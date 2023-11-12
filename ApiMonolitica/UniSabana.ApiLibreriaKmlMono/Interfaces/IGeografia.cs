using UniSabana.ApiLibreriaKmlMono.Dtos;

namespace UniSabana.ApiLibreriaKmlMono.Interfaces
{
    public interface IGeografia
    {
        void CargarDatos(GeoJsonDto data);
        string MostrarDatos();
    }
}
