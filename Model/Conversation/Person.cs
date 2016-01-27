using System.ComponentModel;
using System.Runtime.CompilerServices;
using Hoc_tieng_Nhat_cung_Maruko.Properties;

namespace Hoc_tieng_Nhat_cung_Maruko.Model.Conversation
{
    public class Person : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string AvatarUrl { get; set; }

        public Person(string name, string avatarUrl)
        {
            Name = name;
            AvatarUrl = avatarUrl;
        }

        public Person()
        {
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}