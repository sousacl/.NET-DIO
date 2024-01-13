using Xunit;
using ConsoleApp;

[TestClass]
public class ValidacoesListaTests
{
    // Cria um objeto da classe ValidacoesLista
    ValidacoesLista validacoesLista = new ValidacoesLista();

    [TestMethod]
    public void DeveRemoverNumerosNegativosDeUmaLista()
    {
        // Define os valores de entrada e esperados
        List<int> listaEntrada = new List<int> { -1, 2, -3, 4, -5 };
        List<int> listaEsperada = new List<int> { 2, 4 };

        // Invoca o método RemoverNumerosNegativos da classe ValidacoesLista
        List<int> listaResultado = validacoesLista.RemoverNumerosNegativos(listaEntrada);

        // Verifica se o resultado é igual ao esperado
        Assert.Equal(listaEsperada, listaResultado);
    }

    [TestMethod]
    public void DeveConterONumero9NaLista()
    {
        // Define os valores de entrada e esperados
        List<int> listaEntrada = new List<int> { 1, 2, 3, 4, 5, 9 };
        int numeroProcurado = 9;
        bool contemEsperado = true;

        // Invoca o método ListaContemDeterminadoNumero da classe ValidacoesLista
        bool contemResultado = validacoesLista.ListaContemDeterminadoNumero(listaEntrada, numeroProcurado);

        // Verifica se o resultado é igual ao esperado
        Assert.Equal(contemEsperado, contemResultado);
    }

    [TestMethod]
    public void NaoDeveConterONumero10NaLista()
    {
        // Define os valores de entrada e esperados
        List<int> listaEntrada = new List<int> { 1, 2, 3, 4, 5, 9 };
        int numeroProcurado = 10;
        bool contemEsperado = false;

        // Invoca o método ListaContemDeterminadoNumero da classe ValidacoesLista
        bool contemResultado = validacoesLista.ListaContemDeterminadoNumero(listaEntrada, numeroProcurado);

        // Verifica se o resultado é igual ao esperado
        Assert.Equal(contemEsperado, contemResultado);
    }

    [TestMethod]
    public void DeveMultiplicarOsElementosDaListaPor2()
    {
        // Define os valores de entrada e esperados
        List<int> listaEntrada = new List<int> { 1, 2, 3, 4, 5 };
        int fatorMultiplicacao = 2;
        List<int> listaEsperada = new List<int> { 2, 4, 6, 8, 10 };

        // Invoca o método MultiplicarNumerosLista da classe ValidacoesLista
        List<int> listaResultado = validacoesLista.MultiplicarNumerosLista(listaEntrada, fatorMultiplicacao);

        // Verifica se o resultado é igual ao esperado
        Assert.Equal(listaEsperada, listaResultado);
    }

    [TestMethod]
    public void DeveRetornar9ComoMaiorNumeroDaLista()
    {
        // Define os valores de entrada e esperados
        List<int> listaEntrada = new List<int> { 1, 2, 3, 4, 5, 9 };
        int maiorEsperado = 9;

        // Invoca o método RetornarMaiorNumeroLista da classe ValidacoesLista
        int maiorResultado = validacoesLista.RetornarMaiorNumeroLista(listaEntrada);

        // Verifica se o resultado é igual ao esperado
        Assert.Equal(maiorEsperado, maiorResultado);
    }

    [TestMethod]
    public void DeveRetornarOitoNegativoComoMenorNumeroDaLista()
    {
        // Define os valores de entrada e esperados
        List<int> listaEntrada = new List<int> { 1, 2, 3, 4, 5, -8 };
        int menorEsperado = -8;

        // Invoca o método RetornarMenorNumeroLista da classe ValidacoesLista
        int menorResultado = validacoesLista.RetornarMenorNumeroLista(listaEntrada);

        // Verifica se o resultado é igual ao esperado
        Assert.Equal(menorEsperado, menorResultado);
    }
}

[TestClass]
public class ValidacoesStringTests
{
    // Cria um objeto da classe ValidacoesString
    ValidacoesString validacoesString = new ValidacoesString();

    [TestMethod]
    public void DeveRetornar6QuantidadeCaracteresDaPalavraMatrix()
    {
        // Define os valores de entrada e esperados
        string textoEntrada = "Matrix";
        int quantidadeEsperada = 6;

        // Invoca o método RetornarQuantidadeCaracteres da classe ValidacoesString
        int quantidadeResultado = validacoesString.RetornarQuantidadeCaracteres(textoEntrada);

        // Verifica se o resultado é igual ao esperado
        Assert.Equal(quantidadeEsperada, quantidadeResultado);
    }

    [TestMethod]
    public void DeveContemAPalavraQualquerNoTexto()
    {
        // Define os valores de entrada e esperados
        string textoEntrada = "Esse é um texto qualquer";
        string textoProcurado = "qualquer";
        bool contemEsperado = true;

        // Invoca o método ContemCaractere da classe ValidacoesString
        bool contemResultado = validacoesString.ContemCaractere(textoEntrada, textoProcurado);

        // Verifica se o resultado é igual ao esperado
        Assert.Equal(contemEsperado, contemResultado);
    }

    [TestMethod]
    public void NaoDeveConterAPalavraTesteNoTexto()
    {
        // Define os valores de entrada e esperados
        string textoEntrada = "Esse é um texto qualquer";
        string textoProcurado = "teste";
        bool contemEsperado = false;

        // Invoca o método ContemCaractere da classe ValidacoesString
        bool contemResultado = validacoesString.ContemCaractere(textoEntrada, textoProcurado);

        // Verifica se o resultado é igual ao esperado
        Assert.Equal(contemEsperado, contemResultado);
    }

    [TestMethod]
    public void TextoDeveTerminarComAPalavraProcurado()
    {
        // Define os valores de entrada e esperados para o cenário positivo
        string textoEntradaPositivo = "Esse é um texto qualquer";
        string textoProcuradoPositivo = "qualquer";
        bool terminaComEsperadoPositivo = true;

        // Invoca o método TextoTerminaCom da classe ValidacoesString para o cenário positivo
        bool terminaComResultadoPositivo = validacoesString.TextoTerminaCom(textoEntradaPositivo, textoProcuradoPositivo);

        // Verifica se o resultado é igual ao esperado para o cenário positivo
        Assert.Equal(terminaComEsperadoPositivo, terminaComResultadoPositivo);

        // Define os valores de entrada e esperados para o cenário negativo
        string textoEntradaNegativo = "Esse é um texto qualquer";
        string textoProcuradoNegativo = "texto";
        bool terminaComEsperadoNegativo = false;

        // Invoca o método TextoTerminaCom da classe ValidacoesString para o cenário negativo
        bool terminaComResultadoNegativo = validacoesString.TextoTerminaCom(textoEntradaNegativo, textoProcuradoNegativo);

        // Verifica se o resultado é igual ao esperado para o cenário negativo
        Assert.Equal(terminaComEsperadoNegativo, terminaComResultadoNegativo);
    }
}
