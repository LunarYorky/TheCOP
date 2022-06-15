using TheCoP.Architecture.Enums;
using TheCoP.Scripts__components_;
using UnityEngine;

namespace TheCoP.Architecture.Data_types
{
    public abstract class BuffBase : ScriptableObject
    {
        public abstract BuffType BuffType { get; }
    }
}
