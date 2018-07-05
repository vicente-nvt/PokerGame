using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.RegrasDeDesempate
{
    public class DesempateDeFlush : IRegraDeDesempate
    {
        private readonly IIDentificadorDeCartas _identificadorDeCartaMaisAlta;

        public DesempateDeFlush(IIDentificadorDeCartas identificadorDeCartaMaisAlta)
        {
            _identificadorDeCartaMaisAlta = identificadorDeCartaMaisAlta;
        }

        public List<Carta> Desempatar(List<Carta> maoA, List<Carta> maoB)
        {
            Carta cartaMaisAltaDaMaoA;
            Carta cartaMaisAltaDaMaoB;
            var copiaDaMaoA = maoA.Select(carta => carta).ToList();
            var copiaDaMaoB = maoB.Select(carta => carta).ToList();

            do
            {
                cartaMaisAltaDaMaoA = _identificadorDeCartaMaisAlta.IdentificarCartas(copiaDaMaoA).First();
                cartaMaisAltaDaMaoB = _identificadorDeCartaMaisAlta.IdentificarCartas(copiaDaMaoB).First();

                copiaDaMaoA.Remove(cartaMaisAltaDaMaoA);
                copiaDaMaoB.Remove(cartaMaisAltaDaMaoB);

                if (copiaDaMaoA.Count == 0 || copiaDaMaoB.Count == 0)
                    return new List<Carta>();

            } while (cartaMaisAltaDaMaoA.Valor == cartaMaisAltaDaMaoB.Valor);

            return cartaMaisAltaDaMaoA.Valor > cartaMaisAltaDaMaoB.Valor ? maoA : maoB;
        }
    }
}