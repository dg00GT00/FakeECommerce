using System;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Services.PaymentProcessingServices.Interfaces;
using Infrastructure.Services.WebSocketsService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services.WebSocketsService.WebSocketsServiceMiddleware
{
    public class WebSocketServiceMiddleware : IMiddleware
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IPaymentWebSocketsService _socketsService;

        public WebSocketServiceMiddleware(
            IPaymentWebSocketsService socketsService,
            IPaymentProcessingService processingService,
            ILoggerFactory loggerFactory)
        {
            _socketsService = socketsService;
            _loggerFactory = loggerFactory;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                var logger = _loggerFactory.CreateLogger<WebSocketServiceMiddleware>();

                var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                logger.LogInformation("Connected to payment processing websocket");

                _socketsService.ListeningPaymentProcessing(webSocket);

                await _socketsService.MessageReceivedAsync(webSocket, async (result, bytes) =>
                {
                    switch (result.MessageType)
                    {
                        case WebSocketMessageType.Text:
                            break;
                        case WebSocketMessageType.Binary:
                            break;
                        case WebSocketMessageType.Close:
                            await webSocket.CloseAsync(
                                result.CloseStatus ?? WebSocketCloseStatus.Empty,
                                result.CloseStatusDescription,
                                CancellationToken.None);
                            _socketsService.Dispose();
                            logger.LogInformation(
                                "Closed the payment processing connection.\n" +
                                "Status: {Status} - Description: {Description}",
                                result.CloseStatus, result.CloseStatusDescription);
                            break;
                        default:
                            _socketsService.Dispose();
                            throw new ArgumentOutOfRangeException();
                    }
                });
            }
            else
            {
                await next(context);
            }
        }
    }
}