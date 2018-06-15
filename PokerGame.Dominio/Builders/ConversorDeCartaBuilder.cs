namespace PokerGame.Dominio
{
    public class ConversorDeCartaBuilder
    {
        private IConversor<int, string> _conversorDeValorDeCarta;
        private IConversor<Naipes, string> _conversorDeNaipe;

        public static ConversorDeCartaBuilder UmConversor()
        {
            return new ConversorDeCartaBuilder();
        }

        public ConversorDeCartaBuilder ComConversorDeValorDeCarta(IConversor<int, string> conversorDeValor)
        {
            _conversorDeValorDeCarta = conversorDeValor;
            return this;
        }

        public ConversorDeCartaBuilder ComConversorDeNaipe(IConversor<Naipes, string> conversorDeNaipe)
        {
            _conversorDeNaipe = conversorDeNaipe;
            return this;
        }

        public ConversorDeCarta Construir()
        {
            return new ConversorDeCarta(_conversorDeValorDeCarta, _conversorDeNaipe);
        }

    }
}