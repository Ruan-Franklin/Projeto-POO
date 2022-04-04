using System;
using System.Collections.Generic;

//Para a classe de aquisição ser serializada, ela precisa ser pública.
public class Aquisição {
  // Atributos da Aquisição de itens
  private int id;
  private DateTime data;
  private bool carrinho;
  // Associação entre venda na aquisição e cliente
  private Cliente cliente;
  //Nesse caso, vamos gravar só o id do cliente.
  private int clienteId;
  // Associação entre aquisição e itens de venda
  private List<AquisiçãoItem> itens = new List<AquisiçãoItem>();

  //Propriedades da aquisição
  //Esses serão os dados gravados quando gerarmos um arquivo XML da parte de venda.

  public int Id{get => id; set => id=value;}
  public DateTime Data{get => data; set => data=value;}
  public bool Carrinho{get => carrinho; set => carrinho=value;}
  public int ClienteId{get => clienteId; set => clienteId=value;}
  public List<AquisiçãoItem> Itens{get => itens; set => itens=value;}
//A gente precisa ter um construtor sem parâmetro, para que a serialização funcione.
  public Aquisição(){}



  public Aquisição(DateTime data, Cliente cliente) {
    this.data = data;
    this.carrinho = true;
    this.cliente = cliente;
    this.clienteId=cliente.Id;
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
    this.clienteId=cliente.Id;
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

  private AquisiçãoItem ItemListar(Produto p) {
    // Verificar se o produto p já está na lista de itens
    foreach(AquisiçãoItem vi in itens) 
      if (vi.GetProduto() == p) return vi;
    return null;  
  }

  public List<AquisiçãoItem> ItemListar() {
    // Retornar a lista de itens
    return itens;
  }

  public void ItemInserir(int quantidade, Produto p) {
    // Verificar se o produto p já está na lista de itens
    AquisiçãoItem item = ItemListar(p);
    if (item == null) {
      item = new AquisiçãoItem(quantidade, p);
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