using PokerGame.Dominio.Conversores;

namespace PokerGame.Dominio.Builders
{
    public class ConversorDeMaoDe5CartasBuilder
    {
        private IConversor<Carta, string> _conversorDeCarta;

        public static ConversorDeMaoDe5CartasBuilder UmConversor()
        {
            return new ConversorDeMaoDe5CartasBuilder();
        }

        public ConversorDeMaoDe5CartasBuilder ComConversorDeCartas(IConversor<Carta, string> conversorDeCarta)
        {
            _conversorDeCarta = conversorDeCarta;
            return this;
        }

        public ConversorDeMaoDe5Cartas Construir()
        {
            return new ConversorDeMaoDe5Cartas(_conversorDeCarta);
        }
    }
}