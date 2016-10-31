using System.ComponentModel;
using System.Runtime.CompilerServices;

using WpfLocTest.Annotations;


namespace WpfLocTest
{
    public class MainWindowModel: INotifyPropertyChanged
    {
        private TestLangEnum _someEnumValue;

        public TestLangEnum SomeEnumValue
        {
            get { return _someEnumValue; }
            set
            {
                _someEnumValue = value;
                OnPropertyChanged(nameof(SomeEnumValue));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}