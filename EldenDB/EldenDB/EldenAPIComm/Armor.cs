using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenAPIComm.ArmorEndpoint
{
    public class Armor
    {
        public bool success { get; set; }
        public int count { get; set; }
        public int total { get; set; }
        public Datum[] data { get; set; }
    }
    public class Datum
    {
        public string id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public Dmgnegation[] dmgNegation { get; set; }
        public Resistance[] resistance { get; set; }
        public float weight { get; set; }
    }
    public class Dmgnegation
    {
        public string name { get; set; }
        public double amount { get; set; }
    }
    public class Resistance
    {
        public string name { get; set; }
        public int amount { get; set; }
    }
}
