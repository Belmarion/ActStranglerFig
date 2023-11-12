using Newtonsoft.Json;
using System.Collections.Concurrent;

namespace UniSabana.ApiLibreriaKmlMono.DLL
{
    public class KmlDll
    {
        private static ConcurrentDictionary<string, object> _inMemoryStore = new ConcurrentDictionary<string, object>();
        public void CargarInformacionKML(string kmlData)
        {
            var dataId = Guid.NewGuid().ToString();
            _inMemoryStore[dataId] = kmlData;
            Console.WriteLine("Cargar información KML: " + kmlData);
        }
        public string ProcesamientoKMLInformacion()
        {
            var allData = _inMemoryStore.Values.ToList();
            return $"{JsonConvert.SerializeObject(allData)}\n";
        }
    }
}
