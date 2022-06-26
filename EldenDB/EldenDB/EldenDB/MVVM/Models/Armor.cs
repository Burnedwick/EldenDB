using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenDB.MVVM.Models
{
    public class Armor
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Phy { get; set; }
        public string Strike { get; set; }
        public string Slash { get; set; }
        public string Pierce { get; set; }
        public string Magic { get; set; }
        public string Fire { get; set; }
        public string Ligt { get; set; }
        public string Holy { get; set; }
        public string Immunity { get; set; }
        public string Robustness { get; set; }
        public string Focus { get; set; }
        public string Vitality { get; set; }
        public string Poise { get; set; }
        public double PhyNeg { get; set; }
        public double StrikeNeg { get; set; }
        public double SlashNeg { get; set; }
        public double PierceNeg { get; set; }
        public double MagicNeg { get; set; }
        public double FireNeg { get; set; }
        public double LigtNeg { get; set; }
        public double HolyNeg { get; set; }
        public double ImmunityNeg { get; set; }
        public double RobustnessNeg { get; set; }
        public double FocusNeg { get; set; }
        public double VitalityNeg { get; set; }
        public double PoiseAmt { get; set; }
        public float Weight { get; set; }
    }
}