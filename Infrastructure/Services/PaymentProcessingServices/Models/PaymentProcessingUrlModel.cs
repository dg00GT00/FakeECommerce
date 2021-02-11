namespace Infrastructure.Services.PaymentProcessingServices.Models
{
    public class PaymentProcessingUrlModel
    {
        public string SetPaymentProcessingPath { get; set; } = "setpaymentprocessing";
        public string GetPaymentProcessingPath { get; set; } = "getpaymentprocessing";
    }
}