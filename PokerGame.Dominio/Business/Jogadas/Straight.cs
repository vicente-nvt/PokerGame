using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Business.Jogadas
{
    public class Straight : IJogada
    {
        private readonly IIDentificadorDeCartas _identificadorDeSequencia;

        public Straight(IIDentificadorDeCartas identificadorDeSequencia)
        {
            _identificadorDeSequencia = identificadorDeSequencia;
        }

        public IEnumerable<Carta> Encontrar(IEnumerable<Carta> maoDe5Cartas) =>
            _identificadorDeSequencia.IdentificarCartas(maoDe5Cartas);

        public bool JogadaEncontradaNaMao(IEnumerable<Carta> maoDe5Cartas) => Encontrar(maoDe5Cartas).Count() == 5;

        public string Nome => "Straight";

        public int PontuacaoDaJogada => (int) Jogada;
        public Jogada Jogada => Jogada.Straight;
    }
}