using System.Xml.Serialization;

namespace UniSabana.ApiLibreriaKmlMono.Dtos
{
    [XmlRoot(ElementName = "Document")]
    public class KmlDto
    {

        [XmlElement(ElementName = "Placemark")]
        public Placemark Placemark { get; set; }

        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        [XmlText]
        public DateTime Text { get; set; }
    }

    [XmlRoot(ElementName = "Point")]
    public class Point
    {

        [XmlElement(ElementName = "coordinates")]
        public DateTime Coordinates { get; set; }
    }

    [XmlRoot(ElementName = "Placemark")]
    public class Placemark
    {

        [XmlElement(ElementName = "Point")]
        public Point Point { get; set; }
    }

    
}
