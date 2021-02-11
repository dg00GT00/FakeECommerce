using System.Threading.Tasks;
using Infrastructure.Services.PaymentProcessingServices;

namespace Infrastructure.Services.WebSocketsService.Interfaces
{
    public interface IWebSocketConnectionManager
    {
        Task AddPaymentTrackerAsync(PaymentProcessingTracker paymentTracker);
        Task<PaymentProcessingTracker?> GetPaymentTrackerAsync(string paymentProcessingPath);
    }
}