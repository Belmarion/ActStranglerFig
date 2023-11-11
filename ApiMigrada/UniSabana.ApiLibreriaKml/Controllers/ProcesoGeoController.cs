using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using UniSabana.ApiLibreriaKml.Dtos;
using UniSabana.ApiLibreriaKml.Interfaces;
using UniSabana.ApiLibreriaKml.Response;
using UniSabana.ApiLibreriaKml.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UniSabana.ApiLibreriaKml.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcesoGeoController : ControllerBase
    {
        private readonly ProcesarGeoJsonServices _obj = new();
        private readonly ProcesarKMLServices _objKml = new();

        [HttpPost("CargarDatosGeoJson")]
        public async Task<ActionResult<bool?>> CargarDatosGeoJson(GeoJsonDto data)
        {
            try
            {
                _obj.CargarDatos(data);
                var response = ApiResponse<bool?>.CreateSuccessful(true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var responseError = ApiResponse<string?>.CreateError(ex.Message);
                return BadRequest(responseError);
            }

        }
        [HttpGet("MostrarDatosGeoJson")]
        public async Task<ActionResult<string?>> MostrarDatosGeoJson()
        {
            try
            {
                var response = ApiResponse<string?>.CreateSuccessful(_obj.MostrarDatos());
                return Ok(response);
            }
            catch (Exception ex)
            {
                var responseError = ApiResponse<string?>.CreateError(ex.Message);
                return BadRequest(responseError);
            }
            
        }
        [HttpPost("CargarDatosGeoJsonParaKML")]
        public async Task<ActionResult<bool?>> CargarDatosGeoJsonParaKML(GeoJsonDto data)
        {
            try
            {
                _objKml.CargarDatos(data);
                var response = ApiResponse<bool?>.CreateSuccessful(true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var responseError = ApiResponse<string?>.CreateError(ex.Message);
                return BadRequest(responseError);
            }

        }
        [HttpGet("MostrarDatosKML")]
        public async Task<ActionResult<string?>> MostrarDatosKML()
        {
            try
            {
                var data = _objKml.MostrarDatos();
                var response = ApiResponse<string?>.CreateSuccessful(_objKml.MostrarDatos());
                return Ok(response);
            }
            catch (Exception ex)
            {
                var responseError = ApiResponse<string?>.CreateError(ex.Message);
                return BadRequest(responseError);
            }

        }

    }
}
