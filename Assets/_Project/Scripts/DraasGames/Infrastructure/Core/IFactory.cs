namespace DraasGames.Infrastructure.Core
{
    public interface IFactory<out T>
    {
        public T Create();
    }
}