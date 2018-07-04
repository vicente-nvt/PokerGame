using PokerGame.Dominio;
using PokerGame.Dominio.Conversores;
using PokerGame.Dominio.Identificadores;
using Xunit;

namespace PokerGame.Testes
{
    public class AnalisadorDeJogadasTeste
    {
        private readonly ConversorDeMaoDe5Cartas _conversorDeMaoDe5Cartas;
        private readonly IIDentificadorDeCartas _identificadorDeNaipesIguais;
        private readonly IIDentificadorDeCartas _identificadorDeSequencia;
        private readonly IIDentificadorDeCartas _identificadorDeTrinca;
        private readonly IIDentificadorDeCartas _identificadorDePar;

        public AnalisadorDeJogadasTeste()
        {
            _identificadorDeNaipesIguais = new IdentificaCincoCartasComNaipesIguais();
            _identificadorDeSequencia = new IdentificaSequenciaDeCarta();
            _identificadorDeTrinca = new IdentificaTresCartasComValoresIguais();
            _identificadorDePar = new IdentificaDuasCartasComValoresIguais();

            var conversorDeNaipes = new ConversorDeNaipe();
            var conversorDeValorDeCarta = new ConversorDeValorDeCarta();
            var conversorDeCarta = new ConversorDeCarta(conversorDeValorDeCarta, conversorDeNaipes);
            _conversorDeMaoDe5Cartas = new ConversorDeMaoDe5Cartas(conversorDeCarta);
        }

        [Theory]
        [InlineData("4D 6S 9H TH QC", "Carta Mais Alta")]
        [InlineData("4D 6S 9H QH QC", "Um Par de Cartas")]
        [InlineData("6D 6S KS QH QC", "Dois Pares")]
        [InlineData("4D 6S QS QH QC", "Uma Trinca")]
        [InlineData("4D 5S 6H 7H 8C", "Straight")]
        [InlineData("4C 6C 9C KC QC", "Flush")]
        [InlineData("6D 6S QS QH QC", "Full House")]
        [InlineData("4D 4S 4H QH 4C", "Quadra")]
        [InlineData("4D 5D 6D 7D 8D", "Straight Flush")]
        [InlineData("10S TS QS KS AS", "Royal Flush")]        
        public void DeveIdentificarAJogadaDaMao(string mao, string nomeDaJogadaEsperada)
        {
            var maoDeCartas = _conversorDeMaoDe5Cartas.Converter(mao);

            var jogadaEncontrada = new AnalisadorDeJogada(_identificadorDeSequencia,
                _identificadorDeNaipesIguais, _identificadorDeTrinca, _identificadorDePar).Analisar(maoDeCartas);

            Assert.Equal(nomeDaJogadaEsperada, jogadaEncontrada.Nome);
        }

        [Theory]
        [InlineData("4D 6S 9H TH QC", 100)]
        [InlineData("4D 6S 9H QH QC", 101)]
        [InlineData("6D 6S KS QH QC", 102)]
        [InlineData("4D 6S QS QH QC", 103)]
        [InlineData("4D 5S 6H 7H 8C", 104)]
        [InlineData("4C 6C 9C KC QC", 105)]
        [InlineData("6D 6S QS QH QC", 106)]
        [InlineData("4D 4S 4H QH 4C", 107)]
        [InlineData("4D 5D 6D 7D 8D", 108)]
        [InlineData("10S TS QS KS AS", 109)]
        public void DeveValidarAPontuacaoDaJogadaDaMao(string mao, int pontuacaoDaJogadaEsperada)
        {
            var maoDeCartas = _conversorDeMaoDe5Cartas.Converter(mao);
            var jogadaEncontrada = new AnalisadorDeJogada(_identificadorDeSequencia,
                _identificadorDeNaipesIguais, _identificadorDeTrinca, _identificadorDePar).Analisar(maoDeCartas);

            Assert.Equal(pontuacaoDaJogadaEsperada, jogadaEncontrada.PontuacaoDaJogada);
        }
    }
}
