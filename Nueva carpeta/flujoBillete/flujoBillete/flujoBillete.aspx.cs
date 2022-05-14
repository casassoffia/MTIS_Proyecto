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
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void crear(object sender, EventArgs e)
        {
            var req = new HttpRequestMessage();
            req.RequestUri = new Uri("http://localhost:8083/");
            req.Method = HttpMethod.Post;

            var exampleJson = "{\"fechaInicio\" : \"" + fechaInicio.Text.ToString() + "\",\n  \"dni\" : \"" + dni.Text.ToString() + "\",\n  \"precioInicio\" : \"" + precioInicio.Text.ToString()+"\",\n  \"precioFin\" : \""+precioFin.Text.ToString() + "\",\n  \"lugar\" : \"" + lugar.Text.ToString() + "\",\n  \"fechaFin\" : \"" + fechaFin.Text.ToString()+ "\",\n  \"numPersonas\" : \"" + numPersonas.Text.ToString()  + "\"\n}";
            var stringContent = new StringContent(JsonConvert.SerializeObject(exampleJson), Encoding.UTF8, "application/json");
            req.Content = stringContent;

            var cl = new HttpClient();
            HttpResponseMessage rr = await cl.SendAsync(req).ConfigureAwait(false);
            rr.EnsureSuccessStatusCode();
            string cont = await rr.Content.ReadAsStringAsync().ConfigureAwait(false);
            
            
        }
    }
}