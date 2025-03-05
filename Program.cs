using System;
using System.Collections.Generic;
using System.Linq;

namespace AplicativoBiblioteca;

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
                case "1": biblioteca.AdicionarLeitor(); break;
                case "2": biblioteca.ListarLeitores(); break;
                case "3": biblioteca.EditarLeitor(); break;
                case "4": biblioteca.RemoverLeitor(); break;
                case "5": biblioteca.AdicionarLivrosAoLeitor(); break;
                case "6": biblioteca.EditarLivroDoLeitor(); break;
                case "7": biblioteca.RemoverLivroDoLeitor(); break;
                case "8": biblioteca.DoarLivro(); break;
                case "9": biblioteca.ListarLeitorEspecifico(); break;
                case "10": biblioteca.BuscarLivro(); break;
                case "0": return;
                default: Console.WriteLine("Opção inválida!"); break;
           }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }   
   }

}