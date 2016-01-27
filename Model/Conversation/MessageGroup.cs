using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Hoc_tieng_Nhat_cung_Maruko.Properties;

namespace Hoc_tieng_Nhat_cung_Maruko.Model.Conversation
{
    public class MessageGroup : ObservableCollection<Message>
    {
        private List<Message> _messages = new List<Message>();
        private List<Person> _persons = new List<Person>();

        public List<Message> Messages
        {
            get
            {
                return _messages;
            }

            set
            {
                if (value == _messages) return;
                _messages = value;
                OnPropertyChanged();
            }
        }

        public List<Person> Persons
        {
            get { return _persons; }
            set
            {
                if (value == _persons) return;
                _persons = value;
                OnPropertyChanged();
            }
        }

        public MessageGroup()
        {
            Messages = new List<Message>();
            Persons = new List<Person>();
        }

        protected override event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
