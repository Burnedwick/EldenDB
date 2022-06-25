using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenDB.MVVM.Models
{
    public class Weapon
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int PhysicalDmg { get; set; }
        public int MagicDmg { get; set; }
        public int FireDmg { get; set; }
        public int LightningDmg { get; set; }
        public int HolyDmg { get; set; }
        public int CriticalDmg { get; set; }
        public string StrScaling { get; set; }
        public string DexScaling { get; set; }
        public string IntScaling { get; set; }
        public string FaithScaling { get; set; }
        public string ArcaneScaling { get; set; }
        public int RequiredStr { get; set; }
        public int RequiredDex { get; set; }
        public int RequiredInt { get; set; }
        public int RequiredFaith { get; set; }
        public int RequiredArcane { get; set; }
        public int PhysicalGuard { get; set; }
        public int MagicGuard { get; set; }
        public int FireGuard { get; set; }
        public int LightningGuard { get; set; }
        public int HolyGuard { get; set; }
        public int GuardBoost { get; set; }
        public string WeaponCategory { get; set; }
        public double Weight { get; set; }
    }
}
