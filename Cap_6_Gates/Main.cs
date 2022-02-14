using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
class MainClass {
   private static NCategoria ncategoria = new NCategoria();
   private static NProduto nproduto = new NProduto();
   private static NSocio nsocio = new NSocio();



   public static void Main() {
     Thread.CurrentThread.CurrentCulture = new CultureInfo("PT-BR");
     int opção = 0;
     Console.WriteLine ("------GitGames — site  de vendas de games ------");
     do{
       try{
         opção=Menu();
         switch(opção) {
           case 1 : PagCliente(); break;
           case 2 : PagVendedor(); break;
           case 3 : PagSocio(); break;
            }
             }
       catch (Exception erro) {
         Console.WriteLine(erro.Message);
         opção=100; }
     } while(opção!=0);
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
             case 5: CategoriaListar(); break;
             case 6: ProdutoListar(); break;
     }
     }
         catch (Exception erro) {
           Console.WriteLine(erro.Message);
           seleção=100; }
     }   while(seleção!=8);
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
       Console.WriteLine("Nenhum produto foi cadastrado");
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
    Console.Write("Informe o preço do produto em R$ ");
    double preço= int.Parse(Console.ReadLine());
    Console.Write("Informe o código da categoria do produto:");
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

     Console.WriteLine("5 - Ver categorias de produtos disponíveis.");
     Console.WriteLine("6 - Ver produtos disponíveis");
     Console.WriteLine("8 - Voltar para o menu principal");
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
     
     foreach(Categoria c in ct){
       Console.WriteLine(c);
       Console.WriteLine(); }
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
    Console.Write("Informe um código de  categoria para exclui-la: ");
    int id = int.Parse(Console.ReadLine());
    // Procurar a categoria com esse id
    Categoria c = ncategoria.Listar(id);
    // Exclui a categoria do cadastro
    ncategoria.Excluir(c);
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

     Console.WriteLine("0 - Voltar para  o menu principal");
     Console.Write("Informe uma opção: ");
     int preferência = int.Parse(Console.ReadLine());
     Console.WriteLine();
     return preferência;
}
public static void ProdutoAtualizar() {
  Console.WriteLine("----- Atualização de Produtos -----");
    ProdutoListar();
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
    nproduto.Atualizar(p);
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
    Console.Write("Informe o nome da empresa que será associada.: ");
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
    CategoriaListar();
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
     Console.WriteLine("2- Adicionar nova empresa como sócia.");
     Console.WriteLine("3- Atualizar sócios");
     Console.WriteLine("4- Excluir sócios");
     Console.WriteLine("0 - Voltar para  o menu principal");
     Console.Write("Informe uma opção: ");
     int deal = int.Parse(Console.ReadLine());
     Console.WriteLine();
     return deal;
}

}


                  