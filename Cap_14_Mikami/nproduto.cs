using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;


class NProduto {
   //Construtor Singleton.
  private NProduto(){ }
  //Instanciando a categoria
  static NProduto obj =new NProduto();
  //Método público que testa se tem um objeto da classe instanciado. Retorna a instância da classe instanciada. Tem uma propriedade chamada de Singleton.
  public static NProduto Singleton{get =>obj;}
  
  private Produto[] produtos = new Produto[10];
  private int np;

  public void Abrir() {
  //  Arquivo<Produto[]> f = new Arquivo<Produto[]>();
    //produtos = f.Abrir("./produtos.xml");
   // np = produtos.Length;
   // AtualizarCategoria();

    XmlSerializer xml = new XmlSerializer(typeof(Produto[]));
    StreamReader f = new StreamReader("./produtos.xml", Encoding.Default);
    produtos = (Produto[]) xml.Deserialize(f);
    f.Close();
    np = produtos.Length;
    AtualizarCategoria();
  }
  //É necessário atribuir novamente a categoria dos produtos.
  //Operação privada de atualizar categoria:
  private void AtualizarCategoria(){
    //AtualizarCategoria() percorre o vetor de produtos para atualizar a categoria de produtos.
    for(int i=0 ; i<np ; i++){
      //Cada produto no vetor
      Produto p = produtos[i];
     //Recuperar a categoria do produto
      Categoria c = NCategoria.Singleton.Listar(p.CategoriaId);
    //Associação entre produto e categoria
      if(c!=null){
        p.SetCategoria(c);
        c.ProdutoInserir(p);
      
    }
    }
  }
  public void Salvar() {
  //  Arquivo<Produto[]> f = new Arquivo<Produto[]>();
    //f.Salvar("./produtos.xml", Listar());

    XmlSerializer xml = new XmlSerializer(typeof(Produto[]));
    StreamWriter f = new StreamWriter("./produtos.xml", false, Encoding.Default);
    xml.Serialize(f, Listar());
    f.Close();
  }

  public Produto[] Listar() {
    Produto[] p = new Produto[np];
    Array.Copy(produtos, p, np);
    return p;
  }

  public Produto Listar(int id) {
    for (int i = 0; i < np; i++)
      if (produtos[i].GetId() == id) return produtos[i];
    return null;  
  }

  public void Inserir(Produto p) {
    if (np == produtos.Length) {
      Array.Resize(ref produtos, 2 * produtos.Length);
    }
    produtos[np] = p;
    np++;
    // Resgatar a categoria do produto que está no processo de Inserção.
    Categoria c = p.GetCategoria();
    if (c != null) c.ProdutoInserir(p);
  } 

public void Atualizar(Produto p) {
    // Encontra no vetor o produto que possui o id informado no parametro (p)
    // Se não encontrar o produto com o Id, retorna sem alterá-lo.
    Produto p_atual = Listar(p.GetId());
    if (p_atual == null) return;
    // Alterar os dados do produto
    p_atual.SetDescrição(p.GetDescrição());
    p_atual.SetQuantidade(p.GetQuantidade());
    p_atual.SetPreço(p.GetPreço());
    // Exclui o produto de sua categoria atual
    if (p_atual.GetCategoria() != null) 
      p_atual.GetCategoria().ProdutoExcluir(p_atual);
    // Atualiza a categoria do produto
    p_atual.SetCategoria(p.GetCategoria());
    // Insere o produto na nova categoria
    if (p_atual.GetCategoria() != null)
      p_atual.GetCategoria().ProdutoInserir(p_atual);
  }


  private int Indice(Produto p) {
    // Retorna o índice do produto no vetor
    for(int i = 0; i < np; i++)
      if (produtos[i] == p) return i;
    return -1;  
  }
  
  public void Excluir(Produto p) {
    // Verifica se o produto está cadastrado
    int n = Indice(p);
    // Se não encontrar o produto, retorna sem alterar
    if (n == -1) return;
    // Desloca os produtos no vetor para substituir o índice do produto excluído
    // Remove o produto do vetor
    for (int i = n; i < np - 1; i++)
      produtos[i] = produtos[i + 1];
    // Decrementa o contador de produtos
    np--;
    // Remove o produto de sua categoria
    Categoria c = p.GetCategoria();
    if (c != null) c.ProdutoExcluir(p);  
  }




}