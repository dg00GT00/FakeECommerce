using System;
using Infrastructure.Services.PaymentProcessingServices.Interfaces;

namespace Infrastructure.Services.PaymentProcessingServices
{
    /// <summary>
    /// Holds the state of payment processing status
    /// </summary>
    public class PaymentProcessingService : IPaymentProcessingService
    {
        private bool _processingStatus = true;
        public event EventHandler<bool>? PaymentProcessingEvent;

        /// <summary>
        /// Check if the payment processing event has already an method associate with it
        /// </summary>
        public bool HasPaymentProcessingEventMethod => !string.IsNullOrEmpty(PaymentProcessingEvent?.Method.Name);

        private void OnPaymentProcessingStatusChange(bool e)
        {
            PaymentProcessingEvent?.Invoke(this, e);
        }

        /// <summary>
        /// If the payment processing status is running 
        /// </summary>
        public bool ProcessingStatus
        {
            get => _processingStatus;
            set
            {
                _processingStatus = value;
                OnPaymentProcessingStatusChange(value);
            }
        }
    }
}