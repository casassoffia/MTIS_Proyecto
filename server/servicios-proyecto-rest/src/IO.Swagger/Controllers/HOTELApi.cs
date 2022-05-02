/*
 * SERVICIOS PROYECTO
 *
 * API del PROYECTO
 *
 * OpenAPI spec version: 1.0.0
 * Contact: you@your-company.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using IO.Swagger.Attributes;

using Microsoft.AspNetCore.Authorization;
using IO.Swagger.Models;
using MySql.Data.MySqlClient;

namespace IO.Swagger.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class HOTELApiController : ControllerBase
    {

        public List<Hotel> hoteles = new List<Hotel>();

        /// <summary>
        /// Comprobar hoteles disponibles
        /// </summary>
        /// <param name="listaHoteles">Lista de hoteles que cumplen las características anteriores</param>
        /// <response code="200">Hoteles con las características</response>
        /// <response code="400">ERROR 400: No hay hoteles con esas características</response>
        [HttpPost]
        [Route("/aditwitter20212022/proyecto/1.0.0/comprobarDisponibilidadHotel")]
        [ValidateModelState]
        [SwaggerOperation("ComprobarDisponibilidadHotelPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Hotel>), description: "Hoteles con las características")]
        public virtual IActionResult ComprobarDisponibilidadHotelPost([FromBody][Required()]List<Hotel> listaHoteles)
        {
            List<Hotel> filtradoHoteles = new List<Hotel>();

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=localhost;user id=root;database=companiarea;Password=root";
            con.Open();
            for (int i = 0; i < listaHoteles.Count; i++)
            {
                if (listaHoteles[i].Disponibilidad.Value)
                {
                    filtradoHoteles.Add(listaHoteles[i]);
                }
            }
            hoteles = filtradoHoteles;

            string exampleJson = "[";
            string disp = "";
            for (int i = 0; i < filtradoHoteles.Count; i++)
            {
                if (filtradoHoteles[i].Disponibilidad.Value)
                {
                    disp = "true";
                }
                else
                {
                    disp = "false";
                }
                exampleJson += " {\n  \"numeroPersonas\" : " + filtradoHoteles[i].NumeroPersonas.ToString() + ",\n  \"disponibilidad\" : " + disp + ",\n  \"puntuacion\" : " + filtradoHoteles[i].Puntuacion.ToString() + ",\n  \"precioNoche\" : " + filtradoHoteles[i].PrecioNoche.ToString() + ",\n  \"lugar\" : \"" + filtradoHoteles[i].Lugar + "\",\n  \"name\" : \"" + filtradoHoteles[i].NumeroPersonas + "\",\n  \"description\" : \"" + filtradoHoteles[i].NumeroPersonas.ToString() + "\",\n  \"id\" : " + filtradoHoteles[i].Id.ToString() + " \n}";
                if (i != (filtradoHoteles.Count - 1))
                {
                    exampleJson += ", ";
                }
            }
            exampleJson += " ]";
            var example = exampleJson != null
                ? JsonConvert.DeserializeObject<List<Hotel>>(exampleJson)
                : default(List<Hotel>);
            con.Close();
            if (exampleJson == null)
            {
                return new ObjectResult("ERROR 400: NO EXISTEN HOTELES") { StatusCode = 400 };
            }

            return new ObjectResult(exampleJson) { StatusCode = 200 };
        }

        /// <summary>
        /// Comprobar hoteles para esas caracterísiticas
        /// </summary>
        /// <param name="fechaIn">Check-in con formato YYYY-MM-DD</param>
        /// <param name="fechaOut">Check-out con formato YYYY-MM-DDY</param>
        /// <param name="lugar">Lugar de estancia</param>
        /// <response code="200">Hoteles con las características</response>
        /// <response code="400">ERROR 400: No hay hoteles con esas características</response>
        [HttpPost]
        [Route("/aditwitter20212022/proyecto/1.0.0/comprobarFechaLugarHotel/{fechaIn}/{fechaOut}/{lugar}")]
        [ValidateModelState]
        [SwaggerOperation("ComprobarFechaLugarHotelFechaInFechaOutLugarPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Hotel>), description: "Hoteles con las características")]
        public virtual IActionResult ComprobarFechaLugarHotelFechaInFechaOutLugarPost([FromRoute][Required]string fechaIn, [FromRoute][Required]string fechaOut, [FromRoute][Required]string lugar)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=localhost;user id=root;database=companiarea;Password=root";

            con.Open();
            MySqlCommand cmdClave1 = new MySqlCommand("ALTER TABLE reservaHotel MODIFY fechaInicio date", con);
            cmdClave1.ExecuteReader();
            con.Close();

            con.Open();
            MySqlCommand cmdClave3 = new MySqlCommand("ALTER TABLE reservaHotel MODIFY fechaFin date", con);
            cmdClave3.ExecuteReader();
            con.Close();

            DateTime fecha1 = DateTime.ParseExact(fechaIn, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime fecha2 = DateTime.ParseExact(fechaOut, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            // INTRODUCIR FECHAS EN FORMATO 2022-04-28
            con.Open();
            MySqlCommand cmdClave = new MySqlCommand("select codigoHotel from reservaHotel where fechaInicio <= @fecha1 OR fechaFin >= @fecha2", con);
            cmdClave.Parameters.AddWithValue("@fecha1", fecha1);
            cmdClave.Parameters.AddWithValue("@fecha2", fecha2);
            MySqlDataReader reader = cmdClave.ExecuteReader();

            int codigoH = 0;
            List<int> codigosHoteles = new List<int>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    codigoH = reader.GetInt32("codigoHotel");
                    codigosHoteles.Add(codigoH);
                }

                con.Close();
            }
            else
            {
                return new ObjectResult("ERROR 400: NO EXISTEN HOTELES") { StatusCode = 400 };
            }

            string exampleJson = "[";
            List<Hotel> leidos = new List<Hotel>();
            Console.WriteLine(codigosHoteles.Count);
            foreach (int codigoHotel in codigosHoteles)
            {
                con.Open();
                MySqlCommand cmdClave5 = new MySqlCommand("select count(*) from hotel where id NOT IN (@id) and lugar=@lugar", con);
                cmdClave5.Parameters.AddWithValue("@id", codigoHotel);
                cmdClave5.Parameters.AddWithValue("@lugar", lugar);
                var readerContar = cmdClave5.ExecuteScalar();
                con.Close();
                con.Open();
                MySqlCommand cmdClave2 = new MySqlCommand("select * from hotel where id NOT IN (@id) and lugar=@lugar", con);
                cmdClave2.Parameters.AddWithValue("@id", codigoHotel);
                cmdClave2.Parameters.AddWithValue("@lugar", lugar);
                MySqlDataReader reader2 = cmdClave2.ExecuteReader();

                var contador = 1;
                string disp = "";

                while (reader2.Read())
                {
                    Hotel hotel = new Hotel();
                    hotel.Id = reader2.GetInt32("id");
                    hotel.Name = reader2.GetString("name");
                    hotel.Description = reader2.GetString("description");
                    hotel.PrecioNoche = Convert.ToDecimal(reader2.GetDouble("precioNoche"));
                    hotel.NumeroPersonas = reader2.GetInt32("numeroPersonas");
                    hotel.Puntuacion = reader2.GetInt32("puntuacion");
                    if (reader2.GetBoolean("disponibilidad"))
                    {
                        disp = "true";
                    }
                    else
                    {
                        disp = "false";
                    }

                    hotel.Lugar = reader2.GetString("lugar");
                    hotel.Disponibilidad = reader2.GetBoolean("disponibilidad");
                    bool repetido = false;
                    for (int i = 0; i < leidos.Count; i++)
                    {
                        if (leidos[i].Id == hotel.Id)
                        {
                            repetido = true;
                        }
                    }
                    if (!repetido)
                    {
                        leidos.Add(hotel);
                        exampleJson += " {\n  \"numeroPersonas\" : " + hotel.NumeroPersonas.ToString() + ",\n  \"disponibilidad\" : " + disp + ",\n  \"puntuacion\" : " + hotel.Puntuacion.ToString() + ",\n  \"precioNoche\" : " + hotel.PrecioNoche.ToString() + ",\n  \"lugar\" : \"" + hotel.Lugar.ToString() + "\",\n  \"name\" : \"" + hotel.Name.ToString() + "\",\n  \"description\" : \"" + hotel.Description.ToString() + "\",\n  \"id\" : " + hotel.Id.ToString() + " \n}";
                        if (!(contador).ToString().Equals(readerContar.ToString()))
                        {
                            exampleJson += ", ";
                        }
                        contador++;
                    }
                }
                con.Close();
            }

            exampleJson += " ]";
            var example = exampleJson != null
                ? JsonConvert.DeserializeObject<List<Hotel>>(exampleJson)
                : default(List<Hotel>);

            if (exampleJson == null)
            {
                return new ObjectResult("ERROR 400: NO EXISTEN HOTELES") { StatusCode = 400 };
            }
            else
            {
                hoteles = JsonConvert.DeserializeObject<List<Hotel>>(exampleJson);
                Console.WriteLine(exampleJson);
                return new ObjectResult(exampleJson) { StatusCode = 200 };
            }
        }

        /// <summary>
        /// Comprobar hoteles para esas caracterísiticas
        /// </summary>
        /// <param name="n">Número de personas</param>
        /// <param name="listaHoteles">Lista de hoteles que cumplen las características anteriores</param>
        /// <response code="200">Hoteles con las características</response>
        /// <response code="400">ERROR 400: No hay hoteles con esas características</response>
        [HttpPost]
        [Route("/aditwitter20212022/proyecto/1.0.0/comprobarPersonasHotel/{n}")]
        [ValidateModelState]
        [SwaggerOperation("ComprobarPersonasHotelNPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Hotel>), description: "Hoteles con las características")]
        public virtual IActionResult ComprobarPersonasHotelNPost([FromRoute][Required]int? n, [FromBody][Required()]List<Hotel> listaHoteles)
        {
            List<Hotel> filtradoHoteles = new List<Hotel>();

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=localhost;user id=root;database=companiarea;Password=root";
            con.Open();
            for (int i = 0; i < listaHoteles.Count; i++)
            {
                if (listaHoteles[i].NumeroPersonas == n)
                {
                    filtradoHoteles.Add(listaHoteles[i]);
                }
            }
            hoteles = filtradoHoteles;

            string exampleJson = "[";
            string disp = "";
            for (int i = 0; i < filtradoHoteles.Count; i++)
            {
                if (filtradoHoteles[i].Disponibilidad.Value)
                {
                    disp = "true";
                }
                else
                {
                    disp = "false";
                }
                exampleJson += " {\n  \"numeroPersonas\" : " + filtradoHoteles[i].NumeroPersonas.ToString() + ",\n  \"disponibilidad\" : " + disp + ",\n  \"puntuacion\" : " + filtradoHoteles[i].Puntuacion.ToString() + ",\n  \"precioNoche\" : " + filtradoHoteles[i].PrecioNoche.ToString() + ",\n  \"lugar\" : \"" + filtradoHoteles[i].Lugar + "\",\n  \"name\" : \"" + filtradoHoteles[i].NumeroPersonas + "\",\n  \"description\" : \"" + filtradoHoteles[i].NumeroPersonas.ToString() + "\",\n  \"id\" : " + filtradoHoteles[i].Id.ToString() + " \n}";
                if (i != (filtradoHoteles.Count - 1))
                {
                    exampleJson += ", ";
                }
            }
            exampleJson += " ]";
            var example = exampleJson != null
                ? JsonConvert.DeserializeObject<List<Hotel>>(exampleJson)
                : default(List<Hotel>);
            con.Close();
            if (exampleJson == null)
            {
                return new ObjectResult("ERROR 400: NO EXISTEN HOTELES") { StatusCode = 400 };
            }

            return new ObjectResult(exampleJson) { StatusCode = 200 };
        }

        /// <summary>
        /// Comprobar hoteles para esas caracterísiticas
        /// </summary>
        /// <param name="precioInicio">Rango inicial del precio</param>
        /// <param name="precioFin">Rango final del precio</param>
        /// <param name="listaHoteles">Lista de hoteles que cumplen las características anteriores</param>
        /// <response code="200">Hoteles con las características</response>
        /// <response code="400">ERROR 400: No hay hoteles con esas características</response>
        [HttpPost]
        [Route("/aditwitter20212022/proyecto/1.0.0/comprobarPreciosHotel/{precioInicio}/{precioFin}")]
        [ValidateModelState]
        [SwaggerOperation("ComprobarPreciosHotelPrecioInicioPrecioFinPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Hotel>), description: "Hoteles con las características")]
        public virtual IActionResult ComprobarPreciosHotelPrecioInicioPrecioFinPost([FromRoute][Required]decimal? precioInicio, [FromRoute][Required]decimal? precioFin, [FromBody][Required()]List<Hotel> listaHoteles)
        {
            List<Hotel> filtradoHoteles = new List<Hotel>();

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=localhost;user id=root;database=companiarea;Password=root";
            con.Open();
            for (int i = 0; i < listaHoteles.Count; i++)
            {
                if (listaHoteles[i].PrecioNoche <= precioFin && listaHoteles[i].PrecioNoche >= precioInicio)
                {
                    filtradoHoteles.Add(listaHoteles[i]);
                }
            }
            hoteles = filtradoHoteles;

            string exampleJson = "[";
            string disp = "";
            for (int i = 0; i < filtradoHoteles.Count; i++)
            {
                if (filtradoHoteles[i].Disponibilidad.Value)
                {
                    disp = "true";
                }
                else
                {
                    disp = "false";
                }
                exampleJson += " {\n  \"numeroPersonas\" : " + filtradoHoteles[i].NumeroPersonas.ToString() + ",\n  \"disponibilidad\" : " + disp + ",\n  \"puntuacion\" : " + filtradoHoteles[i].Puntuacion.ToString() + ",\n  \"precioNoche\" : " + filtradoHoteles[i].PrecioNoche.ToString() + ",\n  \"lugar\" : \"" + filtradoHoteles[i].Lugar + "\",\n  \"name\" : \"" + filtradoHoteles[i].NumeroPersonas + "\",\n  \"description\" : \"" + filtradoHoteles[i].NumeroPersonas.ToString() + "\",\n  \"id\" : " + filtradoHoteles[i].Id.ToString() + " \n}";
                if (i != (filtradoHoteles.Count - 1))
                {
                    exampleJson += ", ";
                }
            }
            exampleJson += " ]";
            var example = exampleJson != null
                ? JsonConvert.DeserializeObject<List<Hotel>>(exampleJson)
                : default(List<Hotel>);
            con.Close();
            if (exampleJson == null)
            {
                return new ObjectResult("ERROR 400: NO EXISTEN HOTELES") { StatusCode = 400 };
            }

            return new ObjectResult(exampleJson) { StatusCode = 200 };
        }

        /// <summary>
        /// Obtiene el hotel con mejor puntuación
        /// </summary>
        /// <param name="hoteles">pasar lista de hoteles</param>
        /// <response code="200">Hotel con mejor puntuación</response>
        /// <response code="400">No hay ningún hotel</response>
        [HttpPost]
        [Route("/aditwitter20212022/proyecto/1.0.0/hotel")]
        [ValidateModelState]
        [SwaggerOperation("HotelPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(Hotel), description: "Hotel con mejor puntuación")]
        public virtual IActionResult HotelPost([FromBody][Required()]List<Hotel> listaHoteles)
        {
            Hotel mejorHotel = new Hotel();
            mejorHotel.Puntuacion = 0;
            string disp = "";
            string exampleJson = "";
            for (int i = 0; i < listaHoteles.Count; i++)
            {
                if (listaHoteles[i].Puntuacion >= mejorHotel.Puntuacion)
                {
                    mejorHotel = listaHoteles[i];
                }
            }
            if (mejorHotel.Disponibilidad.Value)
            {
                disp = "true";
            }
            else
            {
                disp = "false";
            }
            exampleJson = "{\n  \"numeroPersonas\" : " + mejorHotel.NumeroPersonas.ToString() + ",\n  \"disponibilidad\" : " + disp + ",\n  \"puntuacion\" : " + mejorHotel.Puntuacion.ToString() + ",\n  \"precioNoche\" : " + mejorHotel.PrecioNoche.ToString() + ",\n  \"lugar\" : \"" + mejorHotel.Lugar + "\",\n  \"name\" : \"" + mejorHotel.NumeroPersonas + "\",\n  \"description\" : \"" + mejorHotel.NumeroPersonas.ToString() + "\",\n  \"id\" : " + mejorHotel.Id.ToString() + " \n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Hotel>(exampleJson)
            : default(Hotel);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Eliminar reserva</remarks>
        /// <param name="id">pasar id de la reserva a borrar</param>
        /// <response code="204">Reserva borrada</response>
        /// <response code="404">No se ha encontrado la reserva</response>
        [HttpDelete]
        [Route("/aditwitter20212022/proyecto/1.0.0/reserva/hoteles/borrar/{id}")]
        [ValidateModelState]
        [SwaggerOperation("ReservaHotelesBorrarIdDelete")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse404), description: "No se ha encontrado la reserva")]
        public virtual IActionResult ReservaHotelesBorrarIdDelete([FromRoute][Required]int? id)
        { 
            //TODO: Uncomment the next line to return response 204 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(204);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404, default(InlineResponse404));

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Ver detalles de la reserva</remarks>
        /// <param name="id">pasar id de la reserva del hotek</param>
        /// <response code="200">Reserva del hotel se devuelve</response>
        /// <response code="400">No existe la reserva del hotel</response>
        [HttpGet]
        [Route("/aditwitter20212022/proyecto/1.0.0/reserva/hoteles/consultar/{id}")]
        [ValidateModelState]
        [SwaggerOperation("ReservaHotelesConsultarIdGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(ReservaHotel), description: "Reserva del hotel se devuelve")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse4001), description: "No existe la reserva del hotel")]
        public virtual IActionResult ReservaHotelesConsultarIdGet([FromRoute][Required]int? id)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=localhost;user id=root;database=companiarea;Password=root";
            con.Open();
            string exampleJson = null;
            if (id != null)
            {
                MySqlCommand cmdClave = new MySqlCommand("select * from reservaHotel where idReserva=@id", con);
                cmdClave.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmdClave.ExecuteReader();

                if (reader.Read())
                {
                    int idReserva = reader.GetInt32("idReserva");
                    string dni = reader.GetString("dniCliente");
                    int idHotel = reader.GetInt32("codigoHotel");
                    double precioTotal = reader.GetDouble("precioTotal");
                    string fechaInicio = reader.GetString("fechaInicio");
                    string fechaFin = reader.GetString("fechaFin");
                    con.Close();

                    exampleJson = "{\n  \"fechaInicio\" : \"" + fechaInicio + "\",\n  \"dniCliente\" : \"" + dni + "\",\n  \"precioTotal\" : " + precioTotal.ToString() + ",\n  \"codigoHotel\" : \"" + idHotel.ToString() + "\",\n  \"fechaFin\" : \"" + fechaFin + "\",\n  \"idReserva\" : " + id.ToString() + "\n}";
                }

                var example = exampleJson != null
                ? JsonConvert.DeserializeObject<ReservaHotel>(exampleJson)
                : default(ReservaHotel);            //TODO: Change the data returned
                return new ObjectResult(example);
            }
            else
            {
                return new ObjectResult("ERROR 400: NO EXISTE LA RESERVA") { StatusCode = 400 };
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Decrementar precio de la reserva del hotel</remarks>
        /// <param name="id">pasar id de la reserva</param>
        /// <param name="body">Reserva del hotel</param>
        /// <response code="201">Hotel modificado</response>
        /// <response code="404">Hotel no encontrado</response>
        [HttpPut]
        [Route("/aditwitter20212022/proyecto/1.0.0/reserva/hoteles/modificar/{id}")]
        [ValidateModelState]
        [SwaggerOperation("ReservaHotelesModificarIdPut")]
        public virtual IActionResult ReservaHotelesModificarIdPut([FromRoute][Required]int? id, [FromBody]ReservaHotel body)
        { 
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Crear una reserva del hotel</remarks>
        /// <param name="idHotel">pasar el id del mejor hotel</param>
        /// <param name="dniCliente">pasar el dni del cliente</param>
        /// <param name="fechaIn">pasar fecha inicio</param>
        /// <param name="fechaOut">pasar fecha fin</param>
        /// <param name="body">Reserva de Hotel</param>
        /// <response code="201">Reserva del hotel creada</response>
        /// <response code="400">No existe ese hotel</response>
        /// <response code="409">Esa reserva ya existe</response>
        [HttpPost]
        [Route("/aditwitter20212022/proyecto/1.0.0/reserva/hoteles/nuevo")]
        [ValidateModelState]
        [SwaggerOperation("ReservaHotelesNuevoPost")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "No existe ese hotel")]
        [SwaggerResponse(statusCode: 409, type: typeof(InlineResponse409), description: "Esa reserva ya existe")]
        public virtual IActionResult ReservaHotelesNuevoPost([FromQuery][Required()]int? idHotel, [FromQuery][Required()]string dniCliente, [FromQuery][Required()]string fechaIn, [FromQuery][Required()]string fechaOut)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=localhost;user id=root;database=companiarea;Password=root";
            con.Open();
            if (idHotel != null)
            {
                MySqlCommand cmdClave = new MySqlCommand("select * from hotel where id=@idHotel", con);
                cmdClave.Parameters.AddWithValue("@idHotel", idHotel);
                MySqlDataReader reader = cmdClave.ExecuteReader();


                if (reader.Read())
                {
                    double precioNoche = reader.GetDouble("precioNoche");
                    double precioTotal = 0;
                    con.Close();
                    con.Open();
                    MySqlCommand cmdClave1 = new MySqlCommand("ALTER TABLE reservaHotel MODIFY fechaInicio date", con);
                    cmdClave1.ExecuteReader();
                    con.Close();

                    con.Open();
                    MySqlCommand cmdClave3 = new MySqlCommand("ALTER TABLE reservaHotel MODIFY fechaFin date", con);
                    cmdClave3.ExecuteReader();
                    con.Close();
                    DateTime fecha1 = DateTime.ParseExact(fechaIn, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime fecha2 = DateTime.ParseExact(fechaOut, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    int totalDias = (fecha2 - fecha1).Days;
                    precioTotal = totalDias * precioNoche;
                    con.Open();
                    MySqlCommand cmdClave2 = new MySqlCommand("insert into  reservaHotel (codigoHotel,dniCliente,precioTotal,fechaInicio,fechaFin )values ('" + idHotel + "','" + dniCliente + "','" + precioTotal + "','" + fechaIn + "','" + fechaOut + "')", con);

                    cmdClave2.ExecuteNonQuery();
                    con.Close();
                }
                return new ObjectResult("RESERVA CONFIRMADA") { StatusCode = 201 };

            }
            else
            {
                return new ObjectResult("ERROR 400: NO EXISTEN HOTELES") { StatusCode = 400 };
            }
        }
    }
}
