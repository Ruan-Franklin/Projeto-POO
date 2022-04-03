using System;
using System.Collections.Generic;

class NSocio {
  //Singleton da classe de negócio de sócio
  private NSocio() { }
  static NSocio obj = new NSocio();
  public static NSocio Singleton { get => obj; }

  //Tipo genérico de sócio
  
  private List<Socio> socios = new List<Socio>();

  public List<Socio> Listar() {
    // Retorna uma listas com os sócios cadastrados
    socios.Sort();
    return socios;
  }

   public void Abrir() {
    Arquivo<List<Socio>> f = new Arquivo<List<Socio>>();
    socios = f.Abrir("./socios.xml");
  }

  public void Salvar() {
    Arquivo<List<Socio>> f = new Arquivo<List<Socio>>();
    f.Salvar("./socios.xml", Listar());
  }

  public Socio Listar(int id) {
    // Localiza na lista o sócio com o id informado
    for (int i = 0; i < socios.Count; i++)
      if (socios[i].Id == id) return socios[i];
    return null;  
  }

  public void Inserir(Socio c) {
    // Gera o id do sócio
    int max = 0;
    foreach(Socio obj in socios)
      if (obj.Id > max) max = obj.Id;
    c.Id = max + 1;      
    // Insere a empresa sócio na lista
    socios.Add(c);
  } 

  public void Atualizar(Socio c) {
    // Localiza na lista o sócio que possui o id informado no parâmetro c
    Socio c_atual = Listar(c.Id);
    // Se não encontrar o sócio com o Id, retorna sem alterar
    if (c_atual == null) return;
    // Altera os dados do Sócio
    c_atual.Nome = c.Nome;
    c_atual.Nascimento = c.Nascimento;
  } 

  public void Excluir(Socio c) {
    // Remove o Sócio da lista
    if (c != null) socios.Remove(c);
  } 
}