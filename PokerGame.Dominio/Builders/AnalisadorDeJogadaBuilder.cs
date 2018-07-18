using PokerGame.Dominio.Business;
using PokerGame.Dominio.Conversores;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Builders
{
    public class AnalisadorDeJogadaBuilder
    {
        private IdentificaTresCartasComValoresIguais _identificadorDeTrinca;
        private IdentificaDuasCartasComValoresIguais _identificadorDePar;
        private IdentificaSequenciaDeCarta _identificadorDeSequencia;
        private IdentificaCincoCartasComNaipesIguais _identificadorDeNaipes;
        private IIDentificadorDeCartas _identificadorDeCartaMaisAlta;
        private IIDentificadorDeCartas _identificadorDeQuatroCartasIguais;

        public static AnalisadorDeJogadaBuilder UmAnalisador()
        {
            return new AnalisadorDeJogadaBuilder();
        }

        public AnalisadorDeJogadaBuilder ComIdentificadorDeCartaMaisAltaDefinido()
        {
            _identificadorDeCartaMaisAlta = new IdentificaCartaMaisAlta();
            return this;
        }

        public AnalisadorDeJogadaBuilder ComIdentificadorDeQuatroCartasDefinido()
        {
            _identificadorDeQuatroCartasIguais = new IdentificaQuatroCartasComValoresIguais();
            return this;
        }

        public AnalisadorDeJogadaBuilder ComIdentificadorDeTrincaDefinido()
        {
            _identificadorDeTrinca = new IdentificaTresCartasComValoresIguais();
            return this;
        }

        public AnalisadorDeJogadaBuilder ComIdentificadorDeParDefinido()
        {
            _identificadorDePar = new IdentificaDuasCartasComValoresIguais();
            return this;
        }

        public AnalisadorDeJogadaBuilder ComIdentificadorDeSequenciaDefinido()
        {
            _identificadorDeSequencia = new IdentificaSequenciaDeCarta();
            return this;
        }

        public AnalisadorDeJogadaBuilder ComIdentificadorDeNaipesIguaisDefinido()
        {
            _identificadorDeNaipes = new IdentificaCincoCartasComNaipesIguais();
            return this;
        }

        public AnalisadorDeJogada Construir()
        {
            return new AnalisadorDeJogada(_identificadorDeSequencia, _identificadorDeNaipes,
                _identificadorDeTrinca, _identificadorDePar, _identificadorDeCartaMaisAlta,
                _identificadorDeQuatroCartasIguais);
        }
    }
}