using System;

class Categoria {
  private int id;
  private string descrição;
  private Produto[] produtos = new Produto[10];
  private int np;
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
  public Produto[] ProdutoListar() {
    Produto[] c = new Produto[np];
    Array.Copy(produtos, c, np);
    return c;
  }
  public void ProdutoInserir(Produto p) {
    if (np == produtos.Length) {
      Array.Resize(ref produtos, 2 * produtos.Length);
    }
    produtos[np] = p;
    np++;
  }
  public override string ToString() {
    return id + " - " + descrição + " - Nº produtos: " + np;
  }
}