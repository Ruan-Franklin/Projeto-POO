using System;

class AquisiçãoItem {
  // Atributos do item de AquisiçãoItem
  private int quantidade;
  private double preço;
  // Associação entre AquisiçãoItem e Produto
  private Produto produto;
  public AquisiçãoItem(int quantidade, Produto produto) {
    this.quantidade = quantidade;
    this.preço = produto.GetPreço();
    this.produto = produto;
  }
  public void SetQuantidade(int quantidade) {
    this.quantidade = quantidade;
  }
  public void SetPreço(double preço) {
    this.preço = preço;
  }
  public void SetProduto(Produto produto) {
    this.produto = produto;
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