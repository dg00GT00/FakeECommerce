using System.Net.WebSockets;

namespace Infrastructure.Services.PaymentProcessingServices
{
    public class PaymentProcessingTracker
    {
        public string? PaymentProcessingPath { get; set; }
        public WebSocket? Socket { get; set; }
    }
}