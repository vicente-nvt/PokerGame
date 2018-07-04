using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.RegrasDeDesempate
{
    public class DesempateDeFullHouse : IRegraDeDesempate
    {
        private readonly IIDentificadorDeCartas _identificadorDeTrinca;

        public DesempateDeFullHouse(IIDentificadorDeCartas identificadorDeTrinca)
        {
            _identificadorDeTrinca = identificadorDeTrinca;
        }

        public List<Carta> Desempatar(List<Carta> maoA, List<Carta> maoB)
        {
            var trincaDaMaoA = _identificadorDeTrinca.IdentificarCartas(maoA);
            var trincaDaMaoB = _identificadorDeTrinca.IdentificarCartas(maoB);

            var somaDaTrincaDaMaoA = trincaDaMaoA.Sum(carta => carta.Valor);
            var somaDaTrincaDaMaoB = trincaDaMaoB.Sum(carta => carta.Valor);

            return somaDaTrincaDaMaoA > somaDaTrincaDaMaoB ? maoA : maoB;
        }
    }
}