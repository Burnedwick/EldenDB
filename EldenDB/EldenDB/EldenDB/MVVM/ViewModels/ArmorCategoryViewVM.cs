using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EldenAPIComm;
using EldenDB.MVVM.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace EldenDB
{
    public partial class ArmorCategoryViewVM : ObservableObject
    {
        public ObservableCollection<Armor> CurrentCategoryArmors { get; } = new();
        [ObservableProperty]
        private string category;
        [ObservableProperty]
        private Armor selectedArmor;
        [ObservableProperty]
        private string searchText;
        [ICommand]
        private async void SelectionChanged()
        {
            if (selectedArmor != null)
            {
                await Shell.Current.GoToAsync(nameof(WeaponDetailView), true,
                    new Dictionary<string, object>()
                    {
                        {"Armor", selectedArmor},
                    });
                SelectedArmor = null;
            }
        }
        //Find all entries that match the category navigated to and instantiate the public observable list with them.
        private DBData data;
        public ArmorCategoryViewVM(DBData DBdata)
        {
            this.data = DBdata;
            Category = DBdata.Category;
            IEnumerable<EldenAPIComm.ArmorEndpoint.Datum> matches = data.ArmorList.Where(el => el.category == category);
            foreach (EldenAPIComm.ArmorEndpoint.Datum d in matches)
            {
                CurrentCategoryArmors.Add(d.ConvertFromDatumToArmor());
            }
        }
    }
}
