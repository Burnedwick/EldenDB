using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenDB
{
    public partial class MainPageVM : ObservableObject
    {
        [ObservableProperty]
        private string counterLabel = "Current count: 0";
        private int count = 0;
        [ICommand]
        private void CounterClicked()
        {
            count++;
            CounterLabel = $"Current count: {count}";
            SemanticScreenReader.Announce(CounterLabel);
        }
    }
}
