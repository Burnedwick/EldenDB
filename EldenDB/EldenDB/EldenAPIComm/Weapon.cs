using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenAPIComm.WeaponEndpoint
{
    public class Weapon
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
        public Attack[] attack { get; set; }
        public Defence[] defence { get; set; }
        public Scaleswith[] scalesWith { get; set; }
        public Requiredattribute[] requiredAttributes { get; set; }
        public string category { get; set; }
        public float weight { get; set; }
    }

    public class Attack
    {
        public string name { get; set; }
        public int amount { get; set; }
    }

    public class Defence
    {
        public string name { get; set; }
        public int amount { get; set; }
    }

    public class Scaleswith
    {
        public string name { get; set; }
        public string scaling { get; set; }
    }

    public class Requiredattribute
    {
        public string name { get; set; }
        public int amount { get; set; }
    }

}