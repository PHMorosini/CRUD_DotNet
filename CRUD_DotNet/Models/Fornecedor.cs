namespace CRUD_DotNet.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Endereco { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }

        public Fornecedor() { }

        public Fornecedor(int id, string name, string endereco, string rua, string bairro)
        {
            Id = id;
            Name = name;
            Endereco = endereco;
            Rua = rua;
            Bairro = bairro;
        }
    }
}
