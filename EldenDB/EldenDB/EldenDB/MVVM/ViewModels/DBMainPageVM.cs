﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EldenAPIComm;
using EldenDB.MVVM.Models;
using System.Collections.ObjectModel;

namespace EldenDB
{
    public partial class DBMainPageVM : ObservableObject
    {
        [ICommand]
        private async Task GoToCategoryViewAsync()
        {
            await Shell.Current.GoToAsync(nameof(WeaponCategories), true);
        }
    }
}
