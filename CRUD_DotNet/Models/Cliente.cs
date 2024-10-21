using System.ComponentModel.DataAnnotations;

namespace CRUD_DotNet.Models
{
    public class Cliente
    {

        [Key]
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3, ErrorMessage =
            "O Nome do Cliente deve ter no mínimo 3 e no máximo 60 caracteres.")]
        public string Nome { get; set; }
        [StringLength(60, MinimumLength = 3, ErrorMessage =
            "O Nome do Endereco deve ter no mínimo 3 e no máximo 60 caracteres.")]
        public string Endereco { get; set; }
        [StringLength(60, MinimumLength = 3, ErrorMessage =
            "O Nome do Rua deve ter no mínimo 3 e no máximo 60 caracteres.")]
        public string Rua { get; set; }
        [StringLength(60, MinimumLength = 3, ErrorMessage =
            "O Nome do Bairro deve ter no mínimo 3 e no máximo 60 caracteres.")]
        public string Bairro { get; set; }
        public string EstadoSigla { get; set; }
        [StringLength(60, MinimumLength = 3, ErrorMessage =
            "O Nome do Cidade deve ter no mínimo 3 e no máximo 60 caracteres.")]
        public string Cidade {get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
        public Cliente(string nome, string endereco, string rua, string bairro, string cidade)
        {

            Nome = nome;
            Endereco = endereco;
            Rua = rua;
            Bairro = bairro;
            Cidade = cidade;
        }
        public Cliente()
        {
            Ativo = true;
        }
    }
}
