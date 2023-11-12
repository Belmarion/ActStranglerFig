using Newtonsoft.Json;
using SharpKml.Dom;
using System.Collections.Concurrent;
using UniSabana.ApiLibreriaKmlMono.Dtos;
using UniSabana.ApiLibreriaKmlMono.Interfaces;

namespace UniSabana.ApiLibreriaKmlMono.Services
{
    public class ProcesarGeoJsonServices : IGeografia
    {
        private string? _geoJson;
        private static ConcurrentDictionary<string, object> _inMemoryStore = new ConcurrentDictionary<string, object>();
        public void CargarDatos(GeoJsonDto data)
        {
            var dataId = Guid.NewGuid().ToString();
            _inMemoryStore[dataId] = data;
            var geoJsonDto = JsonConvert.SerializeObject(data);
            _geoJson = geoJsonDto;
        }

        public string MostrarDatos()
        {
            var allData = _inMemoryStore.Values.ToList();
            return JsonConvert.SerializeObject(allData);
        }
    }
}
