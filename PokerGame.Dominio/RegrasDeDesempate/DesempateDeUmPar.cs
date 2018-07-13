using System.Collections.Generic;
using System.Linq;
using PokerGame.Dominio.Identificadores;

namespace PokerGame.Dominio.RegrasDeDesempate
{
    public class DesempateDeUmPar : IRegraDeDesempate
    {
        private readonly IIDentificadorDeCartas _identificadorDePar;
        private readonly IIDentificadorDeCartas _identificadorDeCartaMaisAlta;

        public DesempateDeUmPar(IIDentificadorDeCartas identificadorDePar, 
            IIDentificadorDeCartas identificadorDeCartaMaisAlta)
        {
            _identificadorDePar = identificadorDePar;
            _identificadorDeCartaMaisAlta = identificadorDeCartaMaisAlta;
        }

        public List<Carta> Desempatar(List<Carta> maoA, List<Carta> maoB)
        {
            var parDaMaoA = _identificadorDePar.IdentificarCartas(maoA);
            var parDaMaoB = _identificadorDePar.IdentificarCartas(maoB);

            var restanteDaMaoA = maoA.Where(carta => !parDaMaoA.Contains(carta)).ToList();
            var restanteDaMaoB = maoB.Where(carta => !parDaMaoB.Contains(carta)).ToList();

            if (parDaMaoA.First().Valor != parDaMaoB.First().Valor)
                return parDaMaoA.First().Valor > parDaMaoB.First().Valor ? maoA : maoB;

            Carta cartaMaisAltaDaMaoA;
            Carta cartaMaisAltaDaMaoB;

            do
            {
                cartaMaisAltaDaMaoA = _identificadorDeCartaMaisAlta.IdentificarCartas(restanteDaMaoA).First();
                cartaMaisAltaDaMaoB = _identificadorDeCartaMaisAlta.IdentificarCartas(restanteDaMaoB).First();

                restanteDaMaoA.Remove(cartaMaisAltaDaMaoA);
                restanteDaMaoB.Remove(cartaMaisAltaDaMaoB);

                if (restanteDaMaoA.Count == 0 || restanteDaMaoB.Count == 0)
                    return new List<Carta>();

            } while (cartaMaisAltaDaMaoB.Valor == cartaMaisAltaDaMaoA.Valor);

            return cartaMaisAltaDaMaoA.Valor > cartaMaisAltaDaMaoB.Valor ? maoA : maoB;
        }
    }
}