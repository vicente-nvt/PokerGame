using System.Collections.Generic;

namespace PokerGame.Dominio
{
    public class Jogador
    {
        public string Nome { get; }
        private List<Carta> _mao { get; }
        public IEnumerable<Carta> Mao => _mao;

        public Jogador(string nome, List<Carta> mao)
        {
            Nome = nome;
            _mao = mao;
        }
    }
}