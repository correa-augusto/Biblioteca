using System;

namespace AplicativoBiblioteca
{
    class Livro
    {
        private string titulo;
        private string subtitulo;
        private string escritor;
        private string editora;
        private string genero;
        private string tipoDaCapa;
        private int anoPublicacao;
        private int numeroDePaginas;
        private string isbn { get; set; }

        public string Isbn
        {
            get => isbn;
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Isbn não pode ser vazio");
                }
                isbn = value.Trim();
            }
        }

        public string Titulo
        {
            get => titulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("O título não pode estar vazio.");
                }
                titulo = value.Trim();
            }
        }

        public string Subtitulo
        {
            get => subtitulo;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("O subtítulo não pode estar vazio.");
                }
                subtitulo = value.Trim();
            }
        }

        public string Escritor
        {
            get => escritor;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("O escritor não pode estar vazio.");
                }
                escritor = value.Trim();
            }
        }

        public string Editora
        {
            get => editora;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("A editora não pode estar vazia.");
                }
                editora = value.Trim();
            }
        }

        public string Genero
        {
            get => genero;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("O gênero não pode estar vazio.");
                }
                genero = value.Trim();
            }
        }

        public string TipoDaCapa
        {
            get => tipoDaCapa;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("O tipo da capa não pode estar vazio.");
                }
                tipoDaCapa = value.Trim();
            }
        }

        public int AnoPublicacao
        {
            get => anoPublicacao;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("O ano de publicação deve ser maior que zero.");
                }
                else if (value < 1970)
                {
                    throw new Exception("O ano de publicação deve ser maior que 1970.");
                }
                else if (value > DateTime.Now.Year)
                {
                    throw new Exception("O ano de publicação não pode ser maior que o ano atual.");
                }

                anoPublicacao = value;
            }
        }

        public int NumeroDePaginas
        {
            get => numeroDePaginas;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("O número de páginas deve ser maior que zero.");
                }

                numeroDePaginas = value;
            }
        }

        public override string ToString()
        {
            return $"{Titulo} - {Subtitulo} | {Escritor} | {Editora} | {Genero} | {AnoPublicacao} | {TipoDaCapa} | {NumeroDePaginas} páginas";
        }
    }
}
