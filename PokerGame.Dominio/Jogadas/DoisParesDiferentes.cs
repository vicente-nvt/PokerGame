using System.Collections.Generic;
using System.Linq;

namespace PokerGame.Dominio.Jogadas
{
    public class DoisParesDiferentes : IJogada
    {
        private IList<Carta> _maoDe5Cartas;
        private IIDentificadorDeCartas _identificadorDeCartas;

        public DoisParesDiferentes(IList<Carta> maoDe5Cartas, IIDentificadorDeCartas identificadorDeCartas)
        {
            _maoDe5Cartas = maoDe5Cartas;
            _identificadorDeCartas = identificadorDeCartas;
        }

        public List<Carta> Encontrar()
        {
            var umPar = _identificadorDeCartas.IdentificarCartas(_maoDe5Cartas);
            var restanteDaMao = _maoDe5Cartas.Where(carta => !umPar.Contains(carta)).ToList();
            var outroPar = _identificadorDeCartas.IdentificarCartas(restanteDaMao);

            var encontrouDoisPares = umPar.Count == 2 && outroPar.Count == 2;    
            var doisPares = new List<Carta>();

            if (encontrouDoisPares)
            {
                doisPares.AddRange(umPar);
                doisPares.AddRange(outroPar);
            }

            return doisPares;
        }

        public bool JogadaEncontradaNaMao() => Encontrar().Count == 4;
    }
}