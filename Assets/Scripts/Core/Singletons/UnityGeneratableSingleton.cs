using UnityEngine;

namespace Singletons
{
    public abstract class UnityGeneratableSingleton<T> : UnitySingletonBase<T>
        where T : Component
    {
        public static T Instance
        {
            get { return GetOrGenerateInstance(); }
        }
    }
}