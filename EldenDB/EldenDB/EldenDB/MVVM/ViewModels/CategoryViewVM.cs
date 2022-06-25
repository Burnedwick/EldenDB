using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using EldenDB.MVVM.Models;

namespace EldenDB
{
    public partial class CategoryViewVM : ObservableObject
    {
        public ObservableCollection<Weapon> CurrentCategoryWeapons { get; } = new();
        [ObservableProperty]
        private string category;
        [ObservableProperty]
        private Weapon selectedWeapon;
        [ObservableProperty]
        private string searchText;
        [ICommand]
        private async void SelectionChanged()
        {
            if (selectedWeapon != null)
            {
                await Shell.Current.GoToAsync(nameof(WeaponDetailView), true,
                    new Dictionary<string, object>()
                    {
                        {"Weapon", selectedWeapon},
                    });
                SelectedWeapon = null;
            }
        }
        //Need to work on
        [ICommand]
        private async void SearchWeapon()
        {
            if (searchText != null)
            {
                await Shell.Current.GoToAsync(nameof(WeaponDetailView), true,
                    new Dictionary<string, object>()
                    {
                        {"Weapon", selectedWeapon},
                    });
                SelectedWeapon = null;
            }
        }
        //Find all entries that match the category navigated to and instantiate the public observable list with them.
        private DBData data;
        public CategoryViewVM(DBData DBdata)
        {
            this.data = DBdata;
            Category = DBdata.Category;
            IEnumerable<EldenAPIComm.WeaponEndpoint.Datum> matches = data.WeaponList.Where(el => el.category == category);
            foreach (EldenAPIComm.WeaponEndpoint.Datum d in matches)
            {
                CurrentCategoryWeapons.Add(d.ConvertFromDatumToWeapon());
            }
        }
    }
}
