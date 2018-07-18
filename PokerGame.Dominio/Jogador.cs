namespace PokerGame.Dominio
{
    public class Jogador
    {
        public string Nome { get; }
        public string Mao { get; }

        public Jogador(string nome, string mao)
        {
            Nome = nome;
            Mao = mao;
        }
    }
}