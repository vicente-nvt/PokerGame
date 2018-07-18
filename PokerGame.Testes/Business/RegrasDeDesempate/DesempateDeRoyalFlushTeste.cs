using PokerGame.Dominio.Business.RegrasDeDesempate;
using Xunit;

namespace PokerGame.Testes.Business.RegrasDeDesempate
{
    public class DesempateDeRoyalFlushTeste
    {
        [Fact]
        public void NaoDeveDeterminarVencedorNoDesempateDeRoyalFlush()
        {
            var jogadaVencedoraEncontrada = new DesempateDeRoyalFlush().Desempatar(null, null);

            Assert.Empty(jogadaVencedoraEncontrada);
        }
    }
}
