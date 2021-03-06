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
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace IO.Swagger.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class ReservaBillete : IEquatable<ReservaBillete>
    { 
        /// <summary>
        /// Gets or Sets IdReserva
        /// </summary>
        [Required]

        [DataMember(Name="idReserva")]
        public int? IdReserva { get; set; }

        /// <summary>
        /// Gets or Sets CodigoBillete
        /// </summary>
        [Required]

        [DataMember(Name="codigoBillete")]
        public string CodigoBillete { get; set; }

        /// <summary>
        /// Gets or Sets DniCliente
        /// </summary>
        [Required]

        [DataMember(Name="dniCliente")]
        public string DniCliente { get; set; }

        /// <summary>
        /// Gets or Sets PrecioTotal
        /// </summary>
        [Required]

        [DataMember(Name="precioTotal")]
        public decimal? PrecioTotal { get; set; }

        /// <summary>
        /// Gets or Sets FechaInicio
        /// </summary>
        [Required]

        [DataMember(Name="fechaInicio")]
        public string FechaInicio { get; set; }

        /// <summary>
        /// Gets or Sets FechaFin
        /// </summary>
        [Required]

        [DataMember(Name="fechaFin")]
        public string FechaFin { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ReservaBillete {\n");
            sb.Append("  IdReserva: ").Append(IdReserva).Append("\n");
            sb.Append("  CodigoBillete: ").Append(CodigoBillete).Append("\n");
            sb.Append("  DniCliente: ").Append(DniCliente).Append("\n");
            sb.Append("  PrecioTotal: ").Append(PrecioTotal).Append("\n");
            sb.Append("  FechaInicio: ").Append(FechaInicio).Append("\n");
            sb.Append("  FechaFin: ").Append(FechaFin).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((ReservaBillete)obj);
        }

        /// <summary>
        /// Returns true if ReservaBillete instances are equal
        /// </summary>
        /// <param name="other">Instance of ReservaBillete to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ReservaBillete other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    IdReserva == other.IdReserva ||
                    IdReserva != null &&
                    IdReserva.Equals(other.IdReserva)
                ) && 
                (
                    CodigoBillete == other.CodigoBillete ||
                    CodigoBillete != null &&
                    CodigoBillete.Equals(other.CodigoBillete)
                ) && 
                (
                    DniCliente == other.DniCliente ||
                    DniCliente != null &&
                    DniCliente.Equals(other.DniCliente)
                ) && 
                (
                    PrecioTotal == other.PrecioTotal ||
                    PrecioTotal != null &&
                    PrecioTotal.Equals(other.PrecioTotal)
                ) && 
                (
                    FechaInicio == other.FechaInicio ||
                    FechaInicio != null &&
                    FechaInicio.Equals(other.FechaInicio)
                ) && 
                (
                    FechaFin == other.FechaFin ||
                    FechaFin != null &&
                    FechaFin.Equals(other.FechaFin)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (IdReserva != null)
                    hashCode = hashCode * 59 + IdReserva.GetHashCode();
                    if (CodigoBillete != null)
                    hashCode = hashCode * 59 + CodigoBillete.GetHashCode();
                    if (DniCliente != null)
                    hashCode = hashCode * 59 + DniCliente.GetHashCode();
                    if (PrecioTotal != null)
                    hashCode = hashCode * 59 + PrecioTotal.GetHashCode();
                    if (FechaInicio != null)
                    hashCode = hashCode * 59 + FechaInicio.GetHashCode();
                    if (FechaFin != null)
                    hashCode = hashCode * 59 + FechaFin.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(ReservaBillete left, ReservaBillete right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ReservaBillete left, ReservaBillete right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
