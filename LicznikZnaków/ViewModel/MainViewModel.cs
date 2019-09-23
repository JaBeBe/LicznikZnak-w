using LicznikZnaków.View;
using Xamarin.Forms;
using System.Windows.Input;

namespace LicznikZnaków
{
    class MainViewModel : BaseViewModel
    {
        string _normalText = "";
        string _result = "Brak Danych";

        public MainViewModel()
        {
            this.DoSpellCommand = new Command(() =>
            {
                this.Result = string.Format("Powiększony Tekst: {0}", this.NormalText.ToUpperInvariant());
            }, () =>
            {
                return !string.IsNullOrEmpty(this.NormalText);
            }
            );
            this.NextPageCommand = new Command(async () =>
             {
                 await App.Navigation.PushAsync(new SecondPage());
             });
        }

        public string NormalText
        {
            set
            {
                if (_normalText != value)
                {
                    _normalText = value;
                    OnPropertyChanged();
                    OnPropertyChanged("NormalTextLength");
                    OnPropertyChanged("NormalTextVisibility");
                    ((Command)this.DoSpellCommand).ChangeCanExecute();
                }
            }
            get
            {
                return _normalText;
            }
        }

        public string NormalTextLength
        {
            get
            {
                return string.Format("Wprowadzono {0} znaków", this.NormalText.Length);
            }
        }
        public bool NormalTextVisibility
        {
            get
            {
                return (this.NormalText.Length > 4);
            }
        }
        public string Result
        {
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged();
                }
            }
            get
            {
                return _result;
            }
        }

        public ICommand DoSpellCommand { protected set; get; }
        public ICommand NextPageCommand { protected set; get; }
    }
}
