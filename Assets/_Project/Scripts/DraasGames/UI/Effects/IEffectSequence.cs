namespace DraasGames.UI.Effects
{
    public interface IEffectSequence
    {
        /// <summary>
        /// Start effect sequence
        /// </summary>
        /// <param name="sequentially"></param>
        public void PlaySequence(bool sequentially = true);

        public void CancelSequence();
    }
}