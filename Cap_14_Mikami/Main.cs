using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
class MainClass {
   private static NCategoria ncategoria = new NCategoria();
   private static NProduto nproduto = new NProduto();
   private static NSocio nsocio = new NSocio();
   private static NCliente ncliente = new NCliente();
  private static NAquisição naquisição = new NAquisição();
   private static Cliente clienteLogin = null;
   private static Aquisição clienteAquisição = null;

   



   public static void Main() {
     Thread.CurrentThread.CurrentCulture = new CultureInfo("PT-BR");
     try{
       ncategoria.Abrir();
     
     }
     catch(Exception erro){
       Console.WriteLine(erro.Message);
       
       
     }
     int opção = 0;
     Console.WriteLine ("------GitGames — site  de vendas de games ------");
     Console.WriteLine("Usuário, seja bem-vindo(a)");
     do{
       try{
         opção=Menu();
         switch(opção) {
           case 1 : ClienteLogin(); break;
           case 2 : PagVendedor(); break;
           case 3 : PagSocio(); break;
            }
             }
       catch (Exception erro) {
         Console.WriteLine(erro.Message);
         opção=100; }
     } while(opção!=0);
     try{
       ncategoria.Salvar();
     }
     catch(Exception erro){
       Console.WriteLine(erro.Message);
       
     }
     Console.WriteLine ("Acesso finalizado, obrigado!....."); }
   public static int Menu() {
     Console.WriteLine();
     Console.WriteLine("----------------------------------");
     Console.WriteLine("Digite uma das opções abaixo para fazer login ou encerrar o acesso.");

     Console.WriteLine("1 - Cliente - Acessar área de clientes");
     Console.WriteLine("2 - Vendedor - Acessar área de vendedores");
     Console.WriteLine("3 - Sócios - Acessar área de empresas sócias");
     Console.WriteLine("0 - Fim");
     Console.Write("Informe uma opção: ");
     int opção = int.Parse(Console.ReadLine());
     Console.WriteLine();
     return opção;                                                        }
   public static void PagCliente() {
     int seleção=0;
     Console.WriteLine("----- Menu do cliente  -----");
     Console.WriteLine("----- Digite uma das opções para continuar  -----");

       do{
         try{
           seleção=Usuario();
           switch(seleção) {
             case 1: CategoriaListar(); break;
             case 2: ProdutoListar(); break;
             case 3: ClienteDesconectar(); break;
             case 4: ClienteInserirnoCarrinho(); break;
             case 5: ClienteCarrinhoVisualizar(); break;
             case 6: ClienteCarrinhoAdquirir(); break;
             case 7: ClienteVendaListar(); break;
             case 8: ClienteCarrinhoEsvaziar(); break;
             
            
     }
     }
         catch (Exception erro) {
           Console.WriteLine(erro.Message);
           seleção=100; }
     }   while(seleção!=9);
       Console.WriteLine ("Você voltou para o menu principal!....."); }
       
 
   public static void PagVendedor() {
     int decisão=0;
     Console.WriteLine("----- Menu do vendedor  -----");
     Console.WriteLine("----- Digite uma das opções para continuar  -----");

       do{
         try{
           decisão=MenuVendedor();
           switch(decisão) {
             case 1: CategoriaListar(); break;
             case 2: ProdutoListar (); break;
             case 3: CategoriaInserir(); break;
             case 4: ProdutoInserir(); break;
             case 5: CategoriaAtualizar(); break;
             case 6: CategoriaExcluir(); break;
             case 7: ProdutoAtualizar(); break;
             case 8: ProdutoExcluir(); break;
             case 9: ClienteInserir(); break;
             case 10: ClienteListar(); break;
             
     }
     }
         catch (Exception erro) {
           Console.WriteLine(erro.Message);
           decisão=100; }
     }   while(decisão!=0);
       Console.WriteLine ("Você voltou para o MENU PRINCIPAL! ..."); }
  public static void ProdutoListar() {
     Console.WriteLine("----- Lista de jogos disponíveis -----");
     Produto[] pt = nproduto.Listar();
     if(pt.Length==0){
       Console.WriteLine("Nenhum produto foi cadastrado por nossos vendedores, confira nossos exclusivos.");
       Console.WriteLine("----- Exclusivos GitGames -----");
       Console.WriteLine("Daylight, PC - 20 unidades, R$ 40,00");
       return;}
     foreach(Produto p in pt){
       Console.WriteLine(p);
       Console.WriteLine();
     }
     }
 
