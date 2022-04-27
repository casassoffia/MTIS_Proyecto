/*
 * COMPROBAR HOTEL
 *
 * API para COMPROBAR HOTEL
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
    public class DefaultApiController : ControllerBase
    { 
        public List<Hotel> hoteles = new List<Hotel>();
        /// <summary>
        /// Comprobar hoteles disponibles
        /// </summary>
        /// <param name="listaHoteles">Lista de hoteles que cumplen las características anteriores</param>
        /// <response code="200">Hoteles con las características</response>
        /// <response code="400">ERROR 400: No hay hoteles con esas características</response>
        [HttpPost]
        [Route("/futratioiw/ComprobarHotel/1.0.0/comprobarDisponibilidad")]
        [ValidateModelState]
        [SwaggerOperation("ComprobarDisponibilidadPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Hotel>), description: "Hoteles con las características")]
        public virtual IActionResult ComprobarDisponibilidadPost([FromBody][Required()]List<Hotel> listaHoteles)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Hotel>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);
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
        /// <param name="fechaIn">Check-in con formato DD-MM-YYYY</param>
        /// <param name="fechaOut">Check-out con formato DD-MM-YYYY</param>
        /// <param name="lugar">pasar lugar de la estancia</param>
        /// <response code="200">Hoteles con las características</response>
        /// <response code="400">ERROR 400: No hay hoteles con esas características</response>
        [HttpPost]
        [Route("/futratioiw/ComprobarHotel/1.0.0/comprobarFechaLugar/{fechaIn}/{fechaOut}/{lugar}")]
        [ValidateModelState]
        [SwaggerOperation("ComprobarFechaLugarFechaInFechaOutLugarPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Hotel>), description: "Hoteles con las características")]
        public virtual IActionResult ComprobarFechaLugarFechaInFechaOutLugarPost([FromRoute][Required]string fechaIn, [FromRoute][Required]string fechaOut, [FromRoute][Required]string lugar)
        {
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=localhost;user id=root;database=companiarea;Password=root";

            // INTRODUCIR FECHAS EN FORMATO 2022-04-28

            // Cambiamos fecha de string a date
        
            
            
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

            con.Open();
            MySqlCommand cmdClave = new MySqlCommand("select codigoHotel from reservaHotel where fechaInicio <= @fecha1 OR fechaFin >= @fecha2", con);
            cmdClave.Parameters.AddWithValue("@fecha1", fecha1);
            cmdClave.Parameters.AddWithValue("@fecha2", fecha2);
            MySqlDataReader reader = cmdClave.ExecuteReader();

            int codigoH= 0;
            List<int> codigosHoteles = new List<int>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    codigoH = reader.GetInt32("codigoHotel");
                    codigosHoteles.Add(codigoH);
                }

                con.Close();
            } else 
            {
                return new ObjectResult("ERROR 400: NO EXISTEN HOTELES") { StatusCode = 400 };
            }

            string exampleJson = "[";
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
                int idH = 0, numP = 0, punt = 0;
                string name = "", description = "", lug = "";
                double precioNoche = 0.0;
                string disp = "";


                while (reader2.Read())
                {
                    idH = reader2.GetInt32("id");
                    name = reader2.GetString("name");
                    description = reader2.GetString("description");
                    precioNoche = reader2.GetDouble("precioNoche");
                    numP = reader2.GetInt32("numeroPersonas");
                    punt = reader2.GetInt32("puntuacion");
                    if (reader2.GetBoolean("disponibilidad"))
                    {
                        disp = "true";
                    }
                    else
                    {
                        disp = "false";
                    }
                     
                    lug = reader2.GetString("lugar");

                    exampleJson += " {\n  \"numeroPersonas\" : " + numP.ToString() + ",\n  \"disponibilidad\" : " + disp + ",\n  \"puntuacion\" : " + punt.ToString() + ",\n  \"precioNoche\" : " + precioNoche.ToString() + ",\n  \"lugar\" : \"" + lug + "\",\n  \"name\" : \"" + name + "\",\n  \"description\" : \"" + description + "\",\n  \"id\" : " + idH.ToString() + " \n}";
                    if (!(contador).ToString().Equals(readerContar.ToString()))
                    {
                        exampleJson += ", ";
                    }
                    contador++;

                    
                }

                exampleJson += " ]";
                var example = exampleJson != null
                    ? JsonConvert.DeserializeObject<List<Hotel>>(exampleJson)
                    : default(List<Hotel>);
                con.Close();
            }

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
        [Route("/futratioiw/ComprobarHotel/1.0.0/comprobarPersonas/{n}")]
        [ValidateModelState]
        [SwaggerOperation("ComprobarPersonasNPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Hotel>), description: "Hoteles con las características")]
        public virtual IActionResult ComprobarPersonasNPost([FromRoute][Required]int? n, [FromBody][Required()]List<Hotel> listaHoteles)
        {
            List<Hotel> filtradoHoteles = new List<Hotel>();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=localhost;user id=root;database=companiarea;Password=root";
            con.Open();
            for(int i=0; i < listaHoteles.Count; i++)
            {
                if (listaHoteles[i].NumeroPersonas == n)
                {
                    filtradoHoteles.Add(listaHoteles[i]);
                }
            }
            hoteles = filtradoHoteles;
            
            string exampleJson = "[";
            string disp = "";
            for (int i=0; i < filtradoHoteles.Count; i++)
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
                if(i!=(filtradoHoteles.Count - 1))
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
        [Route("/futratioiw/ComprobarHotel/1.0.0/comprobarPrecios/{precioInicio}/{precioFin}")]
        [ValidateModelState]
        [SwaggerOperation("ComprobarPreciosPrecioInicioPrecioFinPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Hotel>), description: "Hoteles con las características")]
        public virtual IActionResult ComprobarPreciosPrecioInicioPrecioFinPost([FromRoute][Required]decimal? precioInicio, [FromRoute][Required]decimal? precioFin, [FromBody][Required()]List<Hotel> listaHoteles)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Hotel>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);
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
    }
}
