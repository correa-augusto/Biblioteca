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

            var leitor = new Leitor();

            bool cpfValido = false;
            while (!cpfValido)
            {
                try
                {
                    Console.Write("CPF: ");
                    leitor.Cpf = Console.ReadLine().Trim();
                    cpfValido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bool nomeValido = false;
            while (!nomeValido)
            {
                try
                {
                    Console.Write("Nome: ");
                    leitor.Nome = Console.ReadLine().Trim();
                    nomeValido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            int idade = 0;
            bool idadeValida = false;
            while (!idadeValida)
            {
                try
                {
                    Console.Write("Idade: ");
                    var idadeString = Console.ReadLine().Trim();
                    if (!int.TryParse(idadeString, out idade))
                    {
                        throw new Exception("Idade inválida");
                    }
                    leitor.Idade = idade;

                    idadeValida = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            AdicionarLeitor(leitor);
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
            Console.WriteLine("Adicionando livro ao leitor...");

            Console.Write("Digite o CPF do leitor: ");
            string cpf = Console.ReadLine().Trim();

            Leitor leitor = leitores.FirstOrDefault(l => l.Cpf == cpf);

            if (leitor == null)
            {
                Console.WriteLine("Não é possível adicionar livro, pois o leitor não existe.");
                return;
            }

            Console.WriteLine($"Leitor encontrado: {leitor.Nome}");
            Console.WriteLine("Cadastro de novo livro");

            var livro = new Livro();

            bool isbnValido = false;
            while (!isbnValido)
            {
                try
                {
                    Console.Write("ISBN: ");
                    livro = new Livro() { Isbn = Console.ReadLine().Trim() };
                    isbnValido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bool tituloValido = false;
            while (!tituloValido)
            {
                try
                {
                    Console.Write("Título: ");
                    livro.Titulo = Console.ReadLine().Trim();
                    tituloValido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bool subtituloValido = false;
            while (!subtituloValido)
            {
                try
                {
                    Console.Write("Subtítulo: ");
                    livro.Subtitulo = Console.ReadLine().Trim();
                    subtituloValido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bool escritorValido = false;
            while (!escritorValido)
            {
                try
                {
                    Console.Write("Escritor: ");
                    livro.Escritor = Console.ReadLine().Trim();
                    escritorValido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bool editoraValida = false;
            while (!editoraValida)
            {
                try
                {
                    Console.Write("Editora: ");
                    livro.Editora = Console.ReadLine().Trim();
                    editoraValida = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bool generoValido = false;
            while (!generoValido)
            {
                try
                {
                    Console.Write("Gênero: ");
                    livro.Genero = Console.ReadLine().Trim();
                    generoValido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bool capaValida = false;
            while (!capaValida)
            {
                try
                {
                    Console.Write("Tipo da capa: ");
                    livro.TipoDaCapa = Console.ReadLine().Trim();
                    capaValida = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bool anoValido = false;
            while (!anoValido)
            {
                try
                {
                    Console.Write("Ano de publicação: ");
                    string anoString = Console.ReadLine().Trim();
                    if (!int.TryParse(anoString, out int ano) || ano <= 0)
                    {
                        throw new Exception("O ano de publicação deve ser um número inteiro positivo.");
                    }
                    livro.AnoPublicacao = ano;
                    anoValido = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            bool paginasValidas = false;
            while (!paginasValidas)
            {
                try
                {
                    Console.Write("Número de páginas: ");
                    string paginasString = Console.ReadLine().Trim();
                    if (!int.TryParse(paginasString, out int paginas) || paginas <= 0)
                    {
                        throw new Exception("O número de páginas deve ser um número inteiro positivo.");
                    }
                    livro.NumeroDePaginas = paginas;
                    paginasValidas = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            leitor.AdicionarLivro(livro);
            Console.WriteLine($"Livro \"{livro.Titulo}\" adicionado com sucesso ao leitor {leitor.Nome}.");
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
    }
}
