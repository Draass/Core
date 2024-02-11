namespace DraasGames.Infrastructure.State
{
    public interface IState
    {
        public void Enter();
        public void Exit();
    }
}