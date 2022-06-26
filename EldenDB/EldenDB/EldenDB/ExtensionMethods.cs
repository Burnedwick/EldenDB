using EldenDB.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenDB
{
    public static class ExtensionMethods
    {
        public static Weapon ConvertFromDatumToWeapon(this EldenAPIComm.WeaponEndpoint.Datum datum)
        {
            string StrScaling = "None";
            string DexScaling = "None";
            string IntScaling = "None";
            string FaiScaling = "None";
            string ArcScaling = "None";

            int StrReq =   0;
            int DexReq =   0;
            int IntReq =   0;
            int FaithReq = 0;
            int ArcReq =   0;
            //Find out what attributes the weapon scales with
            for (int i = 0; i < datum.scalesWith.Length; i++)
            {
                switch (datum.scalesWith[i].name)
                {
                    case "Str":
                        StrScaling = datum.scalesWith[i].scaling;
                        break;
                    case "Dex":
                        DexScaling = datum.scalesWith[i].scaling;
                        break;
                    case "Int":
                        IntScaling = datum.scalesWith[i].scaling;
                        break;
                    case "Fai":
                        FaiScaling = datum.scalesWith[i].scaling;
                        break;
                    case "Arc":
                        ArcScaling = datum.scalesWith[i].scaling;
                        break;
                    default:
                        break;
                }
            }
            //Find out what the weapon scales with
            for (int i = 0; i < datum.requiredAttributes.Length; i++)
            {
                switch (datum.requiredAttributes[i].name)
                {
                    case "Str":
                        StrReq = datum.requiredAttributes[i].amount;
                        break;
                    case "Dex":
                        DexReq = datum.requiredAttributes[i].amount;
                        break;
                    case "Fai":
                        FaithReq = datum.requiredAttributes[i].amount;
                        break;
                    case "Int":
                        IntReq = datum.requiredAttributes[i].amount;
                        break;
                    case "Arc":
                        ArcReq = datum.requiredAttributes[i].amount;
                        break;
                    default:
                        break;
                }
            }
            return new Weapon() { 
            Name = datum.name,
            Image = datum.image,
            FaithScaling = FaiScaling,
            IntScaling = IntScaling,
            ArcaneScaling = ArcScaling,
            StrScaling = StrScaling,
            DexScaling = DexScaling,
            RequiredStr = StrReq,
            RequiredDex = DexReq,
            RequiredArcane = ArcReq,
            RequiredFaith = FaithReq,
            RequiredInt = IntReq,
            PhysicalDmg = datum.attack[0].amount,
            MagicDmg = datum.attack[1].amount,
            FireDmg = datum.attack[2].amount,
            LightningDmg = datum.attack[3].amount,
            HolyDmg = datum.attack[4].amount,
            CriticalDmg = datum.attack[5].amount,
            Description = datum.description,
            Id = datum.id,
            WeaponCategory = datum.category,
            Weight = datum.weight,
            PhysicalGuard = datum.defence[0].amount,
            MagicGuard = datum.defence[1].amount,
            FireGuard = datum.defence[2].amount,
            LightningGuard = datum.defence[3].amount,
            HolyGuard = datum.defence[4].amount,
            GuardBoost = datum.defence[5].amount,
            };
        }
        public static Armor ConvertFromDatumToArmor(this EldenAPIComm.ArmorEndpoint.Datum datum)
        {
            return new Armor()
            {
                Phy = datum.dmgNegation[0].name,
                PhyNeg = datum.dmgNegation[0].amount,
                Strike = datum.dmgNegation[1].name,
                StrikeNeg = datum.dmgNegation[1].amount,
                Slash = datum.dmgNegation[2].name,
                SlashNeg = datum.dmgNegation[2].amount,
                Pierce = datum.dmgNegation[3].name,
                PierceNeg = datum.dmgNegation[3].amount,
                Magic = datum.dmgNegation[4].name,
                MagicNeg = datum.dmgNegation[4].amount,
                Fire = datum.dmgNegation[5].name,
                FireNeg = datum.dmgNegation[5].amount,
                Ligt = datum.dmgNegation[6].name,
                LigtNeg = datum.dmgNegation[6].amount,
                Holy = datum.dmgNegation[7].name,
                HolyNeg = datum.dmgNegation[7].amount,

                Immunity = datum.resistance[0].name,
                ImmunityNeg = datum.resistance[0].amount,
                Robustness = datum.resistance[1].name,
                RobustnessNeg = datum.resistance[1].amount,
                Focus = datum.resistance[2].name,
                FocusNeg = datum.resistance[2].amount,
                Vitality = datum.resistance[3].name,
                VitalityNeg = datum.resistance[3].amount,
                Poise = datum.resistance[4].name,
                PoiseAmt = datum.resistance[4].amount,

                Category = datum.category,
                Description = datum.description,
                ID = datum.id,
                Image = datum.image,
                Name = datum.name,
                Weight = datum.weight,
            };
        }
    }
}
