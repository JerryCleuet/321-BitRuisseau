using Backend.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitRuisseau.Protocol
{
    public class Envelope(string senderId, string receiverId, MessageType type, string message)
    {
        public string Id { get; init; } = Guid.NewGuid().ToString();
        public string SenderId { get; init; } = senderId;
        public string? ReceiverId { get; init; } = receiverId;
        public MessageType Type { get; init; } = type;
        public string Message { get; set; } = message;
    }
}
