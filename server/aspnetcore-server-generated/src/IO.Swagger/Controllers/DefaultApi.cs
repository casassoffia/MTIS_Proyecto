/*
 * Hotel
 *
 * API del HOTEL
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

namespace IO.Swagger.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DefaultApiController : ControllerBase
    { 
        /// <summary>
        /// Obtiene el listado de todos los hoteles
        /// </summary>
        /// <response code="200">Muestra el listado de todos los hoteles</response>
        /// <response code="400">No hay ningún hotel</response>
        [HttpGet]
        [Route("/aditwitter20212022/Hotel/1.0.0/hoteles")]
        [ValidateModelState]
        [SwaggerOperation("HotelesGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Hotel>), description: "Muestra el listado de todos los hoteles")]
        public virtual IActionResult HotelesGet()
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Hotel>));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);
            string exampleJson = null;
            exampleJson = "[ {\n  \"numeroPersonas\" : 2,\n  \"disponibilidad\" : true,\n  \"puntuacion\" : 7,\n  \"precioNoche\" : 123.96,\n  \"lugar\" : \"Alicante\",\n  \"name\" : \"Melia\",\n  \"description\" : \"Hotel con vistas al mar\",\n  \"id\" : 1\n}, {\n  \"numeroPersonas\" : 2,\n  \"disponibilidad\" : true,\n  \"puntuacion\" : 7,\n  \"precioNoche\" : 123.96,\n  \"lugar\" : \"Alicante\",\n  \"name\" : \"Melia\",\n  \"description\" : \"Hotel con vistas al mar\",\n  \"id\" : 1\n} ]";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<List<Hotel>>(exampleJson)
                        : default(List<Hotel>);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Obtiene el mejor hotel, el cual, presenta la mejor puntuación
        /// </summary>
        /// <param name="id">pasar id del hotel</param>
        /// <response code="200">Mejor puntuación de hotel</response>
        /// <response code="400">No existe hotel</response>
        [HttpGet]
        [Route("/aditwitter20212022/Hotel/1.0.0/mejorHotel/{id}")]
        [ValidateModelState]
        [SwaggerOperation("MejorHotelIdGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(Hotel), description: "Mejor puntuación de hotel")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "No existe hotel")]
        public virtual IActionResult MejorHotelIdGet([FromRoute][Required]int? id)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Hotel));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400, default(InlineResponse400));
            string exampleJson = null;
            exampleJson = "{\n  \"numeroPersonas\" : 2,\n  \"disponibilidad\" : true,\n  \"puntuacion\" : 7,\n  \"precioNoche\" : 123.96,\n  \"lugar\" : \"Alicante\",\n  \"name\" : \"Melia\",\n  \"description\" : \"Hotel con vistas al mar\",\n  \"id\" : 1\n}";
            
                        var example = exampleJson != null
                        ? JsonConvert.DeserializeObject<Hotel>(exampleJson)
                        : default(Hotel);            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
