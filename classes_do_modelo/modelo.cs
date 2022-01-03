using System;

class MainClass {
  public static void Main() {
    Categoria c1 = new Categoria(1, "Jogos de Playstation 5");
    Categoria c2 = new Categoria(2, "Jogos de Xbox Séries X");
    Console.WriteLine(c1);
    Console.WriteLine(c2);

    Produto p1 = new Produto(1, "Resident Evil Village, PS5", 7, 125);
    Produto p2 = new Produto(2, "Spider-Man: Miles Morales, PS5", 40, 120);
    Produto p3 = new Produto(3, "Fifa 21, Xbox Séries X", 20, 100);
    Produto p4 = new Produto(4, "Battlefield 2042, Xbox Séries X", 20, 140);    

    Console.WriteLine(p1);
    Console.WriteLine(p2);
    Console.WriteLine(p3);
    Console.WriteLine(p4);
  }
}

class Categoria {
  private int id;
  private string descrição;
  public Categoria(int id, string descrição) {
    this.id = id;
    this.descrição = descrição;
  }
  public void SetId(int id) {
    this.id = id;
  }
  public void SetDescrição(string descrição) {
    this.descrição = descrição;
  }
  public int GetId() {
    return id;
  }
  public string GetDescrição() {
    return descrição;
  }
  public override string ToString() {
    return id + " - " + descrição;
  }
}

class Produto {
  private int id;
  private string descrição;
  private int quantidade;
  private double preço;
  public Produto(int id, string descrição, int quantidade, double preço) {
    this.id = id;
    this.descrição = descrição;
    this.quantidade = quantidade > 0 ? quantidade : 0;
    this.preço = preço > 0 ? preço : 0;
  }
  public void SetId(int id) {
    this.id = id;
  }
  public void SetDescrição(string descrição) {
    this.descrição = descrição;
  }
  public void SetQuantidade(int qtd) {
    this.quantidade = quantidade > 0 ? quantidade : 0;
  }
  public void SetPreço(double preço) {
    this.preço = preço > 0 ? preço : 0;
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
  public override string ToString() {
    return id + " - " + descrição + " - estoque: " + quantidade + " - preço: R$ " + preço.ToString("0.00");
  }
}
