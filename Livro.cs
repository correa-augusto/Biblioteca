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

    public Livro()
    {
        Console.Write("Título: ");
        Titulo = Console.ReadLine();
        Console.Write("Subtítulo: ");
        Subtitulo = Console.ReadLine();
        Console.Write("Escritor: ");
        Escritor = Console.ReadLine();
        Console.Write("Editora: ");
        Editora = Console.ReadLine();
        Console.Write("Gênero: ");
        Genero = Console.ReadLine();
        Console.Write("Tipo da capa: ");
        TipoDaCapa = Console.ReadLine();
        Console.Write("Ano de publicação: ");
        AnoPublicacao = int.Parse(Console.ReadLine());
        Console.Write("Número de páginas: ");
        NumeroDePaginas = int.Parse(Console.ReadLine());
    }

    public override string ToString()
    {
        return $"{Titulo} - {Subtitulo} | {Escritor} | {Editora} | {Genero} | {AnoPublicacao} | {TipoDaCapa} | {NumeroDePaginas} páginas";
    }
}