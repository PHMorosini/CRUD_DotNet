using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD_DotNet.Models
{
    public class Cliente
    {

        [Key]
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3, ErrorMessage =
            "O Nome do Cliente deve ter no mínimo 3 e no máximo 60 caracteres.")]
        [Required(ErrorMessage = "É necessario o nome do cliente")]
        public string Nome { get; set; }
        //-----------------------------------------------------------------------------------
        [StringLength(14, MinimumLength = 11, ErrorMessage =
            "O CPF/CNPJ deve ter no mínimo 11 e no máximo 64 caracteres.")]
        [DisplayName("CPF/CNPJ")]
        [Required(ErrorMessage = "É necessario inserir o CPF/CNPJ do cliente")]
        public string Cpf { get; set; }
        //-----------------------------------------------------------------------------------
        [StringLength(60, MinimumLength = 3, ErrorMessage =
            "O Nome do Endereco deve ter no mínimo 3 e no máximo 60 caracteres.")]
        [Required(ErrorMessage = "É necessario inserir o endereço do cliente")]
        public string Endereco { get; set; }
        //-----------------------------------------------------------------------------------
        [Required(ErrorMessage = "É necessário inserir a data de nascimento")]
        [DisplayName("Data de Nascimento")]
        public DateOnly DataNascimento { get; set; }
        //-----------------------------------------------------------------------------------
        [StringLength(60, MinimumLength = 3, ErrorMessage =
            "O Nome do Rua deve ter no mínimo 3 e no máximo 60 caracteres.")]
        [Required(ErrorMessage = "É necessario inserir a rua do cliente")]
        public string Rua { get; set; }
        //-----------------------------------------------------------------------------------
        [StringLength(60, MinimumLength = 3, ErrorMessage =
            "O Nome do Bairro deve ter no mínimo 3 e no máximo 60 caracteres.")]
        [Required(ErrorMessage = "É necessario inserir o bairro do cliente")]
        public string Bairro { get; set; }
        //-----------------------------------------------------------------------------------
        public string EstadoSigla { get; set; }
        //-----------------------------------------------------------------------------------
        [StringLength(60, MinimumLength = 3, ErrorMessage =
            "O Nome do Cidade deve ter no mínimo 3 e no máximo 60 caracteres.")]
        [Required(ErrorMessage = "É necessario inserir a cidade do cliente")]
        public string Cidade {get; set; }

        [Required] 
        public bool EhEstudante { get; set; }
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
