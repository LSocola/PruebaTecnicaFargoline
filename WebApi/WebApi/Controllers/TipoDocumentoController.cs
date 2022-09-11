using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApi.DataAccess;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        [HttpGet]
        [Route("Listar")]
        public List<TipoDocumento> ListarTipoDoc()
        {
            return TipoDocDA.ListarTipoDoc();
        }
    }
}
