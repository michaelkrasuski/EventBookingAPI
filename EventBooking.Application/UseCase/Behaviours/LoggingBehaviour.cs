﻿using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace EventBooking.Application.UseCase.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehaviour<TRequest, TResponse>> _logger;

        public LoggingBehaviour(ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("EventBooking API Request Handling: { name } {@request }", typeof(TRequest).Name, JsonSerializer.Serialize(request));
            var response = await next();
            _logger.LogInformation("EventBooking API Response Handling: { name } {@response }", typeof(TResponse).Name, JsonSerializer.Serialize(response));

            return response;
        }
    }
}
