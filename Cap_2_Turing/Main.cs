using System;
class MainClass {
   private static NCategoria ncategoria = new NCategoria();
   private static NProduto nproduto = new NProduto();


   public static void Main() {
     int opção = 0;
     Console.WriteLine ("------GitGames — site  de vendas de games ------");
     do{
       try{
         opção=Menu();
         switch(opção) {
           case 1 : PagCliente(); break;
           case 2 : PagVendedor(); break;
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
       Console.WriteLine ("Acesso finalizado, obrigado!....."); }
       
 
   public static void PagVendedor() {
     int decisão=0;
     Console.WriteLine("----- Menu do vendedor  -----");
     Console.WriteLine("----- Digite uma das opções para continuar  -----");

       do{
         try{
           decisão=Negociador();
           switch(decisão) {
             case 3: CategoriaInserir(); break;
             case 4: ProdutoInserir(); break;
     }
     }
         catch (Exception erro) {
           Console.WriteLine(erro.Message);
           decisão=100; }
     }   while(decisão!=9);
       Console.WriteLine ("Acesso finalizado, obrigado!....."); }
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
    Console.Write("Informe uma descrição sobre o produto: ");
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
     Console.WriteLine("8 - Encerrar o acesso");
     Console.Write("Informe uma opção: ");
     int escolha = int.Parse(Console.ReadLine());
     Console.WriteLine();
     return escolha;
  }
  public static void CategoriaListar() {
    Categoria[] ct = ncategoria.Listar();
     if(ct.Length==0){
       Console.WriteLine("Não há nenhuma categoria cadastrada");
       return;}
     foreach(Categoria c in ct){
       Console.WriteLine(c);
       Console.WriteLine(); }
  }
  


 public static void CategoriaInserir() {
    Console.WriteLine("----- Inserção de Categorias -----");
    Console.Write("Informe um código para a categoria: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    // Instanciar a classe de Categoria
    Categoria c = new Categoria(id, descricao);
    // Inserção da categoria
    ncategoria.Inserir(c);
  }

public static int Negociador() {
     Console.WriteLine();
     Console.WriteLine("----------------------------------");
     Console.WriteLine("Digite uma das opções para continuar.");

     Console.WriteLine("3- Inserir categoria de produtos.");
     Console.WriteLine("4- Inserir produto");
     Console.WriteLine("9 - Encerrar o acesso");
     Console.Write("Informe uma opção: ");
     int preferência = int.Parse(Console.ReadLine());
     Console.WriteLine();
     return preferência;
}
}
                  