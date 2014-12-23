using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBTech_Greyhound_Race.Models
{
    // a dog that runs in the race.
    public class Entry
    {
        public int ID { get; set; }             // unique number of the dog
        public String Name { get; set; }        // name of the dog (should be displayed in the application)
        public float OddsDecimal { get; set; }  // odds for the dog to win the race (should be displayed in the application)
    }
}