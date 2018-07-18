using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Business.RegrasDeDesempate
{
    public class DesempateDeFullHouse : IRegraDeDesempate
    {
        private readonly IIDentificadorDeCartas _identificadorDeTrinca;

        public DesempateDeFullHouse(IIDentificadorDeCartas identificadorDeTrinca)
        {
            _identificadorDeTrinca = identificadorDeTrinca;
        }

        public IEnumerable<Carta> Desempatar(IEnumerable<Carta> maoA, IEnumerable<Carta> maoB)
        {
            var trincaDaMaoA = _identificadorDeTrinca.IdentificarCartas(maoA);
            var trincaDaMaoB = _identificadorDeTrinca.IdentificarCartas(maoB);

            var somaDaTrincaDaMaoA = trincaDaMaoA.Sum(carta => carta.Valor);
            var somaDaTrincaDaMaoB = trincaDaMaoB.Sum(carta => carta.Valor);

            return somaDaTrincaDaMaoA > somaDaTrincaDaMaoB ? maoA : maoB;
        }
    }
}