using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Jogadas
{
    public class DoisParesDiferentes : IJogada
    {
        private IList<Carta> _maoDe5Cartas;
        private IIDentificadorDeCartas _identificadorDePares;

        public DoisParesDiferentes(IList<Carta> maoDe5Cartas, IIDentificadorDeCartas identificadorDePares)
        {
            _maoDe5Cartas = maoDe5Cartas;
            _identificadorDePares = identificadorDePares;
        }

        public List<Carta> Encontrar()
        {
            var umPar = _identificadorDePares.IdentificarCartas(_maoDe5Cartas);
            var restanteDaMao = _maoDe5Cartas.Where(carta => !umPar.Contains(carta)).ToList();
            var outroPar = _identificadorDePares.IdentificarCartas(restanteDaMao);

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