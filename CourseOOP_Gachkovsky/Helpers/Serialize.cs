using CourseOOP_Gachkovsky.Models;
using CourseOOP_Gachkovsky.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CourseOOP_Gachkovsky.Helpers
{
    public class Serialize
    {
        public void SerializeTourXML(TourViewModel tours)
        {
            XmlSerializer xml = new XmlSerializer(typeof(TourViewModel));

            using (FileStream fs = new FileStream("Tours.xml", FileMode.Create))
            {
                xml.Serialize(fs, tours);
            }
        }

        public TourViewModel DeserializeTourXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(TourViewModel));
            using (FileStream fs = new FileStream("Tours.xml", FileMode.OpenOrCreate))
            {
                return (TourViewModel)xml.Deserialize(fs);
            }
        }

        public void SerializeRezerveTourXML(RezerveTourViewModel rezerveTours)
        {
            XmlSerializer xml = new XmlSerializer(typeof(RezerveTourViewModel));

            using (FileStream fs = new FileStream("RezerveTours.xml", FileMode.Create))
            {
                xml.Serialize(fs, rezerveTours);
            }
        }

        public RezerveTourViewModel DeserializeRezerveTourXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(RezerveTourViewModel));
            using (FileStream fs = new FileStream("RezerveTours.xml", FileMode.OpenOrCreate))
            {
                return (RezerveTourViewModel)xml.Deserialize(fs);
            }
        }

    }
}
