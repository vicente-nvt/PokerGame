using System.Collections.Generic;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Jogadas
{
    public class UmParDeCartas : IJogada
    {
        private readonly IIDentificadorDeCartas _identificadorDePar;

        public UmParDeCartas(IIDentificadorDeCartas identificadorDePar)
        {
            _identificadorDePar = identificadorDePar;
        }

        public List<Carta> Encontrar(List<Carta> maoDe5Cartas) => _identificadorDePar.IdentificarCartas(maoDe5Cartas);

        public bool JogadaEncontradaNaMao(List<Carta> maoDe5Cartas) => Encontrar(maoDe5Cartas).Count == 2;

        public string Nome => "Um Par de Cartas";
        public int PontuacaoDaJogada => 101;
    }
}