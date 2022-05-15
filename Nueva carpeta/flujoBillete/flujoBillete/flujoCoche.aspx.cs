using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace flujoBillete
{
    public partial class flujoCoche : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void crear(object sender, EventArgs e)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri("http://localhost:8082/");
            request.Method = HttpMethod.Post;
            try { 
                var exampleJson = "{\"fechaInicio\" : \"" + fechaInicio.Text.ToString() + "\",\n  \"dni\" : \"" + dni.Text.ToString() + "\",\n  \"precioInicio\" : \"" + precioInicio.Text.ToString() + "\",\n  \"precioFin\" : \"" + precioFin.Text.ToString() + "\",\n  \"lugar\" : \"" + lugar.Text.ToString() + "\",\n  \"fechaFin\" : \"" + fechaFin.Text.ToString() + "\",\n  \"numPersonas\" : \"" + numPersonas.Text.ToString() + "\"\n}";

                var stringContent = new StringContent(JsonConvert.SerializeObject(exampleJson), Encoding.UTF8, "application/json");
                request.Content = stringContent;

                var client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();
                string cont = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                lblReserva.Text = " La reserva se ha realizado correctamente";
            }
            catch (Exception ex)
            {
                lblReserva.Text = "No se ha podido realizar la reserva";
            }
        }
    }
}