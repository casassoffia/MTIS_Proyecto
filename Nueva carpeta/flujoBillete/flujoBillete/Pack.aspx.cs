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
    public partial class Pack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void crear(object sender, EventArgs e)
        {

            var requestCoche = new HttpRequestMessage();
            requestCoche.RequestUri = new Uri("http://localhost:8082/");
            requestCoche.Method = HttpMethod.Post;

            var requestBillete = new HttpRequestMessage();
            requestBillete.RequestUri = new Uri("http://localhost:8083/");
            requestBillete.Method = HttpMethod.Post;

            var requestHotel = new HttpRequestMessage();
            requestHotel.RequestUri = new Uri("http://localhost:8081/");
            requestHotel.Method = HttpMethod.Post;
            try
            {
                var exampleJson = "{\"fechaInicio\" : \"" + fechaInicio.Text.ToString() + "\",\n  \"dni\" : \"" + dni.Text.ToString() + "\",\n  \"precioInicio\" : \"" + precioInicio.Text.ToString() + "\",\n  \"precioFin\" : \"" + precioFin.Text.ToString() + "\",\n  \"lugar\" : \"" + lugar.Text.ToString() + "\",\n  \"fechaFin\" : \"" + fechaFin.Text.ToString() + "\",\n  \"numPersonas\" : \"" + numPersonas.Text.ToString() + "\"\n}";

                var stringContent = new StringContent(JsonConvert.SerializeObject(exampleJson), Encoding.UTF8, "application/json");
                requestCoche.Content = stringContent;
                var stringContent1 = new StringContent(JsonConvert.SerializeObject(exampleJson), Encoding.UTF8, "application/json");
                requestBillete.Content = stringContent1;
                var stringContent2 = new StringContent(JsonConvert.SerializeObject(exampleJson), Encoding.UTF8, "application/json");
                requestHotel.Content = stringContent2;

                //var client = new HttpClient();
                using (var client = new HttpClient())
                {
                    HttpResponseMessage responsecoche = await client.SendAsync(requestCoche).ConfigureAwait(false);
                    responsecoche.EnsureSuccessStatusCode();
                    await responsecoche.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
                

                
                using (var client1 = new HttpClient())
                {
                    HttpResponseMessage responseBillete = await client1.SendAsync(requestBillete).ConfigureAwait(false);
                    responseBillete.EnsureSuccessStatusCode();
                    await responseBillete.Content.ReadAsStringAsync().ConfigureAwait(false);
                }
                //var client1 = new HttpClient();


                using (var client2 = new HttpClient())
                {
                    HttpResponseMessage responseHotel = await client2.SendAsync(requestHotel).ConfigureAwait(false);
                    responseHotel.EnsureSuccessStatusCode();
                    await responseHotel.Content.ReadAsStringAsync().ConfigureAwait(false);
                }




                lblReserva.Text = " La reserva se ha realizado correctamente";
            }
            catch (Exception ex)
            {
                lblReserva.Text = "No se ha podido realizar la reserva";
            }
        }
    }
}
