//A classe de arquivos manipula um obojeto de um tipo genérico, mas ela precisa fazer uso das bibliotecas de arquivo e de serialização.
using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;

//Classe genérica arquivo, que recebe um parâmetro de tipo:
class Arquivo<T>{
  //As operações feitas aqui são semelhantes ás operações de abrir e salvar.

public T Abrir(string arquivo) {
//O método abrir recebe o nome do arquivo que será aberto e retornará um objeto da classe T.
  
   // Arquivo<Categoria[]> f = new Arquivo<Categoria[]>();
    //categorias = f.Abrir("./categorias.xml");
//    nc = categorias.Length;
    XmlSerializer xml = new XmlSerializer(typeof(T));
    StreamReader f = new StreamReader(arquivo, Encoding.Default);
    T obj = (T) xml.Deserialize(f);
    f.Close();
    return obj;
  
}

 // O método salvar é semelhante. Neste método, se recebe um nome de um arquivo e recebe um objeto da classe T para persistir nesse arquivo.

  public void Salvar(string arquivo, T obj) {
    //Arquivo<Categoria[]> f = new Arquivo<Categoria[]>();
    //f.Salvar("./categorias.xml", Listar());
    XmlSerializer xml = new XmlSerializer(typeof(T));
    StreamWriter f = new StreamWriter(arquivo, false, Encoding.Default);
    xml.Serialize(f, obj);
    f.Close();
  }
}