using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class comidas
    {
        [Key]
        public int id_comida { get; set; }      
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string durabilidad { get; set; }
        public int? fecha_caducidad { get; set; }
        public int? fecha_compra {  get; set; }
        public string estado { get; set; }
        public int? dias_duracion { get; set; }
    }
}
