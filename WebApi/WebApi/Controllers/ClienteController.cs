
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebApi.DataAccess;
using WebApi.Models;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("Obtener/{codigo}")]
        public Cliente ObtenerCliente(int codigo)
        {
            return ClienteDA.ObtenerCliente(codigo);
        }
        [HttpGet]
        [Route("Listar")]
        public List<Cliente> ListarClientes()
        {
            return ClienteDA.GetClientes();
        }
        [HttpPost]
        [Route("Registrar")]
        public String RegistrarCliente([FromBody] Cliente cliente)
        {
            return ClienteDA.RegistrarCliente(cliente);
        }
        [HttpPut]
        [Route("Actualizar")]
        public String ActualizarCliente([FromBody] Cliente cliente)
        {
            return ClienteDA.ActualizarCliente(cliente);
        }
        [HttpDelete]
        [Route("Eliminar/{codigo}")]
        public String EliminarCliente(int codigo)
        {
            return ClienteDA.EliminarCliente(codigo);
        }
    }
}
