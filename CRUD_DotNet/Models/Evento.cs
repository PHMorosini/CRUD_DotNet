﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD_DotNet.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Endereco { get; set; }
        [Required]
        public string Bairro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public int EventoId { get; set; } // Chave primária do Evento
        public string EstadoSigla { get; set; } // Coluna para armazenar a sigla do Estado
        [DisplayName("Valor do ingresso")]
        public decimal ValorIngresso { get; set; }
        public bool Ativo { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
        public Estado Estado { get; set; }
    }
}