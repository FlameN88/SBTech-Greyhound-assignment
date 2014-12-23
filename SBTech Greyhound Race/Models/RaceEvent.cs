using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBTech_Greyhound_Race.Models
{
    // Race
    public class RaceEvent
    {

        public int ID { get; set; }                 // unique identifier of the race
        public int EventNumber { get; set; }        // the number of the race (should be displayed in the application)
        public DateTime EventTime { get; set; }     // starting time of the race (should be displayed in the application)
        public DateTime FinishTime { get; set; }    // time when the race is expected to finish (should be displayed in the application)
        public int Distance { get; set; }           // distance that all dogs must run (should be displayed in the application)
        public String Name { get; set; }            // name of the venue (should be displayed in the application)
        public Entry[] Entries { get; set; }        
    }
}