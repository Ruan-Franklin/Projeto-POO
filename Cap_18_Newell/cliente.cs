using System;

//Para fazer a serialização da classe cliente, ela precisa ser pública.
public class Cliente : IComparable<Cliente> {
  // Propriedade do Cliente
  public int Id { get; set; }
  public string Nome { get; set; }
  public DateTime Nascimento { get; set; }
  public int CompareTo(Cliente obj) {
    return this.Nome.CompareTo(obj.Nome);
  }
  public override string ToString() {
    return Id + " - " + Nome + " - " + "Nascido em: " + Nascimento.ToString("dd/MM/yyyy");
  }
}