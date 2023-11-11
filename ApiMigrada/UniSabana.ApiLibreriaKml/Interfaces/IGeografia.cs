using UniSabana.ApiLibreriaKml.Dtos;

namespace UniSabana.ApiLibreriaKml.Interfaces
{
    public interface IGeografia
    {
        void CargarDatos(GeoJsonDto data);
        string MostrarDatos();
    }
}
