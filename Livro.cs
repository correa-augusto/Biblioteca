class Livro
{
   public string Titulo;
   public string Subtitulo;
   public string Escritor;
   public string Editora;
   public string Genero;
   public string TipoDaCapa;
   public int AnoPublicacao;
   public int NumeroDePaginas;

   public Livro(string titulo, string subtitulo, string escritor, string editora, string genero, int anoPublicacao, string tipoDaCapa, int numeroDePaginas)
   {
       Titulo = titulo;
       Subtitulo = subtitulo;
       Escritor = escritor;
       Editora = editora;
       Genero = genero;
       AnoPublicacao = anoPublicacao;
       TipoDaCapa = tipoDaCapa;
       NumeroDePaginas = numeroDePaginas;
   }

   public override string ToString()
    {
        return $"{Titulo} - {Subtitulo} | {Escritor} | {Editora} | {Genero} | {AnoPublicacao} | {TipoDaCapa} | {NumeroDePaginas} páginas";
    }
}