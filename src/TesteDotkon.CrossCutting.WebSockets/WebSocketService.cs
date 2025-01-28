using System.Net.WebSockets;
using System.Text;

namespace TesteDotkon.CrossCutting.WebSockets;

public class WebSocketService
{
    private List<WebSocket> _sockets = new List<WebSocket>();

    public async Task HandleWebSocketAsync(WebSocket socket)
    {
        var buffer = new byte[1024 * 4];
        _sockets.Add(socket); 

        while (socket.State == WebSocketState.Open)
        {
            WebSocketReceiveResult? result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

            if (result.MessageType == WebSocketMessageType.Text)
            {
                var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine($"Mensagem recebida: {message}");

                var responseMessage = "Mensagem recebida com sucesso!";
                var byteResponse = Encoding.UTF8.GetBytes(responseMessage);
                await socket.SendAsync(new ArraySegment<byte>(byteResponse), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }

        _sockets.Remove(socket);
    }

    public async Task BroadcastMessage(string message)
    {
        var byteResponse = Encoding.UTF8.GetBytes(message);
        foreach (var socket in _sockets)
        {
            if (socket.State == WebSocketState.Open)
            {
                await socket.SendAsync(new ArraySegment<byte>(byteResponse), WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
    }
}
