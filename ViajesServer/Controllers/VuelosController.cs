using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViajesServer.Commun.Entidades;
using ViajesServer.Commun.Wrappers;
using ViajesServer.Negocio.Interface;

namespace ViajesServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VuelosController : ControllerBase
    {
        public IViajesNegocio _negocio;

        public VuelosController(IViajesNegocio Negocio)
        {
            _negocio = Negocio;
        }

        [HttpGet]
        [Route("{nombre}")]
        public ActionResult ObtenerParametro(string nombre)
        {
            ParametosViaje parametro = _negocio.obtenerparametro(nombre);
            return Ok(parametro);
        }

        [Route("Reservar")]
        [HttpPost(Name = "Reservar")]
        public IActionResult RealizarReservaVuelo(VuelosReservas Reserva)
        {
            try
            {
                _negocio.RealizarReservaVuelo(Reserva);
                return Ok();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpGet]
        [Route("ObtenerVuelosDisponibles/{Origen}/{Destino}/{FechaVuelo}")]
        public IActionResult ObtenerVuelosDisponibles(long Origen, long Destino, DateTime FechaVuelo)
        {
            try
            {
                ICollection<Vuelos> vuelos = _negocio.ObtenerVuelosDisponibles(Origen, Destino, FechaVuelo);
                return Ok(vuelos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        [Route("ReservasUsuario/{Documento}")]
        public IActionResult ObtenerReservasUsuario(long Documento)
        {
            try
            {
                ICollection<ReservasVuelosUsuarios_Wrapper> reservas = _negocio.ObtenerReservasUsuario(Documento);
                return Ok(reservas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Route("ObtenerTodosVuelos")]
        [HttpGet]
        public IActionResult ObtenerTodosVuelosDisponibles()
        {
            try
            {
                ICollection<Vuelos> vuelos = _negocio.ObtenerTodosVuelosDisponibles();
                return Ok(vuelos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Cargando......");
        }
    }
}
