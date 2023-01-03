using TheCoP.Architecture.Enums;
using UnityEngine;

namespace TheCoP.Architecture.Abstract
{
    public abstract class BuffBase : ScriptableObject
    {
        public abstract BuffType BuffType { get; }
    }
}
