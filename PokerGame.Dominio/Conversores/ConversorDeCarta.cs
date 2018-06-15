namespace PokerGame.Dominio.Conversores
{
    public class ConversorDeCarta : IConversor<Carta, string>
    {
        private readonly IConversor<Naipes, string> _conversorDeNaipe;
        private readonly IConversor<int, string> _conversorDeValor;

        public ConversorDeCarta(IConversor<int, string> conversorDeValorDeCarta,
            IConversor<Naipes, string> conversorDeNaipe)
        {
            _conversorDeNaipe = conversorDeNaipe;
            _conversorDeValor = conversorDeValorDeCarta;
        }

        public Carta Converter(string cartaDeEntrada)
        {
            var naipe = _conversorDeNaipe.Converter(ObterNaipeDaCarta(cartaDeEntrada));
            var valor = _conversorDeValor.Converter(ObterValorDaCarta(cartaDeEntrada));

            return new Carta(valor, naipe);
        }

        private static string ObterNaipeDaCarta(string cartaDeEntrada) => cartaDeEntrada.Substring(cartaDeEntrada.Length == 3 ? 2 : 1, 1);
        
        private static string ObterValorDaCarta(string cartaDeEntrada) => cartaDeEntrada.Substring(0, cartaDeEntrada.Length == 3 ? 2 : 1);

    }
}