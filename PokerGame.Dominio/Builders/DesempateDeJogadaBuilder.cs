using PokerGame.Dominio.Identificadores;
using PokerGame.Dominio.RegrasDeDesempate;

namespace PokerGame.Dominio.Builders
{
    public class DesempateDeJogadaBuilder
    {
        private IdentificaCartaMaisAlta _identificadorDeCartasMaisAlta;
        private IdentificaDuasCartasComValoresIguais _identificadorDePar;
        private IdentificaTresCartasComValoresIguais _identificadorDeTrinca;
        private IdentificaQuatroCartasComValoresIguais _identificadorDeQuadra;

        public static DesempateDeJogadaBuilder UmDesempatador()
        {
            return new DesempateDeJogadaBuilder();
        }

        public DesempateDeJogadaBuilder ComIdentificadorDeCartaMaisAltaDefinido()
        {
            _identificadorDeCartasMaisAlta = new IdentificaCartaMaisAlta();
            return this;
        }

        public DesempateDeJogadaBuilder ComIdentificadorDeParDefinido()
        {
            _identificadorDePar = new IdentificaDuasCartasComValoresIguais();
            return this;
        }

        public DesempateDeJogadaBuilder ComIdentificadorDeTrincaDefinido()
        {
            _identificadorDeTrinca = new IdentificaTresCartasComValoresIguais();
            return this;
        }

        public DesempateDeJogadaBuilder ComIdentificadorDeQuadraDefinido()
        {
            _identificadorDeQuadra = new IdentificaQuatroCartasComValoresIguais();            
            return this;
            
        }

        public IDesempateDeJogada Construir()
        {
            return new DesempateDeJogada(_identificadorDeTrinca, _identificadorDeCartasMaisAlta, _identificadorDeQuadra,
                _identificadorDePar);
        }
    }
}