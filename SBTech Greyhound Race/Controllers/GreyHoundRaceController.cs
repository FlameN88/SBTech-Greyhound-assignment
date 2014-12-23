using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Http;
using System.Xml;

namespace SBTech_Greyhound_Race.Controllers
{
    public class GreyhoundraceController : ApiController
    {
        protected XmlDocument xml_document;

        // GET api/greyhoundrace
        public String Get()
        {
            return ReadXmlFile();
        }

        protected String ReadXmlFile()
        {
            xml_document = new XmlDocument();
            // TODO: Exceptions
            try
            {
                xml_document.Load(HttpContext.Current.Server.MapPath("~/Content/race.xml"));

                XmlNodeList event_nodes = xml_document.SelectNodes("//UpcomingEvents/RaceEvent");

                // Parse Events
                Models.RaceEvent[] race_events = new Models.RaceEvent[event_nodes.Count];
                for (int i = 0; i < event_nodes.Count; i++)
                {
                    race_events[i] = ParseEvent(event_nodes[i]);
                }

                // Serialize to JSON
                MemoryStream mem_stream = new MemoryStream();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Models.RaceEvent[]));

                ser.WriteObject(mem_stream, race_events);
                mem_stream.Position = 0;
                StreamReader sr = new StreamReader(mem_stream);
                return sr.ReadToEnd();
            } catch (Exception e){
                return "error";
            }
        }

        protected Models.RaceEvent ParseEvent(XmlNode xml_node)
        {
            Models.RaceEvent parsed_event   = new Models.RaceEvent();
            parsed_event.ID                 = Convert.ToInt32(xml_node.Attributes["ID"].Value);
            parsed_event.EventNumber        = Convert.ToInt32(xml_node.Attributes["EventNumber"].Value);
            parsed_event.EventTime          = DateTime.Parse(xml_node.Attributes["EventTime"].Value);
            parsed_event.FinishTime         = DateTime.Parse(xml_node.Attributes["FinishTime"].Value);
            parsed_event.Distance           = Convert.ToInt32(xml_node.Attributes["Distance"].Value);
            parsed_event.Name               = xml_node.Attributes["Name"].Value;

            // Parse Entries
            XmlNodeList entry_nodes = xml_node.SelectNodes("Entry");
            parsed_event.Entries = new Models.Entry[entry_nodes.Count];
            for (int i = 0; i < entry_nodes.Count; i++)
            {
                parsed_event.Entries[i] = ParseEntry(entry_nodes[i]);
            }

            return parsed_event;
        }

        protected Models.Entry ParseEntry(XmlNode xml_node)
        {
            Models.Entry parsed_entry   = new Models.Entry();
            parsed_entry.ID             = Convert.ToInt32(xml_node.Attributes["ID"].Value);
            parsed_entry.Name           = xml_node.Attributes["Name"].Value;
            parsed_entry.OddsDecimal    = Convert.ToSingle(xml_node.Attributes["OddsDecimal"].Value);
            return parsed_entry;

        }
    }
}
