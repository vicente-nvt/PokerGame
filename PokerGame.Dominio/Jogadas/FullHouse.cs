using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Jogadas
{
    public class FullHouse : IJogada
    {
        private List<Carta> _maoDe5Cartas;
        private IIDentificadorDeCartas _identificadorDeTrinca;
        private IIDentificadorDeCartas _identificadorDePar;

        public FullHouse(List<Carta> maoDe5Cartas, IIDentificadorDeCartas identificadorDeTrinca, IIDentificadorDeCartas identificadorDePar)
        {
            _maoDe5Cartas = maoDe5Cartas;
            _identificadorDeTrinca = identificadorDeTrinca;
            _identificadorDePar = identificadorDePar;
        }

        public List<Carta> Encontrar()
        {
            var trinca = _identificadorDeTrinca.IdentificarCartas(_maoDe5Cartas);
            var restanteDasCartas = _maoDe5Cartas.Where(carta => !trinca.Contains(carta)).ToList();
            var par = _identificadorDePar.IdentificarCartas(restanteDasCartas);

            var fullHouse = new List<Carta>();

            if (trinca.Count == 3 && par.Count == 2)
            {
                fullHouse.AddRange(trinca);
                fullHouse.AddRange(par);
            }

            return fullHouse;
        }

        public bool JogadaEncontradaNaMao() => Encontrar().Count == 5;
    }
}
