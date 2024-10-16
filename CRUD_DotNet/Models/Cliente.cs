using System.ComponentModel.DataAnnotations;

namespace CRUD_DotNet.Models
{
    public class Cliente
    {

        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
        public Cliente(string nome, string endereco, string rua, string bairro)
        {

            Nome = nome;
            Endereco = endereco;
            Rua = rua;
            Bairro = bairro;
        }
        public Cliente()
        {
        }
    }
}
