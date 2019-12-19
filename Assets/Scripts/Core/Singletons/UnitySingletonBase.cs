using UnityEngine;

namespace Singletons
{
    public abstract class UnitySingletonBase<T> : MonoBehaviour
        where T : Component
    {
        private static bool _applicationIsQuitting = false;
        private static T _instance;

        protected static T GetInstanceInScene()
        {
            if (_applicationIsQuitting)
            {
                return null;
            }

            if (!_instance)
            {
                TryFindInstance();
            }

            return _instance;
        }
        
        protected static T GetOrGenerateInstance()
        {
            if (_applicationIsQuitting) {
                return null;
            }
			
            if (!_instance) {
				
                TryFindInstance();
				
                if (_instance == null)
                {
                    GenerateNewInstanceOfSingleton();
                }
            }
            return _instance;
        }

        private static void TryFindInstance()
        {
            T[] objs = FindObjectsOfType<T>();
				
            if (objs.Length > 0) {
                _instance = objs[0];
            }
				
            if (objs.Length > 1)
            {
                _instance = objs[0];
            }
        }

        private static void GenerateNewInstanceOfSingleton()
        {
            var obj = new GameObject ( typeof(T).Name + "[Generated Singleton]");
            _instance = obj.AddComponent<T> ();
        }
        
        protected virtual void OnApplicationQuit () {
            _applicationIsQuitting = true;
        }

        protected virtual void Awake ()
        {
            if (!_instance) {
                _instance = this as T;
            } else {
                Destroy (gameObject);
            }
        }
    }
}