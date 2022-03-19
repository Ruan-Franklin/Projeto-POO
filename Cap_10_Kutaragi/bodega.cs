using System;
using System.Collections.Generic;

class Bodega {
  // Atributos da Bodega de itens
  private int id;
  private DateTime data;
  private bool carrinho;
  // Associação entre venda na "bodega" e cliente
  private Cliente cliente;
  // Associação entre bodega e itens de venda
  private List<BodegaItem> itens = new List<BodegaItem>();

  public Bodega(DateTime data, Cliente cliente) {
    this.data = data;
    this.carrinho = true;
    this.cliente = cliente;
  }
  
  public void SetId(int id) {
    this.id = id;
  }
  public void SetData(DateTime data) {
    this.data = data;
  }
  public void SetCarrinho(bool carrinho) {
    this.carrinho = carrinho;
  }
  public void SetCliente(Cliente cliente) {
    this.cliente = cliente;
  }
  public int GetId() {
    return id;
  }
  public DateTime GetData() {
    return data;
  }
  public bool GetCarrinho() {
    return carrinho;
  }
  public Cliente GetCliente() {
    return cliente;
  }
  public override string ToString() {
    if (carrinho) 
      return "Compra: " + id + " - " + data.ToString("dd/MM/yyyy") + " - Cliente: " + cliente.Nome + " - carrinho";
    else
      return "Compra: " + id + " - " + data.ToString("dd/MM/yyyy") + " - Cliente: " + cliente.Nome;
  }

  private BodegaItem ItemListar(Produto p) {
    // Verificar se o produto p já está na lista de itens
    foreach(BodegaItem vi in itens) 
      if (vi.GetProduto() == p) return vi;
    return null;  
  }

  public List<BodegaItem> ItemListar() {
    // Retornar a lista de itens
    return itens;
  }

  public void ItemInserir(int quantidade, Produto p) {
    // Verificar se o produto p já está na lista de itens
    BodegaItem item = ItemListar(p);
    if (item == null) {
      item = new BodegaItem(quantidade, p);
      itens.Add(item);
    }
    else
      item.SetQuantidade(item.GetQuantidade() + quantidade);
  }

  public void ItemExcluir() {
    // Remove todos os itens da lista 
    itens.Clear();
  }
}