using UnityEngine;

namespace Sdk.CodeBase.Utilities
{
    public class Singleton <T> : MonoBehaviour where T : MonoBehaviour
    {  
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    GameObject coreGameObject = new GameObject(typeof(T).Name);
 
                    _instance = coreGameObject.AddComponent<T>();
                }
 
                return _instance;
            }
        }
 
        private static T _instance;
 
        private void Start()
        {
            if (_instance == null)
            {
                _instance = GetComponent<T>();
            }
            else
            {
                DestroyImmediate(this);
            }
        }
    }
}