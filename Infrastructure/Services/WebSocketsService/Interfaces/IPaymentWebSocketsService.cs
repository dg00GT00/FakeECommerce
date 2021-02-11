using System;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace Infrastructure.Services.WebSocketsService.Interfaces
{
    public interface IPaymentWebSocketsService : IDisposable
    {
        void ListeningPaymentProcessing(WebSocket webSocket);
        Task MessageReceivedAsync(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage);
    }
}