using System.Threading.Channels;
using System.Threading.Tasks;
using Infrastructure.Services.PaymentProcessingServices;
using Infrastructure.Services.WebSocketsService.Interfaces;

namespace Infrastructure.Services.WebSocketsService
{
    public class WebSocketConnectionManager : IWebSocketConnectionManager
    {
        private readonly Channel<PaymentProcessingTracker>
            _channel = Channel.CreateBounded<PaymentProcessingTracker>(
                new BoundedChannelOptions(10)
                {
                    FullMode = BoundedChannelFullMode.DropOldest
                });

        public async Task AddPaymentTrackerAsync(PaymentProcessingTracker paymentTracker)
        {
            await _channel.Writer.WriteAsync(paymentTracker);
        }

        public async Task<PaymentProcessingTracker?> GetPaymentTrackerAsync(string paymentProcessingPath)
        {
            await foreach (var paymentProcessing in _channel.Reader.ReadAllAsync())
            {
                if (paymentProcessing.PaymentProcessingPath == paymentProcessingPath)
                {
                    return paymentProcessing;
                }

                await AddPaymentTrackerAsync(paymentProcessing);
            }

            return null;
        }
    }
}