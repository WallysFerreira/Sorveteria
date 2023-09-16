namespace Produtos.Models;

public class Produto {
    public string Categoria { get; set; }
    public string Nome { get; set; }
    public float Preco { get; set; }
    public string Descricao { get; set; }
    public string Foto { get; set; }

    public Produto(string categoria, string nome, float preco, string descricao, string foto) {
        this.Categoria = categoria;
        this.Nome = nome;
        this.Preco = preco;
        this.Descricao = descricao;
        this.Foto = foto;
    }
}