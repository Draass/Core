using System;
using DraasGames.Infrastructure.Core;

namespace DraasGames.Infrastructure.ExtensionComponents
{
    /// <summary>
    /// Base abstract class used for assigning components to different behavioral monobehaviour systems
    /// </summary>
    [Serializable]
    public abstract class ExtensionComponent : IInitializable
    {
        public virtual void Initialize() { }
    }
}