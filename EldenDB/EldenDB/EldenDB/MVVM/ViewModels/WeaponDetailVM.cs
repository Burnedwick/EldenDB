using CommunityToolkit.Mvvm.ComponentModel;
using EldenDB.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenDB
{
    [QueryProperty(nameof(Weapon), "Weapon")]
    public partial class WeaponDetailVM : ObservableObject
    {
        public WeaponDetailVM(){    }
        [ObservableProperty]
        private Weapon weapon;
    }
}
