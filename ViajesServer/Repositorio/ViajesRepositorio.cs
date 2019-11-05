using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ViajesServer.Commun.Entidades;
using ViajesServer.Repositorio.Interface;
using ViajesServer.Commun.Wrappers;

namespace ViajesServer.Repositorio
{
    public class ViajesRepositorio : IViajesRepositorio
    {
        private readonly IConfiguration _configuracion;

        public ViajesRepositorio(IConfiguration Configuracion)
        {
            _configuracion = Configuracion;
        }



        public ParametosViaje obtenerparametro(string nombreParametro)
        {
            string CadenaDeConexion = _configuracion.GetConnectionString("Default");

            using (SqlConnection conn = new SqlConnection(CadenaDeConexion))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("pa_ObtenerParametros_VUE", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@NombreParametro", nombreParametro);
                var reader = command.ExecuteReader();
                ICollection<ParametosViaje> parametros = new Collection<ParametosViaje>();
                while (reader.Read())
                {
                    ParametosViaje parametro = new ParametosViaje();
                    parametro.IdParametrizacion = Convert.ToInt32(reader[0]);
                    parametro.NombreParametro = Convert.ToString(reader[1]);
                    parametro.ValorParametro = Convert.ToString(reader[2]);
                    parametro.DescripcionParametro = Convert.ToString(reader[3]);
                    parametros.Add(parametro);
                }
                return parametros?.ElementAt(0);

            }

        }

        public void RealizarReservaVuelo(VuelosReservas Reserva)
        {
            string CadenaDeConexion = _configuracion.GetConnectionString("Default");

            using (SqlConnection conn = new SqlConnection(CadenaDeConexion))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("pa_InsertarReservaVuelo", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@IdDocumento", Reserva.NumeroCedula);
                command.Parameters.AddWithValue("@IdVuelo", Reserva.IdVuelo);
                command.Parameters.AddWithValue("@ValorReserva", Reserva.PrecioReserva);
                command.ExecuteNonQuery();
            }

        }

        public bool VerificarVuelosUsuarioDia(long NumeroCedula)
        {
            string CadenaDeConexion = _configuracion.GetConnectionString("Default");

            using (SqlConnection conn = new SqlConnection(CadenaDeConexion))
            {
                conn.Open();

                SqlCommand command = new SqlCommand("pa_VerificarVuelosReservados", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@NumeroDeCedula", NumeroCedula);
                var reader = command.ExecuteReader();
                bool permitido;
                if (reader.Read())
                {
                    permitido = Convert.ToBoolean(reader[0]);
                }
                else
                {
                    permitido = false;
                }

                return permitido;
            }
        }



        public ICollection<Vuelos> ObtenerTodosVuelosDisponibles()
        {
            string CadenaDeConexion = _configuracion.GetConnectionString("Default");
            ICollection<Vuelos> vuelos = new Collection<Vuelos>();
            using (SqlConnection conn = new SqlConnection(CadenaDeConexion))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("pa_ObtenerTodosVuelosDisponibles", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Vuelos vuelo = new Vuelos();

                    vuelo.IdVuelo = Convert.ToInt64(reader["IdVuelo_VUE"]);
                    vuelo.IdLocalidadOrigen = Convert.ToInt64(reader["IdLocalidadOrigen_VUE"]);
                    vuelo.NombreOrigen = Convert.ToString(reader["origen"]);
                    vuelo.IdLocalidadDestino = Convert.ToInt64(reader["IdLocalidadDestino_VUE"]);
                    vuelo.NombreDestino = Convert.ToString(reader["destino"]);
                    vuelo.Capacidad = Convert.ToInt32(reader["Capacidad_VUE"]);
                    vuelo.Disponibles = Convert.ToInt32(reader["Disponible_VUE"]);
                    vuelo.HoraVuelo = Convert.ToDateTime(reader["FechaVuelo_VUE"]);
                    vuelo.Precio = Convert.ToDecimal(reader["Precio_VUE"]);
                    vuelos.Add(vuelo);
                }

            }
            return vuelos;

        }

        public ICollection<Vuelos> ObtenerVuelosDisponibles(long Origen, long Destino, DateTime FechaVuelo)
        {
            string CadenaDeConexion = _configuracion.GetConnectionString("Default");
            ICollection<Vuelos> vuelos = new Collection<Vuelos>();
            using (SqlConnection conn = new SqlConnection(CadenaDeConexion))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("pa_ObtenerVuelosDisponibles", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Origen", Origen);
                command.Parameters.AddWithValue("@Destino", Destino);
                command.Parameters.AddWithValue("@Fecha", FechaVuelo);
                var reader = command.ExecuteReader();

                while(reader.Read())
                {
                    Vuelos vuelo = new Vuelos();

                    vuelo.IdVuelo = Convert.ToInt64(reader["IdVuelo_VUE"]);
                    vuelo.IdLocalidadOrigen = Convert.ToInt64(reader["IdLocalidadOrigen_VUE"]);
                    vuelo.NombreOrigen = Convert.ToString(reader["origen"]);
                    vuelo.IdLocalidadDestino = Convert.ToInt64(reader["IdLocalidadDestino_VUE"]);
                    vuelo.NombreDestino = Convert.ToString(reader["destino"]);
                    vuelo.Capacidad = Convert.ToInt32(reader["Capacidad_VUE"]);
                    vuelo.Disponibles = Convert.ToInt32(reader["Disponible_VUE"]);
                    vuelo.HoraVuelo = Convert.ToDateTime(reader["FechaVuelo_VUE"]);
                    vuelo.Precio = Convert.ToDecimal(reader["Precio_VUE"]);
                    vuelos.Add(vuelo);
                }

            }
            return vuelos;

        }

        public ICollection<ReservasVuelosUsuarios_Wrapper> ObtenerReservasUsuario(long Documento)
        {
            string CadenaDeConexion = _configuracion.GetConnectionString("Default");
            ICollection<ReservasVuelosUsuarios_Wrapper> reservas = new Collection<ReservasVuelosUsuarios_Wrapper>();
            using (SqlConnection conn = new SqlConnection(CadenaDeConexion))
            {
                conn.Open();
                SqlCommand command = new SqlCommand("pa_ObtenerReservasPorUsuario", conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@NumeroCedula", Documento);
                var reader = command.ExecuteReader();

                
                while (reader.Read())
                {
                    ReservasVuelosUsuarios_Wrapper reserva = new ReservasVuelosUsuarios_Wrapper();
                    reserva.IdReservaVuelo = Convert.ToInt64(reader[0]);
                    reserva.DocumentoReserva = Convert.ToInt64(reader[1]);
                    reserva.IdVuelo = Convert.ToInt64(reader[2]);
                    reserva.NombreOrigen = Convert.ToString(reader[3]);
                    reserva.NombreDestino = Convert.ToString(reader[4]);
                    reserva.FechaVuelo = Convert.ToDateTime(reader[5]);
                    reserva.PrecioReserva = Convert.ToDecimal(reader[6]);
                    reservas.Add(reserva);
                }

            }
            return reservas;

        }

    }

}


