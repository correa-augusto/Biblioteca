using System;

namespace AplicativoBiblioteca
{
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
            while (string.IsNullOrWhiteSpace(Titulo))
            {
                Console.Write("Título: ");
                Titulo = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(Titulo))
                {
                    Console.WriteLine("O título não pode estar vazio.");
                }
            }

            while (string.IsNullOrWhiteSpace(Subtitulo))
            {
                Console.Write("Subtítulo: ");
                Subtitulo = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(Subtitulo))
                {
                    Console.WriteLine("O subtítulo não pode estar vazio.");
                }
            }

            while (string.IsNullOrWhiteSpace(Escritor))
            {
                Console.Write("Escritor: ");
                Escritor = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(Escritor))
                {
                    Console.WriteLine("O escritor não pode estar vazio.");
                }
            }

            while (string.IsNullOrWhiteSpace(Editora))
            {
                Console.Write("Editora: ");
                Editora = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(Editora))
                {
                    Console.WriteLine("A editora não pode estar vazia.");
                }
            }

            while (string.IsNullOrWhiteSpace(Genero))
            {
                Console.Write("Gênero: ");
                Genero = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(Genero))
                {
                    Console.WriteLine("O gênero não pode estar vazio.");
                }
            }

            while (string.IsNullOrWhiteSpace(TipoDaCapa))
            {
                Console.Write("Tipo da capa: ");
                TipoDaCapa = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(TipoDaCapa))
                {
                    Console.WriteLine("O tipo da capa não pode estar vazio.");
                }
            }

            while (AnoPublicacao <= 0)
            {
                Console.Write("Ano de publicação: ");
                var anoPublicacaoInput = Console.ReadLine();

                if (int.TryParse(anoPublicacaoInput, out AnoPublicacao) && AnoPublicacao <= 0)
                {
                    Console.WriteLine("O ano de publicação não pode ser menor ou igual a zero.");
                }
                else if (!int.TryParse(anoPublicacaoInput, out AnoPublicacao))
                {
                    Console.WriteLine("O ano de publicação deve ser um número inteiro.");
                }
            }

            while (NumeroDePaginas <= 0)
            {
                Console.Write("Número de páginas: ");
                var numeroDePaginasInput = Console.ReadLine();

                if (int.TryParse(numeroDePaginasInput, out NumeroDePaginas) && NumeroDePaginas <= 0)
                {
                    Console.WriteLine("O número de páginas não pode ser menor ou igual a zero.");
                }
                else if (!int.TryParse(numeroDePaginasInput, out NumeroDePaginas))
                {
                    Console.WriteLine("O número de páginas deve ser um número inteiro.");
                }
            }
        }

        public override string ToString()
        {
            return $"{Titulo} - {Subtitulo} | {Escritor} | {Editora} | {Genero} | {AnoPublicacao} | {TipoDaCapa} | {NumeroDePaginas} páginas";
        }
    }
}
