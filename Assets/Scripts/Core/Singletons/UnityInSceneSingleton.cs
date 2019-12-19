using UnityEngine;

namespace Singletons
{
    public abstract class UnityInSceneSingleton<T> : UnitySingletonBase<T>
        where T : Component
    {
        public static T Instance
        {
            get { return GetInstanceInScene(); }
        }
    }
}