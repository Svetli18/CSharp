﻿using System.Collections.Generic;

namespace Exam.Discord
{
    public class Message
    {
        public Message(string id, string content, int timestamp, string channel)
        {
            this.Id = id;
            this.Content = content;
            this.Timestamp = timestamp;
            this.Channel = channel;
        }

        public string Id { get; set; }

        public string Content { get;set; }

        public int Timestamp { get; set; }

        public string Channel { get; set; }

        public List<string> Reactions { get; set; } = new List<string>();

        public override bool Equals(object obj)
        {
            Message other = obj as Message;

            if (other == null)
            {
                return false;
            }

            return this.Id.Equals(other.Id);
        }
    }
}
