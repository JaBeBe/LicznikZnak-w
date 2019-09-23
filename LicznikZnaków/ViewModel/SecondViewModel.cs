using System;
using System.Collections.Generic;
using System.Text;
using LicznikZnaków.Services;
using Xamarin.Forms;

namespace LicznikZnaków
{
    class SecondViewModel : BaseViewModel
    {
        string _langCode = "";

        public SecondViewModel()
        {
            ILangService langserv = DependencyService.Get<ILangService>();
            this.LangCode = string.Format("Twój język to: {0}", langserv.GetlanCode());
        }

        public string LangCode
        {
            set
            {
                if (_langCode != value)
                {
                    _langCode = value;
                    OnPropertyChanged();
                }

            }
            get
            {
                return _langCode;

            }
        }
    }
}
