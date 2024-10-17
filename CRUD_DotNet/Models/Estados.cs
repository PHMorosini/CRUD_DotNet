using System.ComponentModel.DataAnnotations;

namespace CRUD_DotNet.Models
{
    public class Estado
    {
        [Key]
        public int Id { get; set; }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public ICollection<Evento> Eventos { get; set; }
    }
}
