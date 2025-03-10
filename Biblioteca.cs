using System;
using System.Collections.Generic;
using System.Linq;

namespace AplicativoBiblioteca
{
    class Biblioteca
    {
        private List<Leitor> leitores = new List<Leitor>();

        public bool AdicionarLeitor(Leitor leitor)
        {
            if (leitores.Exists(l => l.Cpf == leitor.Cpf))
            {
                Console.WriteLine("Leitor já existe.");
                return false;
            }
            leitores.Add(leitor);
            return true;
        }

        public void ListarLeitores()
        {
            leitores.ForEach(l => Console.WriteLine($"Nome: {l.Nome} | CPF: {l.Cpf}"));
        }

        public void ListarLeitorEspecifico(string cpf)
        {
            Leitor leitor = leitores.FirstOrDefault(l => l.Cpf == cpf);
            if (leitor != null)
            {
                Console.WriteLine($"Nome: {leitor.Nome} | CPF: {leitor.Cpf}");
                Console.WriteLine("Livros do leitor:");
                if (leitor.ObterLivros().Any())
                {
                    leitor.ObterLivros().ForEach(livro => Console.WriteLine($"- {livro.Titulo} ({livro.AnoPublicacao})"));
                }
                else
                {
                    Console.WriteLine("Nenhum livro cadastrado.");
                }
            }
            else
            {
                Console.WriteLine("Leitor não encontrado.");
            }
        }

        public void RemoverLeitor(string cpf)
        {
            leitores.RemoveAll(l => l.Cpf == cpf);
        }

        public void EditarLeitor(string cpf)
        {
            Leitor leitor = leitores.FirstOrDefault(l => l.Cpf == cpf);
            if (leitor != null)
            {
                Console.Write($"Novo nome para {leitor.Nome}: ");
                string novoNome = Console.ReadLine();
                leitor.EditarNome(novoNome);
                Console.WriteLine("Leitor atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Leitor não encontrado.");
            }
        }

        public void AdicionarLivrosAoLeitor(string cpf, Livro livro)
        {
            Leitor leitor = leitores.FirstOrDefault(l => l.Cpf == cpf);
            if (leitor != null)
            {
                leitor.AdicionarLivro(livro);
            }
            else
            {
                Console.WriteLine("Não é possível adicionar livro, pois o leitor não existe.");
            }
        }

        public void EditarLivroDoLeitor(string cpf, string titulo)
        {
            Leitor leitor = leitores.FirstOrDefault(l => l.Cpf == cpf);
            if (leitor == null)
            {
                Console.WriteLine("Leitor não encontrado.");
                return;
            }

            Livro livro = leitor.BuscarLivro(titulo);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado na lista do leitor.");
                return;
            }

            Console.WriteLine($"Editando livro: {livro.Titulo}");
            Console.Write("Novo título: ");
            livro.Titulo = Console.ReadLine();
            Console.Write("Novo ano de publicação: ");
            livro.AnoPublicacao = int.Parse(Console.ReadLine());
        }

        public void RemoverLivroDoLeitor(string cpf, string titulo)
        {
            Leitor leitor = leitores.FirstOrDefault(l => l.Cpf == cpf);
            if (leitor != null)
            {
                leitor.RemoverLivro(titulo);
                Console.WriteLine($"Livro \"{titulo}\" removido do leitor {leitor.Nome}.");
            }
            else
            {
                Console.WriteLine("Leitor não encontrado.");
            }
        }

        public void BuscarLivro(string titulo)
        {
            leitores.ForEach(l =>
            {
                if (l.ObterLivros().Any(livro => livro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase)))
                    Console.WriteLine($"Leitor: {l.Nome} - CPF: {l.Cpf}");
            });
        }

        public void DoarLivro(string titulo, string cpfRecebedor)
        {
            Leitor leitorAntigo = leitores.FirstOrDefault(l => l.ObterLivros().Any(livro => livro.Titulo == titulo));
            if (leitorAntigo == null)
            {
                Console.WriteLine("Leitor doador não encontrado.");
                return;
            }

            Livro livro = leitorAntigo.BuscarLivro(titulo);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            leitorAntigo.RemoverLivro(titulo);
            Leitor leitorNovo = leitores.FirstOrDefault(l => l.Cpf == cpfRecebedor);
            if (leitorNovo != null)
            {
                leitorNovo.AdicionarLivro(livro);
                Console.WriteLine($"Livro \"{titulo}\" doado para {leitorNovo.Nome}.");
            }
            else
            {
                Console.WriteLine("Leitor destinatário não encontrado.");
            }
        }
    }
}
