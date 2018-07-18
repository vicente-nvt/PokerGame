using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.Business.RegrasDeDesempate
{
    public class DesempateDeCartaMaisAlta : IRegraDeDesempate
    {
        private readonly IIDentificadorDeCartas _identificadorDeCartaMaisAlta;

        public DesempateDeCartaMaisAlta(IIDentificadorDeCartas identificadorDeCartaMaisAlta)
        {
            _identificadorDeCartaMaisAlta = identificadorDeCartaMaisAlta;
        }

        public IEnumerable<Carta> Desempatar(IEnumerable<Carta> maoA, IEnumerable<Carta> maoB)
        {
            var cartaMaisAltaDaMaoA = _identificadorDeCartaMaisAlta.IdentificarCartas(maoA).First();
            var cartaMaisAltaDaMaoB = _identificadorDeCartaMaisAlta.IdentificarCartas(maoB).First();

            var restanteDaMaoA = maoA.Where(carta => carta.HashDaCarta != cartaMaisAltaDaMaoA.HashDaCarta).ToList();
            var restanteDaMaoB = maoB.Where(carta => carta.HashDaCarta != cartaMaisAltaDaMaoB.HashDaCarta).ToList();

            while (cartaMaisAltaDaMaoA.Valor == cartaMaisAltaDaMaoB.Valor)
            {
                if (restanteDaMaoA.Count == 0 || restanteDaMaoB.Count == 0)
                    return new List<Carta>();

                cartaMaisAltaDaMaoA = _identificadorDeCartaMaisAlta.IdentificarCartas(restanteDaMaoA).First();
                cartaMaisAltaDaMaoB = _identificadorDeCartaMaisAlta.IdentificarCartas(restanteDaMaoB).First();

                restanteDaMaoA.Remove(cartaMaisAltaDaMaoA);
                restanteDaMaoB.Remove(cartaMaisAltaDaMaoB);
            }

            return cartaMaisAltaDaMaoA.Valor > cartaMaisAltaDaMaoB.Valor ? maoA : maoB;
        }
    }
}