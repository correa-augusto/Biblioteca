using System;
using System.Collections.Generic;
using System.Linq;

namespace AplicativoBiblioteca
{
    class Leitor
    {
        public string Nome;

        public int Idade;
        public string Cpf;
        private List<Livro> livros;

        public Leitor()
        {
            while (string.IsNullOrWhiteSpace(Cpf))
            {
                Console.Write("CPF (digite \"sair\" para voltar ao menu): ");
                Cpf = Console.ReadLine().Trim();

                if (Cpf.Equals("sair", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                if (string.IsNullOrWhiteSpace(Cpf))
                {
                    Console.WriteLine("O CPF não pode estar vazio.");
                }
                else if (Biblioteca.ExisteCPF(Cpf))
                {
                    Console.WriteLine("O CPF já está cadastrado.");
                    Cpf = string.Empty;
                }
            }

            while (string.IsNullOrWhiteSpace(Nome))
            {

                Console.Write("Nome: ");
                Nome = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(Nome))
                {
                    Console.WriteLine("O nome não pode estar vazio.");
                }
            }

            while (Idade <= 0)
            {

                Console.Write("Idade: ");
                var IdadeInput = Console.ReadLine();

                if (int.TryParse(IdadeInput, out Idade) && Idade < 0)
                {
                    Console.WriteLine("A idade não pode ser menor ou igual a zero.");
                }
                else if (!int.TryParse(IdadeInput, out Idade))
                {
                    Console.WriteLine("A idade deve ser um número inteiro.");
                }
            }

            livros = new List<Livro>();
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
            Livro livro = BuscarLivro(titulo);
            if (livro != null) livros.Remove(livro);
        }

        public void EditarNome(string novoNome) => Nome = novoNome;

        public List<Livro> ObterLivros() => livros;
    }
}
