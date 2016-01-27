using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Hoc_tieng_Nhat_cung_Maruko.Properties;

namespace Hoc_tieng_Nhat_cung_Maruko.Model.Conversation
{
    public class Message : INotifyPropertyChanged, IEquatable<Message>
    {
        public string MessageText { get; set; }
        public SenderSide SenderSide { get; set; }
        public Person Person { get; set; }

        public Message(string messageText, SenderSide senderSide, Person person)
        {
            MessageText = messageText;
            SenderSide = senderSide;
            Person = person;
        }

        public Message()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool Equals(Message other)
        {
            return !(MessageText != other.MessageText || Person != other.Person || SenderSide != other.SenderSide);
        }
    }

    public enum SenderSide
    {
        Sender,
        Receiver
    }
}
