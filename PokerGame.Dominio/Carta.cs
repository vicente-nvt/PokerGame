namespace PokerGame.Dominio
{
    public class Carta
    {
        public int Valor { get; }
        public Naipes Naipe { get; }
        public string HashDaCarta => $"{Valor}.{Naipe}";

        public Carta(int valor, Naipes naipe)
        {
            Valor = valor;
            Naipe = naipe;
        }

    }
}