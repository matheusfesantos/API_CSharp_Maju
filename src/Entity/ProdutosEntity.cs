using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdutoEntity.Entity
{
    [Table("Produtos")]
    public class Produtos
    {
        [Key]//Para Definir a chave primária
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//Para gerar o ID automaticamente
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}