namespace PokerGame.Dominio
{
    public interface IJogada<out T>
    {
        T Encontrar();
        bool JogadaEncontradaNaMao();
    }
}