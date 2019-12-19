using UnityEngine;
using Singletons;

namespace Singletons
{
    public abstract class UnityGeneratablePersistentSingleton<T> : UnitySingletonBase<T>
        where T : Component
    {
        public static T Instance
        {
            get { return GetOrGenerateInstance(); }
        }

        protected override void Awake()
        {
            DontDestroyOnLoad(gameObject);
            base.Awake();
        }
    }
}