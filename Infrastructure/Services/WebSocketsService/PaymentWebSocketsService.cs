using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Services.PaymentProcessingServices.Interfaces;
using Infrastructure.Services.WebSocketsService.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services.WebSocketsService
{
    /// <summary>
    /// Manages the WebSocket payment processing communication
    /// </summary>
    public class PaymentWebSocketsService : IPaymentWebSocketsService
    {
        private readonly IPaymentProcessingService _paymentProcessing;
        private readonly ILogger<PaymentWebSocketsService> _logger;

        private WebSocket? _webSocket;

        public PaymentWebSocketsService(IPaymentProcessingService paymentProcessing,
            ILogger<PaymentWebSocketsService> logger)
        {
            _logger = logger;
            _paymentProcessing = paymentProcessing;
        }

        /// <summary>
        /// Attaches an WebSocket instance to the payment processing delegate event
        /// </summary>
        /// <param name="webSocket">the WebSocket instance to attach to</param>
        public void ListeningPaymentProcessing(WebSocket webSocket)
        {
            _webSocket = webSocket;
            if (_paymentProcessing.HasPaymentProcessingEventMethod) return;
            _logger.LogInformation("Assigned to payment websocket event");
            _paymentProcessing.PaymentProcessingEvent += PaymentProcessingOnPaymentProcessingEvent;
        }

        /// <summary>
        /// Receives the message sent from WebSocket client application
        /// </summary>
        /// <param name="socket">a WebSocket instance</param>
        /// <param name="handleMessage">an delegate that will be called on each message received from the client</param>
        public async Task MessageReceivedAsync(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
        {
            var buffer = new byte[1024 * 2];
            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                handleMessage(result, buffer);
            }
        }

        private void PaymentProcessingOnPaymentProcessingEvent(object? sender, bool e)
        {
            var byteStatus = Encoding.Default.GetBytes(e.ToString());
            if (_webSocket == null) return;
            Task.Run(async () =>
            {
                _logger.LogInformation("Sending payment status with following value: {ProcessingStatus}", e);
                await _webSocket.SendAsync(
                    new ArraySegment<byte>(byteStatus),
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None);
            });
        }

        public void Dispose()
        {
            _webSocket?.Dispose();
        }
    }
}