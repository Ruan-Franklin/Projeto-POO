using System;
using System.Collections.Generic;

class NAquisição {
 //Construtor Singleton.
  private NAquisição(){ }
  //Instanciando a categoria
  static NAquisição obj= new NAquisição();
  //Método público que testa se tem um objeto da classe instanciado. Retorna a instância da classe instanciada. Tem uma propriedade chamada de Singleton.
  public static NAquisição Singleton{get =>obj;}
  
  private List<Aquisição> aquisições = new List<Aquisição>();

  public List<Aquisição> Listar() {
    // Retorna uma lista com as potenciais aquisições cadastradas
    return aquisições;
  }

  public List<Aquisição> Listar(Cliente c) {
    // Retorna uma lista com as potenciais aquisições cadastradas do cliente c
    List<Aquisição> vs = new List<Aquisição>();
    foreach(Aquisição a in aquisições)
      if (a.GetCliente() == c) vs.Add(a);
    return vs;
  }

  public Aquisição ListarCarrinho(Cliente c) {
    // Retorna uma lista com as potenciais aquisições cadastradas do cliente c
    foreach(Aquisição a in aquisições)
      if (a.GetCliente() == c && a.GetCarrinho()) return a;
    return null;
  }

  public void Inserir(Aquisição a, bool carrinho) {
    // Gera o código id das Aquisições
    int max = 0;
    foreach (Aquisição obj in aquisições)
      if (obj.GetId() > max) max = obj.GetId();
    a.SetId(max + 1);
    // Inserir a nova na lista de potenciais aquisições
    aquisições.Add(a);
    // Define o atributo carrinho
    a.SetCarrinho(carrinho);
  }

  public List<AquisiçãoItem> ItemListar(Aquisição a) {
    // Retorna os  potenciais objetos de aquisições 
    return a.ItemListar();
  }

  public void ItemInserir(Aquisição a, int quantidade, Produto p) {
    // Inserir um objeto nas potenciais aquisições
    a.ItemInserir(quantidade, p);
  }  

  public void ItemExcluir(Aquisição a) {
    // Remover todos os itens da provável aquisição de um produto
    a.ItemExcluir();
  }

  public void Abrir() {
    //Um objeto da classe arquivo recebe um parâmetro de tipo.
   Arquivo<List<Aquisição>> f = new Arquivo<List<Aquisição>>();
    aquisições = f.Abrir("./aquisições.xml");
  }

  public void Salvar() {
    Arquivo<List<Aquisição>> f = new Arquivo<List<Aquisição>>();
    f.Salvar("./aquisições.xml", Listar());
  }
  
}