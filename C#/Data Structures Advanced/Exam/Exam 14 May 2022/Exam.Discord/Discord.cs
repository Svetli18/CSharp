namespace Exam.Discord
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Discord : IDiscord
    {
        Dictionary<string, Message> byId = new Dictionary<string, Message>();
        Dictionary<string, HashSet<Message>> byChannelAndMassages = new Dictionary<string, HashSet<Message>>();
        OrderedDictionary<int, HashSet<Message>> byTimestampAndMassages = new OrderedDictionary<int, HashSet<Message>>();

        public int Count => this.byId.Count;

        public void SendMessage(Message message)
        {
            if (!this.byId.ContainsKey(message.Id))
            {
                this.byId[message.Id] = message;

                if (!this.byChannelAndMassages.ContainsKey(message.Channel))
                {
                    this.byChannelAndMassages[message.Channel] = new HashSet<Message>();
                }

                if (!this.byTimestampAndMassages.ContainsKey(message.Timestamp))
                {
                    this.byTimestampAndMassages[message.Timestamp] = new HashSet<Message>();
                }

                this.byChannelAndMassages[message.Channel].Add(message);
                this.byTimestampAndMassages[message.Timestamp].Add(message);
            }
        }

        public bool Contains(Message message)
        {
            return this.byId.ContainsKey(message.Id);
        }

        public Message GetMessage(string messageId)
        {
            if (!this.byId.ContainsKey(messageId))
            {
                throw new ArgumentException();
            }

            return this.byId[messageId];
        }

        public void DeleteMessage(string messageId)
        {
            Message message = this.GetMessage(messageId);

            this.byId.Remove(messageId);
            this.byChannelAndMassages[message.Channel].Remove(message);
            this.byTimestampAndMassages[message.Timestamp].Remove(message);
        }

        public void ReactToMessage(string messageId, string reaction)
        {
            Message message = this.GetMessage(messageId);

            message.Reactions.Add(reaction);
        }

        public IEnumerable<Message> GetChannelMessages(string channel)
        {
            if (!this.byChannelAndMassages.ContainsKey(channel))
            {
                throw new ArgumentException();
            }

            return this.byChannelAndMassages[channel];
        }

        public IEnumerable<Message> GetMessagesByReactions(List<string> reactions)
        {
            ICollection<Message> result = new List<Message>();

            var messages = this.byId.Values.Where(x => x.Reactions.Contains(reactions.First()));

            foreach (var message in messages)
            {
                bool containsAll = true;

                foreach (var reaction in reactions)
                {
                    if (!message.Reactions.Contains(reaction))
                    {
                        containsAll = false;
                        break;
                    }
                }

                if (containsAll)
                {
                    result.Add(message);
                }
            }

            return result
                .OrderByDescending(x => x.Reactions.Count)
                .ThenBy(x => x.Timestamp);
        }

        public IEnumerable<Message> GetMessageInTimeRange(int lowerBound, int upperBound)
        {
            IEnumerable<Message> result = this.byTimestampAndMassages
                .Range(lowerBound, true, upperBound, true)
                .SelectMany(x => x.Value)
                .OrderByDescending(x => x.Channel);

            return result;
        }

        public IEnumerable<Message> GetTop3MostReactedMessages()
        {
            IEnumerable<Message> result = new List<Message>(this.byId.Values
                .OrderByDescending(x => x.Reactions.Count)
                .Take(3));

            return result;
        }

        public IEnumerable<Message> GetAllMessagesOrderedByCountOfReactionsThenByTimestampThenByLengthOfContent()
        {
            IEnumerable<Message> result = new List<Message>(this.byId.Values
                .OrderByDescending(x => x.Reactions.Count)
                .ThenBy(x => x.Timestamp)
                .ThenBy(x => x.Content.Length));

            return result;
        }
    }
}
