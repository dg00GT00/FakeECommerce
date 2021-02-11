using System;

namespace Infrastructure.Services.PaymentProcessingServices.Interfaces
{
    public interface IPaymentProcessingService
    {
        event EventHandler<bool>? PaymentProcessingEvent;
        bool ProcessingStatus { get; set; }
        bool HasPaymentProcessingEventMethod { get; }
    }
}