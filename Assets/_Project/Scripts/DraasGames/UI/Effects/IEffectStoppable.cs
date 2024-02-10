namespace DraasGames.UI.Effects
{
    public interface IEffectStoppable : IEffect
    {
        public void Continue();
        public void Stop();
    }
}