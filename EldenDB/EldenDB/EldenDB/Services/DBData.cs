using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenDB
{
    public class DBData
    {
        public List<EldenAPIComm.WeaponEndpoint.Datum> WeaponList { get; set; }
        public List<EldenAPIComm.ArmorEndpoint.Datum> ArmorList { get; set; }
        public string Category { get; set; }
    }
}
