namespace PokerGame.Dominio
{
    public class CartaBuilder
    {
        private Naipes _naipe;
        private int _valor;


        public static CartaBuilder UmaCarta()
        {
            return new CartaBuilder();
        }

        public CartaBuilder ComValor(int valor)
        {
            _valor = valor;
            return this;
        }

        public CartaBuilder ComNaipe(Naipes naipe)
        {
            _naipe = naipe;
            return this;
        }

        public Carta Construir()
        {
            return new Carta(_valor, _naipe);
        }

    }
}