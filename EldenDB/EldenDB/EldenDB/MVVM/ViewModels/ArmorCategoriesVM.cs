using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EldenDB.MVVM.Models;
using System.Collections.ObjectModel;

namespace EldenDB
{
    public partial class ArmorCategoriesVM : ObservableObject
    {
        private DBService eldenService = new DBService();
        private readonly DBData data;
        private List<EldenAPIComm.ArmorEndpoint.Datum> armorList;
        public ArmorCategoriesVM(DBService service, DBData dBData)
        {
            this.eldenService = service;
            this.data = dBData;
            GetArmorCategories();
        }
        [ObservableProperty]
        private string searchText;
        [ObservableProperty]
        private Armor selectedArmor;
        public ObservableCollection<Armor> Armors { get; } = new();
        //Command on click to change to the category of armor clicked.
        
        //Maybe want to refactor to smaller functions for each category? If I can adapt them to fit in the category view model
        //Though I think I'd like to stick to a easy use func and maybe switch the xaml to a category view
        [ICommand]
        private async void SelectionChanged()
        {
            if (selectedArmor != null)
            {
                data.Category = selectedArmor.Category;
                await Shell.Current.GoToAsync(nameof(ArmorCategoryView), true);
                SelectedArmor = null;
            }
        }
        //When somebody enters the armor category page, this gets the armor list and is called in the ctor
        [ICommand]
        private async void GetArmorCategories()
        {
            armorList = await eldenService.GetArmorList();
            data.ArmorList = armorList;
            Armors.Add(armorList[2].ConvertFromDatumToArmor());
            Armors.Add(armorList[1].ConvertFromDatumToArmor());
            Armors.Add(armorList[8].ConvertFromDatumToArmor());
            Armors.Add(armorList[0].ConvertFromDatumToArmor());
        }
    }
}
