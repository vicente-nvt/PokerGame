using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.RegrasDeDesempate
{
    public class DesempateDeQuadra : IRegraDeDesempate
    {
        private readonly IIDentificadorDeCartas _identificadorDeQuadra;

        public DesempateDeQuadra(IIDentificadorDeCartas identificadorDeQuadra)
        {
            _identificadorDeQuadra = identificadorDeQuadra;
        }

        public List<Carta> Desempatar(List<Carta> maoA, List<Carta> maoB)
        {
            var umaCartaDaQuadraA = _identificadorDeQuadra.IdentificarCartas(maoA).First();
            var umaCartaDaQuadraB = _identificadorDeQuadra.IdentificarCartas(maoB).First();

            return umaCartaDaQuadraA.Valor > umaCartaDaQuadraB.Valor ? maoA : maoB;
        }
    }
}