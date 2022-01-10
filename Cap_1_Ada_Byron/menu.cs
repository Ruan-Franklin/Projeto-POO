using System;
class MainClass {
   private static NCategoria ncategoria = new NCategoria();
   public static void Main() {
     int opção = 0;
     Console.WriteLine ("------GitGames — site  de vendas de games ------");
     do{
       try{
         opção=Menu();
         switch(opção) {
           case 1 : PagCliente(); break;
           case 2 : PagVendedor(); break; }  }
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
     Console.WriteLine("----- Categorias de jogos disponíveis -----");
     Categoria[] ct = ncategoria.Listar();
     if(ct.Length==0){
       Console.WriteLine("Não há nenhuma categoria cadastrada");
       return;}
     foreach(Categoria c in ct){
       Console.WriteLine(c);
       Console.WriteLine();
     }
     }
 
   public static void PagVendedor() {
     Console.WriteLine("----- Inserção de produtos -----");
     Console.Write("Informe um código para a categoria: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome da categoria: ");
    string descrição = Console.ReadLine();
    Categoria c = new Categoria(id, descrição);
    ncategoria.Inserir(c);
  }
}

                  