using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// Classe para representar um veículo
class Veiculo
{
    // Atributos do veículo
    public string Placa { get; set; }
    public string Modelo { get; set; }
    public DateTime Entrada { get; set; }
    public DateTime? Saida { get; set; }

    // Construtor do veículo
    public Veiculo(string placa, string modelo)
    {
        Placa = placa;
        Modelo = modelo;
        Entrada = DateTime.Now;
        Saida = null;
    }

    // Método para calcular o valor cobrado pelo período
    public decimal CalcularValor()
    {
        // Define o valor da hora
        decimal valorHora = 5.0m;

        // Calcula o tempo de permanência
        TimeSpan tempo = (Saida ?? DateTime.Now) - Entrada;

        // Arredonda o tempo para cima
        int horas = (int)Math.Ceiling(tempo.TotalHours);

        // Retorna o valor cobrado
        return horas * valorHora;
    }
}

// Classe para representar um estacionamento
class Estacionamento
{
    // Atributo para armazenar os veículos
    private Dictionary<string, Veiculo> veiculos;

    // Construtor do estacionamento
    public Estacionamento()
    {
        veiculos = new Dictionary<string, Veiculo>();
    }

    // Método para adicionar um veículo
    public void AdicionarVeiculo(string placa, string modelo)
    {
        // Verifica se a placa é válida
        if (ValidarPlaca(placa))
        {
            // Cria um novo veículo
            Veiculo veiculo = new Veiculo(placa, modelo);

            // Adiciona o veículo no dicionário
            veiculos.Add(placa, veiculo);

            // Exibe uma mensagem de confirmação
            Console.WriteLine($"Veículo {placa} - {modelo} adicionado com sucesso.");
        }
        else
        {
            // Exibe uma mensagem de erro
            Console.WriteLine($"Placa {placa} inválida.");
        }
    }

    // Método para remover um veículo
    public void RemoverVeiculo(string placa)
    {
        // Verifica se a placa é válida
        if (ValidarPlaca(placa))
        {
            // Busca o veículo no dicionário pelo atributo placa
            Veiculo veiculo = veiculos.GetValueOrDefault(placa);

            // Verifica se o veículo foi encontrado
            if (veiculo != null)
            {
                // Define o horário de saída
                veiculo.Saida = DateTime.Now;

                // Calcula o valor cobrado
                decimal valor = veiculo.CalcularValor();

                // Remove o veículo do dicionário
                veiculos.Remove(placa);

                // Exibe uma mensagem de confirmação com o valor cobrado
                Console.WriteLine($"Veículo {placa} - {veiculo.Modelo} removido com sucesso.");
                Console.WriteLine($"Valor cobrado: R$ {valor}");
            }
            else
            {
                // Exibe uma mensagem de erro
                Console.WriteLine($"Veículo {placa} não encontrado.");
            }
        }
        else
        {
            // Exibe uma mensagem de erro
            Console.WriteLine($"Placa {placa} inválida.");
        }
    }

    // Método para listar os veículos
    public void ListarVeiculos()
    {
        // Verifica se o dicionário está vazio
        if (veiculos.Count == 0)
        {
            // Exibe uma mensagem de aviso
            Console.WriteLine("Não há veículos no estacionamento.");
        }
        else
        {
            // Exibe uma mensagem de cabeçalho
            Console.WriteLine("Veículos no estacionamento:");

            // Percorre o dicionário de veículos
            foreach (KeyValuePair<string, Veiculo> par in veiculos)
            {
                // Exibe os dados do veículo
                Console.WriteLine($"Placa: {par.Key}");
                Console.WriteLine($"Modelo: {par.Value.Modelo}");
                Console.WriteLine($"Entrada: {par.Value.Entrada}");
                Console.WriteLine($"Valor: R$ {par.Value.CalcularValor()}");
                Console.WriteLine();
            }
        }
    }

    // Método estático para validar a placa do veículo
    public static bool ValidarPlaca(string placa)
    {
        // Define o padrão de uma placa válida
        string padrao = @"^[A-Z]{3}[0-9][A-Z][0-9]{2}$";

        // Cria uma expressão regular com o padrão
        Regex regex = new Regex(padrao);

        // Retorna se a placa corresponde ao padrão
        return regex.IsMatch(placa);
    }
}

// Classe principal do programa
class Program
{
    // Método principal do programa
    static void Main(string[] args)
    {
        // Cria um novo estacionamento
        Estacionamento estacionamento = new Estacionamento();

        // Cria uma variável para armazenar a opção escolhida
        int opcao = 0;

        // Cria um bloco try-catch para tratar possíveis exceções
        try
        {
            // Cria um laço para repetir o menu até que a opção 4 seja escolhida
            while (opcao != 4)
            {
                // Exibe o menu de opções
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1 - Adicionar um veículo");
                Console.WriteLine("2 - Remover um veículo");
                Console.WriteLine("3 - Listar os veículos");
                Console.WriteLine("4 - Sair");

                // Lê a opção digitada
                opcao = int.Parse(Console.ReadLine());

                // Verifica qual opção foi escolhida
                switch (opcao)
                {
                    case 1:
                        // Lê os dados do veículo
                        Console.WriteLine("Digite a placa do veículo:");
                        string placa = Console.ReadLine();
                        Console.WriteLine("Digite o modelo do veículo:");
                        string modelo = Console.ReadLine();

                        // Adiciona o veículo no estacionamento
                        estacionamento.AdicionarVeiculo(placa, modelo);
                        break;
                    case 2:
                        // Lê a placa do veículo
                        Console.WriteLine("Digite a placa do veículo:");
                        placa = Console.ReadLine();

                        // Remove o veículo do estacionamento
                        estacionamento.RemoverVeiculo(placa);
                        break;
                    case 3:
                        // Lista os veículos do estacionamento
                        estacionamento.ListarVeiculos();
                        break;
                    case 4:
                        // Exibe uma mensagem de despedida
                        Console.WriteLine("Obrigado por usar o sistema do estacionamento.");
                        break;
                    default:
                        // Exibe uma mensagem de erro
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
        catch (Exception e)
        {
            // Exibe a mensagem da exceção
            Console.WriteLine(e.Message);
        }
    }
}
