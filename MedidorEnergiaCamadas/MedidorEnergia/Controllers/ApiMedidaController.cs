using MedidorEnergia.BLL;
using MedidorEnergia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/medida")]
    public class DefaultController : ApiController
    {

        [HttpGet]
        [Route("{irms}/{potencia}")]
        public HttpResponseMessage ObterMedidasArduino(float irms, float potencia)
        {
            MedidaDTO medidaDTO = new MedidaDTO(irms, potencia);
            try
            {
                if (ModelState.IsValid)
                {
                    MedidaBLL medidaBLL = new MedidaBLL();
                    medidaBLL.Inserir(medidaDTO);
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, medidaDTO);
                    // response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = medida.IDMedida }));
                    return response;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
