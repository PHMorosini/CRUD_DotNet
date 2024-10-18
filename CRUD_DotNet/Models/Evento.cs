using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD_DotNet.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(60,MinimumLength = 3, ErrorMessage =
            "O Nome do Evento deve ter no mínimo 3 e no máximo 60 caracteres.")]
        public string Nome { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string EstadoSigla { get; set; }
        [DisplayName("Valor do ingresso")]
        //[DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal ValorIngresso { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

        //Isso aqui é pra sempre que criar o evento vir como true o campo Ativo,tentei fazer pelo entityconfig mas não foi.
        public Evento()
        {
            Ativo = true;
        }



    }
}
