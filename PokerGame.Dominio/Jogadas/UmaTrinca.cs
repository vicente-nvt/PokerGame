using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Jogadas
{
    public class UmaTrinca : IJogada
    {
        private IList<Carta> _maoDe5Cartas;

        public UmaTrinca(IList<Carta> maoDe5Cartas)
        {
            _maoDe5Cartas = maoDe5Cartas;
        }

        public List<Carta> Encontrar()
        {
            var trinca = new IdentificaTresCartasComValoresIguais().IdentificarCartas(_maoDe5Cartas);

            var aMaoPossuiUmaTrinca = trinca.Count() == 3;            
            var aMaoPossuiDuasCartasDiferentesAlemDaTrinca = aMaoPossuiUmaTrinca && VerificarSeAMaoPossuiDuasCartasDiferentesAlemDaTrinca(trinca);

            return aMaoPossuiDuasCartasDiferentesAlemDaTrinca ? trinca : new List<Carta>();
        }

        private bool VerificarSeAMaoPossuiDuasCartasDiferentesAlemDaTrinca(List<Carta> trinca)
        {
            var outrasCartasAlemDaTrinca = _maoDe5Cartas.Where(carta => !trinca.Contains(carta)).ToArray();

            var temDuasCartasDiferentesNaMaoAlemDaTrinca = outrasCartasAlemDaTrinca.Count() == 2 && 
                                                           outrasCartasAlemDaTrinca[0].Valor != outrasCartasAlemDaTrinca[1].Valor;

            return temDuasCartasDiferentesNaMaoAlemDaTrinca;
        }

        public bool JogadaEncontradaNaMao() => Encontrar().Count == 3;
    }
}
