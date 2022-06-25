using CommunityToolkit.Mvvm.ComponentModel;
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
    public partial class WeaponCategoriesVM: ObservableObject
    {
        private DBService eldenService = new DBService();
        private readonly DBData data;
        private List<EldenAPIComm.WeaponEndpoint.Datum> weaponList;
        public WeaponCategoriesVM(DBService service, DBData dBData)
        {
            this.eldenService = service;
            this.data = dBData;
            GetWeaponCategories();
        }
        [ObservableProperty]
        private string searchText;
        [ObservableProperty]
        private Weapon selectedWeapon;
        public ObservableCollection<Weapon> Weapons { get; } = new();
        [ICommand]
        private async void SelectionChanged()
        {
            if (selectedWeapon != null)
            {
                data.Category = selectedWeapon.WeaponCategory;
                await Shell.Current.GoToAsync(nameof(CategoryView), true);
                SelectedWeapon = null;
            }
        }
        [ICommand]
        private async void GetWeaponCategories()
        {
            weaponList = await eldenService.GetWeaponList();
            data.WeaponList = weaponList;
            string[] weaponCategories = new string[31] { "Dagger", "Short Sword", "Bastard Sword", "Watchdog's Greatsword", "Estoc",
                "Bloody Helice", "Scimitar", "Omen Cleaver", "Uchigatana", "Gargoyle's Twinblade", "Hand Axe", "Crescent Moon Axe", "Curved Club",
                "Nightrider Flail", "Large Club", "Duelist Greataxe", "Short Spear", "Lance", "Lucerne", "Scythe", "Thorned Whip",
                "Spiked Caestus", "Hookclaws", "Composite Bow", "Serpent Bow", "Erdtree Greatbow", "Light Crossbow", "Hand Ballista",
                "Astrologer's Staff", "Finger Seal", "Sentry's Torch" };
            //Make an array with category names and loop through this for as many categories as there are, then display the categories
            for (int i = 0; i < weaponCategories.Length; i++)
            {
                EldenAPIComm.WeaponEndpoint.Datum w = weaponList.Where(el => el.name == weaponCategories[i]).FirstOrDefault();
                Weapons.Add(w.ConvertFromDatumToWeapon());
            }
        }
    }
}
