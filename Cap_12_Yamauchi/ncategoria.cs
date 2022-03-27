using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;



class NCategoria {
  private Categoria[] categorias = new Categoria[10];
  private int nc;
  


  public Categoria[] Listar() {
    Categoria[] c = new Categoria[nc];
    Array.Copy(categorias, c, nc);
    return c;
  }

  public Categoria Listar(int id) {
    for (int i = 0; i < nc; i++)
      if (categorias[i].GetId() == id) return categorias[i];
    return null;  
  }

  public void Inserir(Categoria c) {
    if (nc == categorias.Length) {
      Array.Resize(ref categorias, 2 * categorias.Length);
    }
    categorias[nc] = c;
    nc++;
  }
  public void Atualizar(Categoria c) {
    // Localizar no vetor a categoria que possui o id informado no parametro categoria
    Categoria c_atual = Listar(c.GetId());
    if (c_atual == null) return;
    // Alterar os dados da minha categoria
    c_atual.SetDescrição(c.GetDescrição());
  } 

  private int Indice(Categoria c) {
    for (int i = 0; i < nc; i++)
      if (categorias[i] == c) return i;
    return -1;      
  }

  public void Excluir(Categoria c) {
    // Verifica se a categoria foi  cadastrada por algum vendedor.
    int n = Indice(c);
    if (n == -1) return;
    for (int i = n; i < nc - 1; i++)
      categorias[i] = categorias[i + 1];
    nc--;
    // Recupera a lista de produtos da categoria
    Produto[] ps = c.ProdutoListar();
    foreach(Produto p in ps) p.SetCategoria(null); 
  }

  public void Abrir() {
   // Arquivo<Categoria[]> f = new Arquivo<Categoria[]>();
    //categorias = f.Abrir("./categorias.xml");
//    nc = categorias.Length;
    XmlSerializer xml = new XmlSerializer(typeof(Categoria[]));
    StreamReader f = new StreamReader("./categorias.xml", Encoding.Default);
    categorias = (Categoria[]) xml.Deserialize(f);
    f.Close();
    nc = categorias.Length;
  }

  public void Salvar() {
    //Arquivo<Categoria[]> f = new Arquivo<Categoria[]>();
    //f.Salvar("./categorias.xml", Listar());
    XmlSerializer xml = new XmlSerializer(typeof(Categoria[]));
    StreamWriter f = new StreamWriter("./categorias.xml", false, Encoding.Default);
    xml.Serialize(f, Listar());
    f.Close();
  }

  
 

}