   public static void ProdutoInserir() { // pag do vendedor  
     Console.WriteLine("----- Inserção de produtos -----");
     Console.Write("Informe um código para o produto: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome do jogo: ");
    string descrição = Console.ReadLine();
    Console.Write("Informe o estoque do produto: ");
    int quantidade= int.Parse(Console.ReadLine());
    Console.Write("Informe o preço do produto em R$:  ");
    double preço= int.Parse(Console.ReadLine());
    Console.Write("Informe o código da categoria do produto: ");
    int idcategoria=int.Parse(Console.ReadLine());
    //Seleciona o id da categoria
    Categoria c= ncategoria.Listar(idcategoria);
    //instanciando a classe do produto
    Produto p = new Produto(id, descrição,quantidade,preço,c);
    //Inserindo o produto no sistema
    nproduto.Inserir(p);  }

    public static int Usuario() {
     Console.WriteLine();
     Console.WriteLine("----------------------------------");
     Console.WriteLine("Digite uma das opções para continuar.");

     Console.WriteLine("1 - Ver categorias de produtos disponíveis.");
     Console.WriteLine("2 - Ver produtos disponíveis");
     Console.WriteLine("3- Desconectar");
     Console.WriteLine("4-Adicionar produto ao carrinho de compras");
      Console.WriteLine("5- Consultar carrinho de compras");
      Console.WriteLine("6- Confirma a compra de um produto");
      Console.WriteLine("7- Compras registradas");
      Console.WriteLine("8- Esvaziar o seu carrinho de compras ");

     Console.WriteLine("9 - Voltar para o menu principal");
     Console.Write("Informe uma opção: ");
     int escolha = int.Parse(Console.ReadLine());
     Console.WriteLine();
     return escolha;
  }
  public static void CategoriaListar() {
    Categoria[] ct = ncategoria.Listar();
     if(ct.Length==0){
       Console.WriteLine("Não há nenhuma categoria cadastrada pelos vendedores.");
       Console.WriteLine("Nesse caso, dê uma olhada em nossos jogos de computador.");
       return;}
     
     else{     
      foreach(Categoria c in ct){
       Console.WriteLine(c);
       Console.WriteLine(); }
  }
  }
  


