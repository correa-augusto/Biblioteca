using System;
using System.Collections.Generic;
using System.Linq;

namespace AplicativoBiblioteca
{
    internal class Biblioteca
    {
        public static List<Leitor> leitores = new List<Leitor>();

        public static bool ExisteCPF(string cpf)
        {
            return leitores.Exists(l => l.Cpf == cpf);
        }

        public bool AdicionarLeitor(Leitor leitor)
        {
            leitores.Add(leitor);
            return true;
        }

        public void CriarLeitor()
        {
            Console.WriteLine("Cadastro de novo leitor");

            //Coleta e tratamento de exceção de cpf
            string cpf = "";
            bool cpfValido = false;
            while(!cpfValido)
            {
                try
                {
                   cpf = ColetaCpf();
                   cpfValido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
    
            //Coleta e tratamento de exceção de nome
            string nome = "";
            bool nomeValido = false;
            while (!nomeValido)
            {
                try
                {
                    nome = ColetaNome();  
                    nomeValido = true; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }


            //Coleta e tratamento de exceção de idade
            int idade = 0;
            bool idadeValida = false;
            while(!idadeValida)
            {
                try
                {
                    idade = ColetaIdade();
                    idadeValida = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Leitor novoLeitor = new Leitor(nome, idade, cpf);
            AdicionarLeitor(novoLeitor);
            Console.WriteLine("Leitor adicionado com sucesso!");

        }

        public void ListarLeitores()
        {
            leitores.ForEach(l => Console.WriteLine($"Nome: {l.Nome} | CPF: {l.Cpf} | Idade: {l.Idade}"));
        }

        public void ListarLeitorEspecifico()
        {
            Console.Write("Digite o CPF do leitor: ");
            string cpf = Console.ReadLine().Trim();
            Leitor leitor = leitores.FirstOrDefault(l => l.Cpf == cpf);
            if (leitor != null)
            {
                Console.WriteLine($"Nome: {leitor.Nome} | CPF: {leitor.Cpf} | Idade: {leitor.Idade}");
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

        public void RemoverLeitor()
        {
            Console.Write("Digite o CPF do leitor: ");
            string cpf = Console.ReadLine().Trim();

            if (!ExisteCPF(cpf))
            {
                Console.WriteLine("Leitor não encontrado.");
                return;
            }

            leitores.RemoveAll(l => l.Cpf == cpf);
        }

        public void EditarLeitor()
        {
            Console.Write("Digite o CPF do leitor: ");
            string cpf = Console.ReadLine().Trim();

            Leitor leitor = leitores.FirstOrDefault(l => l.Cpf == cpf);
            if (leitor != null)
            {
                Console.Write($"Novo nome para {leitor.Nome}: ");
                string novoNome = Console.ReadLine().Trim();

                while (string.IsNullOrEmpty(novoNome))
                {
                    Console.WriteLine("O nome não pode estar vazio.");
                    Console.Write("Digite um novo nome: ");
                    novoNome = Console.ReadLine().Trim();
                }

                leitor.EditarNome(novoNome);
                Console.WriteLine("Leitor atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Leitor não encontrado.");
            }
        }

        public void AdicionarLivrosAoLeitor()
        {
            Console.Write("Digite o CPF do leitor: ");
            string cpf = Console.ReadLine().Trim();
            Leitor leitor = leitores.FirstOrDefault(l => l.Cpf == cpf);
            if (leitor != null)
            {
                Livro livro = new Livro();
                leitor.AdicionarLivro(livro);
            }
            else
            {
                Console.WriteLine("Não é possível adicionar livro, pois o leitor não existe.");
            }
        }

        public void EditarLivroDoLeitor()
        {
            Console.Write("Digite o CPF do leitor: ");
            string cpf = Console.ReadLine().Trim();
            Leitor leitor = leitores.FirstOrDefault(l => l.Cpf == cpf);
            if (leitor == null)
            {
                Console.WriteLine("Leitor não encontrado.");
                return;
            }

            Console.Write("Digite o título do livro: ");
            string titulo = Console.ReadLine();
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

        public void RemoverLivroDoLeitor()
        {
            Console.Write("Digite o CPF do leitor: ");
            string cpf = Console.ReadLine();
            Leitor leitor = leitores.FirstOrDefault(l => l.Cpf == cpf);
            if (leitor != null)
            {
                Console.Write("Digite o título do livro: ");
                string titulo = Console.ReadLine();
                leitor.RemoverLivro(titulo);
                Console.WriteLine($"Livro \"{titulo}\" removido do leitor {leitor.Nome}.");
            }
            else
            {
                Console.WriteLine("Leitor não encontrado.");
            }
        }

        public void BuscarLivro()
        {
            Console.Write("Digite o título do livro: ");
            string titulo = Console.ReadLine();
            leitores.ForEach(l =>
            {
                if (l.ObterLivros().Any(livro => livro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase)))
                    Console.WriteLine($"Leitor: {l.Nome} - CPF: {l.Cpf}");
            });
        }

        public void DoarLivro()
        {
            Console.Write("Digite o CPF do leitor doador: ");
            string cpfDoador = Console.ReadLine();
            Leitor leitorAntigo = leitores.FirstOrDefault(l => l.Cpf == cpfDoador);
            if (leitorAntigo == null)
            {
                Console.WriteLine("Leitor doador não encontrado.");
                return;
            }

            Console.Write("Digite o título do livro: ");
            string titulo = Console.ReadLine();
            Livro livro = leitorAntigo.BuscarLivro(titulo);
            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            Console.Write("Digite o CPF do leitor destinatário: ");
            string cpfRecebedor = Console.ReadLine();
            Leitor leitorNovo = leitores.FirstOrDefault(l => l.Cpf == cpfRecebedor);
            if (leitorNovo != null)
            {
                leitorAntigo.RemoverLivro(titulo);
                leitorNovo.AdicionarLivro(livro);
                Console.WriteLine($"Livro \"{titulo}\" doado para {leitorNovo.Nome}.");
            }
            else
            {
                Console.WriteLine("Leitor destinatário não encontrado.");
            }
        }

        private string ColetaCpf()
        {
            string cpf;

            do
            {
                Console.Write("CPF: ");
                cpf = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(cpf))
                {
                    throw new Exception("Cpf não pode ser vazio");
                }
                else if (ExisteCPF(cpf))
                {
                    throw new Exception("Cpf ja existe");
                    cpf = string.Empty;
                }

            } while (string.IsNullOrWhiteSpace(cpf));

            return cpf;
        }

        private string ColetaNome()
        {
            string nome;
            do
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    throw new Exception("Nome não pode ser vazio");
                }

            } while (string.IsNullOrWhiteSpace(nome));

            return nome;
        }

        private int ColetaIdade()
        {
            int idade;
            do
            {
                Console.Write("Idade: ");
                string inputIdade = Console.ReadLine();

                if (!int.TryParse(inputIdade, out idade))
                {
                    throw new Exception("Idade inválida");
                    idade = 0;
                }

            } while (idade <= 0);

            return idade;
        }
    }
}
