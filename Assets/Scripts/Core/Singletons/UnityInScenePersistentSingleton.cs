using UnityEngine;

namespace Singletons
{
    public class UnityInScenePersistentSingleton<T> : UnitySingletonBase<T>
        where T : Component
    {
        public static T Instance
        {
            get { return GetInstanceInScene(); }
        }

        protected override void Awake()
        {
            DontDestroyOnLoad(gameObject);
            base.Awake();
        }
    }
}