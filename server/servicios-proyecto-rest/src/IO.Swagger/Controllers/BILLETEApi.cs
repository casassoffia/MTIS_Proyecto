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
    public class BILLETEApiController : ControllerBase
    {
        public List<Billete> billetes = new List<Billete>();
        /// <summary>
        /// Obtiene el billete con mejor puntuación
        /// </summary>
        /// <param name="billetes">pasar lista de billetes</param>
        /// <response code="200">Billete con mejor puntuación</response>
        /// <response code="400">No hay ningún billete</response>
        [HttpPost]
        [Route("/aditwitter20212022/proyecto/1.0.0/billetes")]
        [ValidateModelState]
        [SwaggerOperation("BilletesPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(Billete), description: "Billete con mejor puntuación")]
        public virtual IActionResult BilletesGet([FromBody][Required()] List<Billete> listaBilletes)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Billete));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);
            Billete mejorBillete = new Billete();
            mejorBillete.Precio = 0;
            string disp = "";
            string exampleJson = "";
            for (int i = 0; i < listaBilletes.Count; i++)
            {
                if (listaBilletes[i].Precio >= mejorBillete.Precio)
                {
                    mejorBillete = listaBilletes[i];
                }
            }
            if (mejorBillete.Disponibilidad.Value)
            {
                disp = "true";
            }
            else
            {
                disp = "false";
            }
            exampleJson += " {\n  \"precio\" : " + mejorBillete.Precio.ToString() + ",\n  \"disponibilidad\" : " + disp + ",\n  \"numeroPersonas\" : " + mejorBillete.NumeroPersonas.ToString() + ",\n  \"lugar\" : " + mejorBillete.Lugar + ",\n  \"name\" : \"" + mejorBillete.Name + "\",\n  \"name\" : \"" + mejorBillete.NumeroPersonas + "\",\n  \"description\" : \"" + mejorBillete.Description.ToString() + "\",\n  \"id\" : " + mejorBillete.Id.ToString() + " \n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Hotel>(exampleJson)
            : default(Hotel);            //TODO: Change the data returned
            return new ObjectResult(example);
            string exampleJson = null;
            exampleJson = "{\n  \"precio\" : 129.96,\n  \"numeroPersonas\" : 2,\n  \"disponibilidad\" : true,\n  \"lugar\" : \"Mallorca\",\n  \"name\" : \"Vueling\",\n  \"description\" : \"Billete a Mallorca\",\n  \"id\" : 1\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<Billete>(exampleJson)
                        : default(Billete);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Comprobar billetes disponibles
        /// </summary>
        /// <param name="listaBilletes">Lista de billetes que cumplen las características anteriores</param>
        /// <response code="200">Billetes con las características</response>
        /// <response code="400">ERROR 400: No hay billetes con esas características</response>
        [HttpPost]
        [Route("/aditwitter20212022/proyecto/1.0.0/comprobarDisponibilidadBillete")]
        [ValidateModelState]
        [SwaggerOperation("ComprobarDisponibilidadBilletePost")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Billete>), description: "Billetes con las características")]
        public virtual IActionResult ComprobarDisponibilidadBilletePost([FromBody][Required()]List<Billete> listaBilletes)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Billete>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);
            List<Billete> filtradoBilletes = new List<Billete>();

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=localhost;user id=root;database=companiarea;Password=root";
            con.Open();
            for (int i = 0; i < listaBilletes.Count; i++)
            {
                if (listaBilletes[i].Disponibilidad.Value)
                {
                    filtradoBilletes.Add(listaBilletes[i]);
                }
            }
            billetes = filtradoBilletes;

            string exampleJson = "[";
            string disp = "";
            for (int i = 0; i < filtradoBilletes.Count; i++)
            {
                if (filtradoBilletes[i].Disponibilidad.Value)
                {
                    disp = "true";
                }
                else
                {
                    disp = "false";
                }
                exampleJson += " {\n  \"precio\" : " + filtradoBilletes[i].Precio.ToString() + ",\n  \"disponibilidad\" : " + disp + ",\n  \"numeroPersonas\" : " + filtradoBilletes[i].NumeroPersonas.ToString() + ",\n  \"lugar\" : " + filtradoBilletes[i].Lugar + ",\n  \"name\" : \"" + filtradoBilletes[i].Name + "\",\n  \"name\" : \"" + filtradoBilletes[i].NumeroPersonas + "\",\n  \"description\" : \"" + filtradoBilletes[i].Description.ToString() + "\",\n  \"id\" : " + filtradoBilletes[i].Id.ToString() + " \n}";
                if (i != (filtradoBilletes.Count - 1))
                {
                    exampleJson += ", ";
                }
            }
            exampleJson += " ]";
            var example = exampleJson != null
                ? JsonConvert.DeserializeObject<List<Billete>>(exampleJson)
                : default(List<Billete>);
            con.Close();
            if (exampleJson == null)
            {
                return new ObjectResult("ERROR 400: NO EXISTEN BILLETES") { StatusCode = 400 };
            }

            return new ObjectResult(exampleJson) { StatusCode = 200 };
            
        }

        /// <summary>
        /// Comprobar billetes para esas caracterísiticas
        /// </summary>
        /// <param name="fechaIn">Check-in con formato YYYY-MM-DD</param>
        /// <param name="fechaOut">Check-out con formato YYYY-MM-DD</param>
        /// <param name="lugarIn">pasar lugar origen de la estancia</param>
        /// <param name="lugarOut">pasar lugar destino de la estancia</param>
        /// <response code="200">Billetes con las características</response>
        /// <response code="400">ERROR 400: No hay billetes con esas características</response>
        [HttpPost]
        [Route("/aditwitter20212022/proyecto/1.0.0/comprobarFechaLugarBillete/{fechaIn}/{fechaOut}/{lugarIn}/{lugarOut}")]
        [ValidateModelState]
        [SwaggerOperation("ComprobarFechaLugarBilleteFechaInFechaOutLugarInLugarOutPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Billete>), description: "Billetes con las características")]
        public virtual IActionResult ComprobarFechaLugarBilleteFechaInFechaOutLugarInLugarOutPost([FromRoute][Required]string fechaIn, [FromRoute][Required]string fechaOut, [FromRoute][Required]string lugarIn, [FromRoute][Required]string lugarOut)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Billete>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);
            string exampleJson = null;
            exampleJson = "[ {\n  \"precio\" : 129.96,\n  \"numeroPersonas\" : 2,\n  \"disponibilidad\" : true,\n  \"lugar\" : \"Mallorca\",\n  \"name\" : \"Vueling\",\n  \"description\" : \"Billete a Mallorca\",\n  \"id\" : 1\n}, {\n  \"precio\" : 129.96,\n  \"numeroPersonas\" : 2,\n  \"disponibilidad\" : true,\n  \"lugar\" : \"Mallorca\",\n  \"name\" : \"Vueling\",\n  \"description\" : \"Billete a Mallorca\",\n  \"id\" : 1\n} ]";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<List<Billete>>(exampleJson)
                        : default(List<Billete>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Comprobar billetes para esas caracterísiticas
        /// </summary>
        /// <param name="n">Número de personas</param>
        /// <param name="listaBilletes">Lista de bileltes que cumplen las características anteriores</param>
        /// <response code="200">Billetes con las características</response>
        /// <response code="400">ERROR 400: No hay billetes con esas características</response>
        [HttpPost]
        [Route("/aditwitter20212022/proyecto/1.0.0/comprobarPersonasBillete/{n}")]
        [ValidateModelState]
        [SwaggerOperation("ComprobarPersonasBilleteNPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Billete>), description: "Billetes con las características")]
        public virtual IActionResult ComprobarPersonasBilleteNPost([FromRoute][Required]int? n, [FromBody][Required()]List<Billete> listaBilletes)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Billete>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);
            List<Billete> filtradoBilletes = new List<Billete>();

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=localhost;user id=root;database=companiarea;Password=root";
            con.Open();
            for (int i = 0; i < listaBilletes.Count; i++)
            {
                if (listaBilletes[i].NumeroPersonas == n)
                {
                    filtradoBilletes.Add(listaBilletes[i]);
                }
            }
            billetes = filtradoBilletes;

            string exampleJson = "[";
            string disp = "";
            for (int i = 0; i < filtradoBilletes.Count; i++)
            {
                if (filtradoBilletes[i].Disponibilidad.Value)
                {
                    disp = "true";
                }
                else
                {
                    disp = "false";
                }
                exampleJson += " {\n  \"precio\" : " + filtradoBilletes[i].Precio.ToString() + ",\n  \"disponibilidad\" : " + disp + ",\n  \"numeroPersonas\" : " + filtradoBilletes[i].NumeroPersonas.ToString() + ",\n  \"lugar\" : " + filtradoBilletes[i].Lugar + ",\n  \"name\" : \"" + filtradoBilletes[i].Name + "\",\n  \"name\" : \"" + filtradoBilletes[i].NumeroPersonas + "\",\n  \"description\" : \"" + filtradoBilletes[i].Description.ToString() + "\",\n  \"id\" : " + filtradoBilletes[i].Id.ToString() + " \n}";
                if (i != (filtradoBilletes.Count - 1))
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
        /// Comprobar billetes para esas caracterísiticas
        /// </summary>
        /// <param name="precioInicio">Rango inicial del precio</param>
        /// <param name="precioFin">Rango final del precio</param>
        /// <param name="listaBilletes">Lista de billetes que cumplen las características anteriores</param>
        /// <response code="200">Billetes con las características</response>
        /// <response code="400">ERROR 400: No hay billetes con esas características</response>
        [HttpPost]
        [Route("/aditwitter20212022/proyecto/1.0.0/comprobarPreciosBillete/{precioInicio}/{precioFin}")]
        [ValidateModelState]
        [SwaggerOperation("ComprobarPreciosBilletePrecioInicioPrecioFinPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Billete>), description: "Billetes con las características")]
        public virtual IActionResult ComprobarPreciosBilletePrecioInicioPrecioFinPost([FromRoute][Required]decimal? precioInicio, [FromRoute][Required]decimal? precioFin, [FromBody][Required()]List<Billete> listaBilletes)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Billete>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);
            List<Billete> filtradoBilletes = new List<Billete>();

            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=localhost;user id=root;database=companiarea;Password=root";
            con.Open();
            for (int i = 0; i < listaBilletes.Count; i++)
            {
                if (listaBilletes[i].Precio <= precioFin && listaBilletes[i].Precio >= precioInicio)
                {
                    filtradoBilletes.Add(listaBilletes[i]);
                }
            }
            billetes = filtradoBilletes;

            string exampleJson = "[";
            string disp = "";
            for (int i = 0; i < filtradoBilletes.Count; i++)
            {
                if (filtradoBilletes[i].Disponibilidad.Value)
                {
                    disp = "true";
                }
                else
                {
                    disp = "false";
                }
                exampleJson += " {\n  \"precio\" : " + filtradoBilletes[i].Precio.ToString() + ",\n  \"disponibilidad\" : " + disp + ",\n  \"numeroPersonas\" : " + filtradoBilletes[i].NumeroPersonas.ToString() + ",\n  \"lugar\" : " + filtradoBilletes[i].Lugar + ",\n  \"name\" : \"" + filtradoBilletes[i].Name + "\",\n  \"name\" : \"" + filtradoBilletes[i].NumeroPersonas + "\",\n  \"description\" : \"" + filtradoBilletes[i].Description.ToString() + "\",\n  \"id\" : " + filtradoBilletes[i].Id.ToString() + " \n}";
                if (i != (filtradoBilletes.Count - 1))
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
        /// 
        /// </summary>
        /// <remarks>Eliminar reserva</remarks>
        /// <param name="id">pasar id de la reserva a borrar</param>
        /// <response code="204">Reserva borrada</response>
        /// <response code="404">No se ha encontrado la reserva</response>
        [HttpDelete]
        [Route("/aditwitter20212022/proyecto/1.0.0/reserva/billetes/borrar/{id}")]
        [ValidateModelState]
        [SwaggerOperation("ReservaBilletesBorrarIdDelete")]
        [SwaggerResponse(statusCode: 404, type: typeof(InlineResponse404), description: "No se ha encontrado la reserva")]
        public virtual IActionResult ReservaBilletesBorrarIdDelete([FromRoute][Required]int? id)
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
        /// <param name="id">pasar id de la reserva del billete</param>
        /// <response code="200">Reserva del billete se devuelve</response>
        /// <response code="400">No existe la reserva del billete</response>
        [HttpGet]
        [Route("/aditwitter20212022/proyecto/1.0.0/reserva/billetes/consultar/{id}")]
        [ValidateModelState]
        [SwaggerOperation("ReservaBilletesConsultarIdGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(ReservaBillete), description: "Reserva del billete se devuelve")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse4001), description: "No existe la reserva del billete")]
        public virtual IActionResult ReservaBilletesConsultarIdGet([FromRoute][Required]int? id)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(ReservaBillete));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(InlineResponse4001));
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=localhost;user id=root;database=companiarea;Password=root";
            con.Open();
            string exampleJson = null;
            if (id != null)
            {
                MySqlCommand cmdClave = new MySqlCommand("select * from reservaBillete where idReserva=@id", con);
                cmdClave.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = cmdClave.ExecuteReader();

                if (reader.Read())
                {
                    int idReserva = reader.GetInt32("idReserva");
                    string dni = reader.GetString("dniCliente");
                    int idBillete = reader.GetInt32("codigoBillete");
                    double precioTotal = reader.GetDouble("precioTotal");
                    string fechaInicio = reader.GetString("fechaInicio");
                    string fechaFin = reader.GetString("fechaFin");
                    con.Close();

                    exampleJson = "{\n  \"fechaInicio\" : \"" + fechaInicio + "\",\n  \"dniCliente\" : \"" + dni + "\",\n  \"precioTotal\" : " + precioTotal.ToString() + ",\n  \"codigoBillete\" : \"" + idBillete.ToString() + "\",\n  \"fechaFin\" : \"" + fechaFin + "\",\n  \"idReserva\" : " + id.ToString() + "\n}";
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
        /// <remarks>Decrementar precio de la reserva del billete</remarks>
        /// <param name="id">pasar id de la reserva</param>
        /// <param name="body">Reserva del billete</param>
        /// <response code="201">Billete modificado</response>
        /// <response code="404">Billete no encontrado</response>
        [HttpPut]
        [Route("/aditwitter20212022/proyecto/1.0.0/reserva/billetes/modificar/{id}")]
        [ValidateModelState]
        [SwaggerOperation("ReservaBilletesModificarIdPut")]
        public virtual IActionResult ReservaBilletesModificarIdPut([FromRoute][Required]int? id, [FromBody]ReservaBillete body)
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
        /// <remarks>Crear una reserva del billete</remarks>
        /// <param name="idBillete">pasar el id del mejor billete</param>
        /// <param name="body">Reserva de Billete</param>
        /// <response code="201">Reserva del billete creada</response>
        /// <response code="400">No existe ese billete</response>
        /// <response code="409">Esa reserva ya existe</response>
        [HttpPost]
        [Route("/aditwitter20212022/proyecto/1.0.0/reserva/billetes/nuevo")]
        [ValidateModelState]
        [SwaggerOperation("ReservaBilletesNuevoPost")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "No existe ese billete")]
        [SwaggerResponse(statusCode: 409, type: typeof(InlineResponse409), description: "Esa reserva ya existe")]
        public virtual IActionResult ReservaBilletesNuevoPost([FromQuery][Required()]int? idBillete, [FromQuery][Required()] string dniCliente, [FromQuery][Required()] string fechaIn, [FromQuery][Required()] string fechaOut)
        {
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(InlineResponse400));

            //TODO: Uncomment the next line to return response 409 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(409, default(InlineResponse409));
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=localhost;user id=root;database=companiarea;Password=root";
            con.Open();
            if (idBillete != null)
            {
                MySqlCommand cmdClave = new MySqlCommand("select * from billete where id=@idBillete", con);
                cmdClave.Parameters.AddWithValue("@idBillete", idBillete);
                MySqlDataReader reader = cmdClave.ExecuteReader();


                if (reader.Read())
                {
                    double precio = reader.GetDouble("precio");
                    double precioTotal = 0;
                    con.Close();
                    con.Open();
                    MySqlCommand cmdClave1 = new MySqlCommand("ALTER TABLE reservaBillete MODIFY fechaInicio date", con);
                    cmdClave1.ExecuteReader();
                    con.Close();

                    con.Open();
                    MySqlCommand cmdClave3 = new MySqlCommand("ALTER TABLE reservaBillete MODIFY fechaFin date", con);
                    cmdClave3.ExecuteReader();
                    con.Close();
                    DateTime fecha1 = DateTime.ParseExact(fechaIn, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime fecha2 = DateTime.ParseExact(fechaOut, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    int totalDias = (fecha2 - fecha1).Days;
                    precioTotal = totalDias * precio;
                    con.Open();
                    MySqlCommand cmdClave2 = new MySqlCommand("insert into  reservaBillete (codigoBillete,dniCliente,precioTotal,fechaInicio,fechaFin )values ('" + idBillete + "','" + dniCliente + "','" + precioTotal + "','" + fechaIn + "','" + fechaOut + "')", con);

                    cmdClave2.ExecuteNonQuery();
                    con.Close();
                }
                return new ObjectResult("RESERVA CONFIRMADA") { StatusCode = 201 };

            }
            else
            {
                return new ObjectResult("ERROR 400: NO EXISTEN BILLETES") { StatusCode = 400 };
            }

            throw new NotImplementedException();
        }
    }
}
