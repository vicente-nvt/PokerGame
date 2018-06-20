using System.Collections.Generic;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Jogadas
{
    public class Straight : IJogada
    {
        private readonly IIDentificadorDeCartas _identificadorDeSequencia;

        public Straight(IIDentificadorDeCartas identificadorDeSequencia)
        {
            _identificadorDeSequencia = identificadorDeSequencia;
        }

        public List<Carta> Encontrar(List<Carta> maoDe5Cartas) => _identificadorDeSequencia.IdentificarCartas(maoDe5Cartas);

        public bool JogadaEncontradaNaMao(List<Carta> maoDe5Cartas) => Encontrar(maoDe5Cartas).Count == 5;

        public string Nome => "Straight";

        public int PontuacaoDaJogada => 104;
    }
}