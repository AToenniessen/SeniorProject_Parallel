using EwuConnect.Domain.Models.Profile;
using System;
using System.Collections.Generic;
using System.Text;

namespace EwuConnect.Domain.Models.Chat
{
    public class Message
    {
        public int Id { get; set; }
        public int ConversationId { get; set; }
        public Conversation Conversation { get; set; }
        public int SenderId { get; set; }
        public User Sender { get; set; }
        public string MessageContent { get; set; }
    }
}