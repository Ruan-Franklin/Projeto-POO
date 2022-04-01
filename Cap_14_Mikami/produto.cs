using System;
//A classe produto precisa ser pública, para que a serialização da classe Categoria funcione.
public class Produto {
  //Atributos do produto
  private int id;
  private string descrição;
  private int quantidade;
  private double preço;
  private int categoriaId;

  //Associação entre categoria e produto
  private Categoria categoria;
  
  //Propriedades do produto
  public int Id { get => id; set => id = value; }
  public string Descrição { get => descrição; set => descrição = value; }
  public int Quantidade { get => quantidade; set => quantidade = value; }
  public double Preço { get => preço; set => preço = value; }
  public int CategoriaId { get => categoriaId; set => categoriaId = value; }
  //Construtor que não recebe parâmetros
  public Produto() { }

  //Construtores
  public Produto(int id, string descrição, int quantidade, double preço) {
    this.id = id;
    this.descrição = descrição;
    this.quantidade = quantidade > 0 ? quantidade : 0;
    this.preço = preço > 0 ? preço : 0;
  }
  public Produto(int id, string descrição, int quantidade, double preço, Categoria categoria) : this(id, descrição, quantidade, preço) {
    this.categoria = categoria;
    this.categoriaId = categoria.GetId();

  }
  //Métodos de acesso
  public void SetId(int id) {
    this.id = id;
  }
  public void SetDescrição(string descrição) {
    this.descrição = descrição;
  }
  public void SetQuantidade(int quantidade) {
    this.quantidade = quantidade > 0 ? quantidade : 0;
  }
  public void SetPreço(double preço) {
    this.preço = preço > 0 ? preço : 0;
  }
  public void SetCategoria(Categoria categoria) {
    this.categoria = categoria;
    this.categoriaId = categoria.GetId();

  }
  public int GetId() {
    return id;
  }
  public string GetDescrição() {
    return descrição;
  }
  public int GetQuantidade() {
    return quantidade;
  }
  public double GetPreço() {
    return preço;
  }
  public Categoria GetCategoria() {
    return categoria;
  }
  public override string ToString() {
    if (categoria == null)
      return id + " - " + descrição + " - estoque: " + quantidade + " - preço: R$ " + preço.ToString("0.00");
    else  
      return id + " - " + descrição + " - estoque: " + quantidade + " - preço: R$ " + preço.ToString("0.00") + " - " + categoria.GetDescrição(); }
}