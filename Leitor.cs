using System;
using System.Collections.Generic;
using System.Linq;

namespace AplicativoBiblioteca
{
    class Leitor
    {
        private string nome;
        private int idade;
        private string cpf;
        private List<Livro> livros = new();

        public string Nome
        {
            get => nome;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Nome não pode ser vazio");
                }
                nome = value.Trim();
            }
        }


        public int Idade
        {
            get => idade;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Idade inválida");
                }
                idade = value;
            }
        }

        public string Cpf
        {
            get => cpf;
            set
            {
                var cpfTrim = value.Trim();

                if (string.IsNullOrWhiteSpace(cpfTrim))
                {
                    throw new Exception("Cpf não pode ser vazio");
                }

                if (Biblioteca.leitores.Any(leitor => leitor.Cpf == cpfTrim))
                {
                    throw new Exception("Cpf ja existe");
                }
                cpf = cpfTrim;
            }
        }

        public void AdicionarLivro(Livro livro) => livros.Add(livro);

        public void ListarLivros()
        {
            Console.WriteLine($"Livros de {Nome}:");
            livros.ForEach(l => Console.WriteLine(l));
        }

        public Livro BuscarLivro(string titulo) =>
            livros.FirstOrDefault(l => l.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase));

        public void RemoverLivro(string titulo)
        {
            var livro = BuscarLivro(titulo);
            if (livro != null) livros.Remove(livro);
        }

        public void EditarNome(string novoNome) => Nome = novoNome;

        public List<Livro> ObterLivros() => livros;
    }
}
