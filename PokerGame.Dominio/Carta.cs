namespace PokerGame.Dominio
{
    public class Carta
    {
        public int Valor { get; }
        public Naipes Naipe { get; }

        public Carta(int valor, Naipes naipe)
        {
            Valor = valor;
            Naipe = naipe;
        }

    }
}