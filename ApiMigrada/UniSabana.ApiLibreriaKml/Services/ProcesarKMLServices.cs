using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoJSON.Net;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using SharpKml.Base;
using SharpKml.Dom;
using SharpKml.Engine;
using NetTopologySuite.IO;
using UniSabana.ApiLibreriaKml.DLL;
using UniSabana.ApiLibreriaKml.Interfaces;
using UniSabana.ApiLibreriaKml.Dtos;
using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace UniSabana.ApiLibreriaKml.Services
{
    public class ProcesarKMLServices : IGeografia
    {
        private KmlDll kmlDll = new();
        
        public void CargarDatos(GeoJsonDto data)
        {
            var geoJsonDto = JsonConvert.SerializeObject(data);
            string infoKml = ConvertGeoJSONToKML(geoJsonDto);
            kmlDll.CargarInformacionKML(infoKml);
        }

        public string MostrarDatos()
        {
           return kmlDll.ProcesamientoKMLInformacion();
        }

        private string ConvertGeoJSONToKML(string geoJSONData)
        {
            string xmlKML = string.Empty;
            try
            {
                var geoJsonReader = new GeoJsonReader();
                var featureCollection = geoJsonReader.Read<FeatureCollection>(geoJSONData);

                var document = new Document();

                foreach (var feature in featureCollection.Features)
                {
                    if (feature.Geometry is GeoJSON.Net.Geometry.Point point)
                    {
                        var placemark = new SharpKml.Dom.Placemark();
                        placemark.Geometry = new SharpKml.Dom.Point
                        {
                            Coordinate = new Vector(point.Coordinates.Longitude, point.Coordinates.Latitude)
                        };

                        document.AddFeature(placemark);
                    }
                }

                var kmlSerializer = new Serializer();
                kmlSerializer.Serialize(document);

                xmlKML = kmlSerializer.Xml.ToString();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Se presento un error al convertir el GeoJson a KML");
            }
            return xmlKML;
        }
    }
}
