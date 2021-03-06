/*
 * VALIDAR CLIENTE
 *
 * API para VALIDAR CLIENTE
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
        /// <summary>
        /// Validamos datos del cliente
        /// </summary>
        /// <param name="dni">pasamos DNI del cliente</param>
        /// <response code="200">Cliente ha sido validado</response>
        /// <response code="400">ERROR 400: No existe el cliente</response>
        [HttpGet]
        [Route("/futratioiw/VALIDAR/1.0.0/validarDatosCliente/{dni}")]
        [ValidateModelState]
        [SwaggerOperation("ValidarDatosClienteDniGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Cliente>), description: "Cliente ha sido validado")]
        public virtual IActionResult ValidarDatosClienteDniGet([FromRoute][Required]string dni)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Cliente>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = "server=localhost;user id=root;database=companiarea;Password=root";
            con.Open();

            // Miramos clave
            MySqlCommand cmdClave = new MySqlCommand("select * from cliente where dni=@dni", con);
            cmdClave.Parameters.AddWithValue("@dni", dni);

            MySqlDataReader reader = cmdClave.ExecuteReader(); ;

            if (reader.HasRows)
            {
                
                    
                string dni_db = "";
                string name = "";
                string lastname = "";
                string email = "";
                string exampleJson = "";
                    if (reader.Read())
                    {
                        dni_db = reader.GetString("dni");
                        name = reader.GetString("name");
                        lastname = reader.GetString("lastname");
                        email = reader.GetString("email");


                        exampleJson = "[ {\n  \"name\" : \""+name+"\",\n  \"dni\" : \""+dni_db+"\",\n  \"email\" : \""+email+"\",\n  \"lastname\" : \""+lastname+"\"\n}]";

                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<List<Cliente>>(exampleJson)
                        : default(List<Cliente>);            //TODO: Change the data returned

                    con.Close();
                        return new ObjectResult(example) { StatusCode = 200 };

                    }

                    //con.Close();

                    return new ObjectResult(exampleJson) { StatusCode = 200 };
                
            }
            else
            {
                return new ObjectResult("ERROR 400: NO EXISTE DNI") { StatusCode = 400 };
            }
                      
           
        }
    }
}
