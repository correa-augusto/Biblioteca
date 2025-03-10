using System;

namespace AplicativoBiblioteca
{
     class Program
     {
          static Biblioteca biblioteca = new Biblioteca();

          static void Main()
          {
               while (true)
               {
                    Console.Clear();
                    Console.WriteLine("===== Biblioteca =====");
                    Console.WriteLine("1. Cadastrar Leitor");
                    Console.WriteLine("2. Listar Leitores");
                    Console.WriteLine("3. Editar Leitor");
                    Console.WriteLine("4. Excluir Leitor");
                    Console.WriteLine("5. Adicionar Livro ao Leitor");
                    Console.WriteLine("6. Editar Livro do Leitor");
                    Console.WriteLine("7. Remover Livro do Leitor");
                    Console.WriteLine("8. Doar Livro para Outro Leitor");
                    Console.WriteLine("9. Listar Livros de um Leitor");
                    Console.WriteLine("10. Buscar Livro e Mostrar Leitor");
                    Console.WriteLine("0. Sair");
                    Console.Write("\nEscolha uma opção: ");

                    string opcao = Console.ReadLine();
                    Console.Clear();

                    switch (opcao)
                    {
                         case "1": biblioteca.AdicionarLeitor(new Leitor()); break;
                         case "2": biblioteca.ListarLeitores(); break;
                         case "3":
                              Console.Write("Digite o CPF do leitor: ");
                              biblioteca.EditarLeitor(Console.ReadLine());
                              break;
                         case "4":
                              Console.Write("Digite o CPF do leitor: ");
                              biblioteca.RemoverLeitor(Console.ReadLine());
                              break;
                         case "5":
                              Console.Write("Digite o CPF do leitor: ");
                              string cpf = Console.ReadLine();
                              biblioteca.AdicionarLivrosAoLeitor(cpf, new Livro());
                              break;
                         case "6":
                              Console.Write("Digite o CPF do leitor: ");
                              cpf = Console.ReadLine();
                              Console.Write("Digite o título do livro: ");
                              string titulo = Console.ReadLine();
                              biblioteca.EditarLivroDoLeitor(cpf, titulo);
                              break;
                         case "7":
                              Console.Write("Digite o CPF do leitor: ");
                              cpf = Console.ReadLine();
                              Console.Write("Digite o título do livro: ");
                              titulo = Console.ReadLine();
                              biblioteca.RemoverLivroDoLeitor(cpf, titulo);
                              break;
                         case "8":
                              Console.Write("Digite o CPF do leitor que irá receber: ");
                              cpf = Console.ReadLine();
                              Console.Write("Digite o livro: ");
                              titulo = Console.ReadLine();
                              biblioteca.DoarLivro(titulo, cpf);
                              break;
                         case "9":
                              Console.Write("Digite o CPF do leitor: ");
                              cpf = Console.ReadLine();
                              biblioteca.ListarLeitorEspecifico(cpf);
                              break;
                         case "10":
                              Console.Write("Digite o título do livro: ");
                              titulo = Console.ReadLine();
                              biblioteca.BuscarLivro(titulo);
                              break;
                         case "0": return;
                         default: Console.WriteLine("Opção inválida!"); break;
                    }
                    Console.WriteLine("\nPressione ENTER para continuar...");
                    Console.ReadLine();
               }
          }
     }
}
