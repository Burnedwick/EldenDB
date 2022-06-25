using EldenAPIComm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EldenDB.MVVM.Models;

namespace EldenDB
{
    public class DBService
    {
        private EldenAPI api = new();
        public async Task<EldenDB.MVVM.Models.Weapon> GetWeaponForCategoryAsync(string weaponName)
        {
            EldenAPIComm.WeaponEndpoint.Datum w = await api.WeaponCallByNameAsync($"{weaponName}");
            Weapon weapon = new Weapon()
            {
                WeaponCategory = w.category,
                Image = w.image,
            };
            return weapon;
        }
        public async Task<List<EldenAPIComm.WeaponEndpoint.Datum>> GetWeaponList()
        {
            return await api.InitializeWeaponData();
        }
        public async Task<List<EldenAPIComm.ArmorEndpoint.Datum>> GetArmorList()
        {
            return await api.InitializeArmorData();
        }
    }
}
