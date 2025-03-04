class Leitor
{
    public string Nome;
    public string Cpf;
    public List<Livro> livros; 

    public Leitor(string nome, string cpf)
    {
        Nome = nome;
        Cpf = cpf;
        livros = new List<Livro>();
    }

    public void AdicionarLivro(Livro livro) => livros.Add(livro);

   public void ListarLivros()
    {
        Console.WriteLine($"Livros de {Nome}:");
        livros.ForEach(l => Console.WriteLine(l));
    }
    public Livro BuscarLivro(string titulo) => livros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

    public void RemoverLivro(string titulo)
    {
        Livro livro = BuscarLivro(titulo);
        if (livro != null) livros.Remove(livro);
    }

    public void EditarNome(string Cpf)
    {
        //fazer metodo para editar nome do leitor
    }

    public List<Livro> ObterLivros() => livros;
}