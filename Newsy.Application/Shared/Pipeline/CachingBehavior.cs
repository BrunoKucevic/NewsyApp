using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newsy.Application.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Newsy.Application.Shared.Pipeline
{
    public class CachingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheable
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<CachingBehavior<TRequest, TResponse>> _logger;
        public CachingBehavior(IMemoryCache cache, ILogger<CachingBehavior<TRequest, TResponse>> logger)
        {
            _cache = cache;
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = request.GetType();
            _logger.LogInformation($"{requestName} is configured for caching");

            TResponse response;
            if (_cache.TryGetValue(request.CacheKey, out response))
            {
                _logger.LogInformation($"Returning cached value for {requestName}");
                return response;
            }
            _logger.LogInformation($"{requestName} with key: {request.CacheKey} is not cached");
            response = await next();
            _cache.Set(request.CacheKey, response);

            return response;
        }
    }
}
