using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_Example.ViewModel
{
    public class MainWindowVM : PropertyBase
    {
        public string Title { get; set; }

        public MainWindowVM()
        {
            Title = "Beautiful example of WPF App using MVVM Pattern!";
        }
    }
}
