namespace UniSabana.ApiLibreriaKmlMono.Dtos
{
    public class GeoJsonDto
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }
    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<int> coordinates { get; set; }
    }

    public class Properties
    {
    }
}
