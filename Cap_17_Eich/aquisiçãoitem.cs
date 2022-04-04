using System;

//É necessário definir as propriedades para as informações que serão gravadas nos arquivos.
public class AquisiçãoItem {
  // Atributos do item de AquisiçãoItem
  private int quantidade;
  private double preço;
  // Associação entre AquisiçãoItem e Produto
  private Produto produto;
  //Apenas o id do produto vai persistir
  private int produtoId;

  //Propriedades do item de aquisição que serão gravadas no arquivo.
  public int Quantidade{get => quantidade; set=> quantidade = value;}
  public double Preço{get => preço; set=> preço = value;}
  public int ProdutoId{get => produtoId; set=> produtoId = value;}

  //É necessário um construtor vazio
  public AquisiçãoItem(){}



  
  
  public AquisiçãoItem(int quantidade, Produto produto) {
    this.quantidade = quantidade;
    this.preço = produto.GetPreço();
    this.produto = produto;
    //É necessário um get, porque o id não está com propriedades.
    this.produtoId=produto.GetId();
  }
  public void SetQuantidade(int quantidade) {
    this.quantidade = quantidade;
  }
  public void SetPreço(double preço) {
    this.preço = preço;
  }
  public void SetProduto(Produto produto) {
    this.produto = produto;
   this.produtoId=produto.GetId();

  }
  public int GetQuantidade() {
    return quantidade;
  }
  public double GetPreço() {
    return preço;
  }
  public Produto GetProduto() {
    return produto;
  }
  public override string ToString() {
    return produto.GetDescrição() + " - Quantidade:" + quantidade + " - Preço: " + preço.ToString("c2");
  }
}