using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using System.Linq;



class NCategoria {
  //Construtor Singleton.
  private NCategoria(){ }
  //Instanciando a categoria
  static NCategoria obj= new NCategoria();
  //Método público que testa se tem um objeto da classe instanciado. Retorna a instância da classe instanciada. Tem uma propriedade chamada de Singleton.
  public static NCategoria Singleton{get =>obj;}
  

  private Categoria[] categorias = new Categoria[10];
  private int nc;
  


  public Categoria[] Listar() {
   // Categoria[] c = new Categoria[nc];
   // Array.Copy(categorias, c, nc);
    //Orderby ordena em crescente ou decrescente
    //Esse método terá uma função que indique qual é o atributo ou propriedade utilizado para fazer essa ordenação.
  //  c.OrderBy(obj => obj.GetDescrição());
    //return c;
    //O Linq tem um método que permite a recuperação de parte dos elementos de uma recuperação, o método Take.
    //O take precisa recuperar de "nc", que representa o contador da quantidade de elementos que temos na coleção de categorias.
    //É necessário usar um OrderBy junto com um ToArray para ordenar no formato de vetor.
    //Com apenas essa instrução é possível substituir as outras operações
    return 
    categorias.Take(nc).OrderBy(obj => obj.GetDescrição()).ToArray();
    
    
    

  }

 public Categoria Listar(int id) {
   //RECUPERAÇÃO DO ID PERCORRENDO A CATEGORIA
  //  for (int i = 0; i < nc; i++)
      //if (categorias[i].GetId() == id) return categorias[i];
    //return null;  

   //RECUPERAÇÃO DO ID UTILIZANDO WHERE


   
   
    //Sempre que estivermos percorrendo alguma coleção, possivelmente conseguimos resolver utilizando alguma instrução do Linq.
    //O método where filtra elementos de uma coleção.
    //É necessário passar uma função que verifique se o objeto que está sendo passado para o método where (No caso uma categoria) tem o id que está sendo procurado.
    //Isso vai retornar uma coleção de objetos da classe categoria que tenham esse ID. No caso do ID só pode ter 1 ou nenhum elemento.
  //  var r = categorias.Where(obj => obj.GetId() == id);
   // if(r.Count() == 0){
     // return null;
   // }
    //O método first retorna um primeiro elemento de uma coleção;
 //   return r.First();

   //RECUPERAÇÃO DO ID UTILIZANDO FirstOrDefault
   
   //Uma maneira mais simples ainda é o usando o método FirstOrDefault
   return categorias.FirstOrDefault(obj => obj.GetId() == id);
    
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
    //Um objeto da classe arquivo recebe um parâmetro de tipo.
   Arquivo<Categoria[]> f = new Arquivo<Categoria[]>();
    categorias = f.Abrir("./categorias.xml");
   nc = categorias.Length;
  //  XmlSerializer xml = new XmlSerializer(typeof(Categoria[]));
  //  StreamReader f = new StreamReader("./categorias.xml", Encoding.Default);
   // categorias = (Categoria[]) xml.Deserialize(f);
   // f.Close();
   // nc = categorias.Length;
  }

  public void Salvar() {
    Arquivo<Categoria[]> f = new Arquivo<Categoria[]>();
    f.Salvar("./categorias.xml", Listar());
    //XmlSerializer xml = new XmlSerializer(typeof(Categoria[]));
   // StreamWriter f = new StreamWriter("./categorias.xml", false, Encoding.Default);
    //xml.Serialize(f, Listar());
   // f.Close();
  }

  

}