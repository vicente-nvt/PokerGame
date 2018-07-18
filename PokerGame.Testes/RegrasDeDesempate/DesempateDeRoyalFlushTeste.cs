using PokerGame.Dominio.RegrasDeDesempate;
using Xunit;

namespace PokerGame.Testes.RegrasDeDesempate
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
