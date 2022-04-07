using System;
//Para fazer a serialização na classe de sócio, ela deve ser pública.
public class Socio : IComparable<Socio> {
  // Propriedade do Sócio
  public int Id { get; set; }
  public string Nome { get; set; }
  public DateTime Nascimento { get; set; }
  public int CompareTo(Socio obj) {
    return this.Nome.CompareTo(obj.Nome);
  }
  public override string ToString() {
    return Id + " - " + Nome + " - " + "Fundada em: " + Nascimento.ToString("dd/MM/yyyy");
  }
}