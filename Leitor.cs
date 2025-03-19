using System;
using System.Collections.Generic;
using System.Linq;

namespace AplicativoBiblioteca
{
    class Leitor
    {
        private string Nome;
        public string _nome
        {
            get => Nome;
            set
            {
                string valorTrim = value?.Trim();
                if (!string.IsNullOrEmpty(valorTrim))
                {
                    Nome = valorTrim;
                }
                else
                {
                    Console.WriteLine("O nome não pode estar vazio.");
                }
            }
        }

        private int Idade;
        public int _idade
        {
            get => Idade;
            set
            {

                if (value > 0)
                {
                    Idade = value;
                }
                else
                {
                    Console.WriteLine("A idade deve ser maior que zero.");
                }
            }
        }

        private string Cpf;
        public string _cpf
        {
            get => Cpf;
            set
            {
                string valorTrim = value?.Trim();
                if (!string.IsNullOrEmpty(valorTrim))
                {
                    if (Biblioteca.ExisteCPF(valorTrim))
                    {
                        Console.WriteLine("CPF já cadastrado.");
                    }
                    else
                    {
                        Cpf = valorTrim;
                    }
                }
                else
                {
                    Console.WriteLine("O CPF não pode estar vazio.");
                }
                
            }
        }

        private List<Livro> livros;

        public Leitor()
        {
            while (string.IsNullOrWhiteSpace(Cpf))
            {
                Console.Write("CPF (digite \"sair\" para voltar ao menu): ");
                string inputCpf = Console.ReadLine()?.Trim();

                if (inputCpf.Equals("sair", StringComparison.OrdinalIgnoreCase))
                {
                    return;
                }

                if (string.IsNullOrWhiteSpace(inputCpf))
                {
                    Console.WriteLine("O CPF não pode estar vazio.");
                }
                else if (Biblioteca.ExisteCPF(inputCpf))
                {
                    Console.WriteLine("O CPF já está cadastrado.");
                }
                else
                {
                    Cpf = inputCpf;
                }
            }

            while (string.IsNullOrWhiteSpace(Nome))
            {
                Console.Write("Nome: ");
                Nome = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(Nome))
                {
                    Console.WriteLine("O nome não pode estar vazio.");
                }
            }

            while (Idade <= 0)
            {
                Console.Write("Idade: ");
                string idadeInput = Console.ReadLine();

                if (int.TryParse(idadeInput, out int idade) && idade > 0)
                {
                    Idade = idade;
                }
                else
                {
                    Console.WriteLine("A idade deve ser um número inteiro maior que zero.");
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
            if (livro != null)
            {
                livros.Remove(livro);
                Console.WriteLine($"Livro \"{titulo}\" removido com sucesso.");
            }
            else
            {
                Console.WriteLine($"Livro \"{titulo}\" não encontrado.");
            }
        }

        public void EditarNome(string novoNome)
        {
            if (!string.IsNullOrWhiteSpace(novoNome))
            {
                Nome = novoNome.Trim();
                Console.WriteLine("Nome atualizado com sucesso.");
            }
            else
            {
                Console.WriteLine("O novo nome não pode estar vazio.");
            }
        }

        public List<Livro> ObterLivros() => livros;
    }
}
