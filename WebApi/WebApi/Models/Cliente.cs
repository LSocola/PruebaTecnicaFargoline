using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace WebApi.Models
{
    public class Cliente:TipoDocumento
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public int IdDocumento { get; set; }
        public string NroDocumento { get; set; }
        
        

    }
}
