using System.Collections.Generic;
using System.Linq;

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
            var trinca = new List<Carta>();

            foreach (var carta in _maoDe5Cartas)
            {
                var outrasCartasComMesmoValor = _maoDe5Cartas.Where(outraCarta =>
                    outraCarta.Valor == carta.Valor && outraCarta.HashDaCarta != carta.HashDaCarta).ToArray();               

                if (outrasCartasComMesmoValor.Count() == 2)
                {
                    trinca.Add(carta);
                    trinca.AddRange(outrasCartasComMesmoValor);
                    break;
                }
            }

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
