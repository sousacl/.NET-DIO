using System;

namespace DesafioCelular
{
    // Classe abstrata Smartphone
    abstract class Smartphone
    {
        // Atributos comuns a todos os smartphones
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double TamanhoTela { get; set; }
        public int Memoria { get; set; }
        public int Armazenamento { get; set; }

        // Construtor da classe abstrata
        public Smartphone(string marca, string modelo, double tamanhoTela, int memoria, int armazenamento)
        {
            Marca = marca;
            Modelo = modelo;
            TamanhoTela = tamanhoTela;
            Memoria = memoria;
            Armazenamento = armazenamento;
        }

        // Método abstrato InstalarAplicativo, que deve ser sobrescrito nas classes filhas
        public abstract void InstalarAplicativo(string nomeAplicativo);

        // Método Ligar, que é comum a todos os smartphones
        public void Ligar()
        {
            Console.WriteLine($"O smartphone {Marca} {Modelo} está ligando...");
        }

        // Método Desligar, que é comum a todos os smartphones
        public void Desligar()
        {
            Console.WriteLine($"O smartphone {Marca} {Modelo} está desligando...");
        }
    }

    // Classe Nokia, que é uma classe filha de Smartphone
    class Nokia : Smartphone
    {
        // Atributo específico da classe Nokia
        public bool PossuiTeclado { get; set; }

        // Construtor da classe Nokia, que chama o construtor da classe base
        public Nokia(string marca, string modelo, double tamanhoTela, int memoria, int armazenamento, bool possuiTeclado) : base(marca, modelo, tamanhoTela, memoria, armazenamento)
        {
            PossuiTeclado = possuiTeclado;
        }

        // Método sobrescrito InstalarAplicativo, que implementa a lógica específica da classe Nokia
        public override void InstalarAplicativo(string nomeAplicativo)
        {
            // Usando um bloco try para tentar instalar o aplicativo
            try
            {
                Console.WriteLine($"O smartphone Nokia {Modelo} está instalando o aplicativo {nomeAplicativo} da loja Ovi Store...");
                // Simulando uma possível exceção ao instalar um aplicativo inválido
                if (nomeAplicativo == "WhatsApp")
                {
                    throw new Exception("O aplicativo WhatsApp não é compatível com o smartphone Nokia 3310.");
                }
                Console.WriteLine($"O aplicativo {nomeAplicativo} foi instalado com sucesso.");
            }
            // Usando um bloco catch para tratar a exceção, caso ela ocorra
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro ao instalar o aplicativo {nomeAplicativo}: {e.Message}");
            }
        }

        // Método específico da classe Nokia
        public void TirarFoto()
        {
            Console.WriteLine($"O smartphone Nokia {Modelo} está tirando uma foto com a sua câmera de alta resolução...");
        }
    }

    // Classe Iphone, que é uma classe filha de Smartphone
    class Iphone : Smartphone
    {
        // Atributo específico da classe Iphone
        public string Cor { get; set; }

        // Construtor da classe Iphone, que chama o construtor da classe base
        public Iphone(string marca, string modelo, double tamanhoTela, int memoria, int armazenamento, string cor) : base(marca, modelo, tamanhoTela, memoria, armazenamento)
        {
            Cor = cor;
        }

        // Método sobrescrito InstalarAplicativo, que implementa a lógica específica da classe Iphone
        public override void InstalarAplicativo(string nomeAplicativo)
        {
            // Usando um bloco try para tentar instalar o aplicativo
            try
            {
                Console.WriteLine($"O smartphone Iphone {Modelo} está instalando o aplicativo {nomeAplicativo} da loja App Store...");
                // Simulando uma possível exceção ao instalar um aplicativo que requer mais armazenamento do que o disponível
                if (nomeAplicativo == "Call of Duty")
                {
                    throw new Exception("O aplicativo Call of Duty requer mais armazenamento do que o disponível no smartphone Iphone 12.");
                }
                Console.WriteLine($"O aplicativo {nomeAplicativo} foi instalado com sucesso.");
            }
            // Usando um bloco catch para tratar a exceção, caso ela ocorra
            catch (Exception e)
            {
                Console.WriteLine($"Ocorreu um erro ao instalar o aplicativo {nomeAplicativo}: {e.Message}");
            }
        }

        // Método específico da classe Iphone
        public void FazerVideoChamada()
        {
            Console.WriteLine($"O smartphone Iphone {Modelo} está fazendo uma videochamada com o seu aplicativo FaceTime...");
        }
    }

    // Classe Program, que contém o método Main
    class Program
    {
        static void Main(string[] args)
        {
            // Criando um objeto da classe Nokia
            Nokia nokia3310 = new Nokia("Nokia", "3310", 2.4, 16, 32, true);

            // Chamando os métodos da classe Nokia
            nokia3310.Ligar();
            nokia3310.InstalarAplicativo("Snake");
            nokia3310.InstalarAplicativo("WhatsApp"); // Este aplicativo vai gerar uma exceção
            nokia3310.TirarFoto();
            nokia3310.Desligar();

            // Criando um objeto da classe Iphone
            Iphone iphone12 = new Iphone("Apple", "Iphone 12", 6.1, 4096, 256, "Azul");

            // Chamando os métodos da classe Iphone
            iphone12.Ligar();
            iphone12.InstalarAplicativo("Instagram");
            iphone12.InstalarAplicativo("Call of Duty"); // Este aplicativo vai gerar uma exceção
            iphone12.FazerVideoChamada();
            iphone12.Desligar();
        }
    }
}