 public static void CategoriaInserir() {
    Console.WriteLine("----- Inserção de Categorias -----");
    Console.Write("Informe um código para a categoria: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome da categoria: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe de Categoria
    Categoria c = new Categoria(id, descricao);
    // Inserção da categoria
    ncategoria.Inserir(c);
  }
  public static void CategoriaAtualizar() {
    Console.WriteLine("----- Atualização de Categorias -----");
    CategoriaListar();
       Categoria[] ct = ncategoria.Listar();
     if(ct.Length==0){
       Console.WriteLine();
       return;}
     else{
       Console.Write("Informe um código de categoria para alterá-la: ");
       int id = int.Parse(Console.ReadLine());
       Console.Write("Informe um novo nome para a categoria: ");
       string descrição = Console.ReadLine();
       // Instanciar a classe de Categoria
       Categoria c = new Categoria(id, descrição);
       // Inserção da categoria
       ncategoria.Atualizar(c);}
  }
  public static void CategoriaExcluir() {
    Console.WriteLine("----- Exclusão de Categorias -----");
    CategoriaListar();
    Categoria[] ct = ncategoria.Listar();
     if(ct.Length==0){
       Console.Write("Informe um código de  categoria para exclui-la: ");}
    else{
      int id = int.Parse(Console.ReadLine());
       // Procurar a categoria com esse id
      Categoria c = ncategoria.Listar(id);
    // Exclui a categoria do cadastro
      ncategoria.Excluir(c);
  }
  }

public static int MenuVendedor() {
     Console.WriteLine();
     Console.WriteLine("----------------------------------");
     Console.WriteLine("Digite uma das opções para continuar.");
     Console.WriteLine("1- Ver as categorias disponibilizadas para os clientes");
     Console.WriteLine("2- Ver os produtos disponibilizados para os clientes.");
     Console.WriteLine("3- Inserir categoria de produtos.");
     Console.WriteLine("4- Inserir produto");
     Console.WriteLine("5- Categoria atualizar");
     Console.WriteLine("6- Categoria excluir");
     Console.WriteLine("7- Produto atualizar");
     Console.WriteLine("8- Produto excluir");
     Console.WriteLine("9- Adicionar uma nova pessoa á lista de clientes.");
     Console.WriteLine("10- Ver lista de  clientes");

     Console.WriteLine("0 - Voltar para  o menu principal");
     Console.Write("Informe uma opção: ");
     int preferência = int.Parse(Console.ReadLine());
     Console.WriteLine();
     return preferência;
}
public static void ProdutoAtualizar() {
  Console.WriteLine("----- Atualização de Produtos -----");
    ProdutoListar();
    Produto[] pt = nproduto.Listar();
    if(pt.Length==0){
      Console.WriteLine();
       return;}
    else{   
      Console.Write("Informe o código do produto a ser atualizado: ");
      int id = int.Parse(Console.ReadLine());
      Console.Write("Informe um novo nome para o produto: ");
      string descrição = Console.ReadLine();
      Console.Write("Informe o estoque do produto: ");
      int quantidade = int.Parse(Console.ReadLine());
      Console.Write("Informe o preço do produto: ");
      double preço = double.Parse(Console.ReadLine());
      CategoriaListar();
      Console.Write("Informe o código da categoria do produto: ");
      int idcategoria = int.Parse(Console.ReadLine());
      // Seleciona a categoria a partir do id
      Categoria c = ncategoria.Listar(idcategoria);    
      // Instancia a classe de Produto
      Produto p = new Produto(id, descrição, quantidade, preço, c);
      // Atualiza o produto
      nproduto.Atualizar(p);}
  }
  public static void ProdutoExcluir() {
    Console.WriteLine("----- Exclusão de Produtos -----");
    ProdutoListar();
    Console.Write("Informe o código do produto a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    // Procura o produto com esse id
    Produto p = nproduto.Listar(id);
    // Exclui o produto
    nproduto.Excluir(p);
  }
  public static void SocioListar() {
    Console.WriteLine("----- Lista de sócios empresariais -----");
    // Lista os sócios
    List<Socio> cs = nsocio.Listar();
    if (cs.Count == 0) {
      Console.WriteLine("Nenhuma empresa cadastrada como sócia.");
      return;
    }
    foreach(Socio c in cs) Console.WriteLine(c);
    Console.WriteLine();  
  }

  public static void SocioInserir() {
    Console.WriteLine("----- Inserção de Sócios -----");
    Console.Write("Informe o nome da empresa que será associada: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a data de fundação (dd/mm/aaaa): ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    // Instancia a classe de sócio
    Socio c = new Socio { Nome = nome, Nascimento = nasc };
    // Insere o sócio
    nsocio.Inserir(c);
  }

  public static void SocioAtualizar() {
    Console.WriteLine("----- Atualização de sócios -----");
    SocioListar();
    List<Socio> st = nsocio.Listar();

    if(st.Count==0){
       Console.WriteLine();
       return;}
     else{
    Console.Write("Informe o código da empresa sócia a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome da empresa: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a data de fundação da empresa (dd/mm/aaaa): ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    // Instancia a classe de sócio
    Socio c = new Socio { Id = id, Nome = nome, Nascimento = nasc };
    // Atualiza o sócio
    nsocio.Atualizar(c);
  }
  }

  public static void SocioExcluir() {
    Console.WriteLine("----- Exclusão de sócios -----");
    SocioListar();
    List<Socio> cs = nsocio.Listar();
    if(cs.Count<1){
      Console.Write("Não há nenhum sócio cadastrado para ser excluído");}
    else{
    Console.Write("Informe o código do sócio a ser excluído: ");
    int id = int.Parse(Console.ReadLine());
    // Procura o cliente com esse id
    Socio c = nsocio.Listar(id);
    // Exclui o cliente do cadastro
    nsocio.Excluir(c);}
  }

public static void PagSocio() {
     int acordo=0;
     Console.WriteLine("----- Menu de sociedade  -----");
     Console.WriteLine("----- Digite uma das opções para continuar  -----");

       do{
         try{
           acordo=UsSocio();
           switch(acordo) {
             case 1: SocioListar(); break;
             case 2: SocioInserir(); break;
             case 3: SocioAtualizar(); break;
             case 4: SocioExcluir(); break;
             
             
     }
     }
         catch (Exception erro) {
           Console.WriteLine(erro.Message);
           acordo=100; }
     }   while(acordo!=0);
       Console.WriteLine ("Você voltou para o MENU PRINCIPAL! ..."); }



public static int UsSocio() {
     Console.WriteLine();
     Console.WriteLine("----------------------------------");
     Console.WriteLine("Digite uma das opções para continuar.");

     Console.WriteLine("1- Ver empresas sócias.");
     Console.WriteLine("2- Registrar nova empresa como sócia.");
     Console.WriteLine("3- Atualizar sócios");
     Console.WriteLine("4- Excluir sócios");
     Console.WriteLine("0 - Voltar para  o menu principal");
     Console.Write("Informe uma opção: ");
     int deal = int.Parse(Console.ReadLine());
     Console.WriteLine();
     return deal;
}



public static int MenuClienteLogin() {
    Console.WriteLine();
    Console.WriteLine("----------------------------------");
    Console.WriteLine("01 - Login");
    Console.WriteLine("2 -  Retorna ao menu de usuário");
    Console.WriteLine("0  - Fim");
    Console.WriteLine("----------------------------------");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op; 
}


public static void ClienteInserir() {
    Console.WriteLine("----- Adicionando Clientes -----");
    Console.Write("Informe o nome do novo cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Digite a data de nascimento do cliente(dd/mm/aaaa): ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    // Instancia a classe de cliente
    Cliente c = new Cliente { Nome = nome, Nascimento = nasc };
    // Insere o cliente
    ncliente.Inserir(c);
  }

    public static void ClienteListar() {
    Console.WriteLine("----- Lista de Clientes -----");
    // Lista os clientes
    List<Cliente> cs = ncliente.Listar();
    if (cs.Count == 0) {
      Console.WriteLine("Nenhum cliente cadastrado, é necessário que um vendedor cadastre os seus clientes.");
      Console.WriteLine();
      Console.WriteLine();
      return;
    }
    else{
      foreach(Cliente c in cs) Console.WriteLine(c);
      Console.WriteLine();}  
  }


public static void ClienteLogin() { 
    Console.WriteLine("----- Login do Cliente -----");
    ClienteListar();
  List<Cliente> cs = ncliente.Listar();
    if(cs.Count !=0) {
      Console.Write("Informe o código do cliente para logar: ");
     int id = int.Parse(Console.ReadLine());
      // Procura o cliente com esse id
     clienteLogin = ncliente.Listar(id);
      PagCliente();}
   
    else{
      ClienteDesconectar();
    }
}

 public static void ClienteInserirnoCarrinho() { 
    // Lista os produtos cadastrados no sistema
    ProdutoListar();
    Console.Write("Informe o código id do produto a ser comprado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a quantidade desejada: ");
    int quantidade = int.Parse(Console.ReadLine());
    // Procurar o produto pelo id
    Produto p = nproduto.Listar(id);
    // Verifica se o produto foi localizado
    if (p != null) {
      // Verifica se já existe um carrinho
      if (clienteAquisição == null)
        clienteAquisição = new Aquisição(DateTime.Now, clienteLogin);
      // Insere o produto no carrinho
      naquisição.ItemInserir(clienteAquisição, quantidade, p);  
    }
 }
    



    public static void ClienteDesconectar() { 
    Console.WriteLine("----- Voltando para o menu principal ------------");
    Console.WriteLine("-------------------------------------------------");
      Console.WriteLine("-------------------------------------------------");
    Console.WriteLine();
    Console.WriteLine();
      
    clienteLogin = null;
    Main();
  }
  public static void ClienteCarrinhoVisualizar(){
    Console.WriteLine("----- Megazord do cliente -----");
   // Analisa  se existe um carrinho de compras
    if (clienteAquisição == null) {
      Console.WriteLine("Nenhum produto foi encontrado no seu carrinho.");
      return;
    }
    // Lista os produtos no carrinho
    List<AquisiçãoItem> itens = naquisição.ItemListar(clienteAquisição);
    foreach(AquisiçãoItem item in itens) Console.WriteLine(item);
    Console.WriteLine();
  }

public static void ClienteCarrinhoAdquirir() { 
    // Verifica se já há um carrinho devidamente registrado em nosso sistema.
    if (clienteAquisição == null) {
      Console.WriteLine("Não foi encontrado nenhum produto no carrinho");
      return;
    }
  Console.WriteLine("-----  ----- -----  -----");
  Console.WriteLine("-----  ----- -----  -----");
  Console.WriteLine("Você confirmou a compra dos itens que estavam em seu carrinho.");
    // Salva a aquisição do cliente
    naquisição.Inserir(clienteAquisição, false);
    // Começa um novo carrinho
    clienteAquisição = null;
  }
  

   public static void ClienteVendaListar() { 
    Console.WriteLine("----- Minhas Compras -----");
    // Listar as compras do cliente
    List<Aquisição> vs = naquisição.Listar(clienteLogin);
    if (vs.Count == 0) {
      Console.WriteLine("Nenhuma compra cadastrada no sistema");
      return;
    }
    foreach(Aquisição a in vs) {
      Console.WriteLine(a);
      foreach (AquisiçãoItem item in naquisição.ItemListar(a))
        Console.WriteLine("  " + item);
    }    
    Console.WriteLine();
  }
    public static void ClienteCarrinhoEsvaziar() { 
    // Verificar se existe algum carrinho no sistema.
    if (clienteAquisição != null)
      naquisição.ItemExcluir(clienteAquisição);
  }
}



                  