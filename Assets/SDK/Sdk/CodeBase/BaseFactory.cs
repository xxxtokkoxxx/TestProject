using UnityEngine;
using Zenject;

namespace SDK.Sdk.CodeBase
{
    public class BaseFactory
    {
        protected TObject Create<TObject>(TObject gameObject, Transform parent)
            where TObject : Behaviour
        {
            return Object.Instantiate(gameObject, parent);
        }
        
        protected TObject Create<TObject>(TObject gameObject)
            where TObject : Behaviour
        {
            return Object.Instantiate(gameObject);
        }
        
        protected TObject Create<TObject>(TObject gameObject, Vector3 position, Quaternion rotation, Transform parent)
            where TObject : Behaviour
        {
            return Object.Instantiate(gameObject, position, rotation, parent);
        }
        
        protected TObject CreateWithDependencyInjection<TObject>(DiContainer container,
            TObject gameObject,
            Transform parent) 
            where TObject : Behaviour
        {
            return container.InstantiatePrefab(gameObject, parent).GetComponent<TObject>();
        }

        protected TObject CreateWithDependencyInjection<TObject>(DiContainer container,
            TObject gameObject,
            Vector3 position, 
            Quaternion rotation, 
            Transform parent) 
            where TObject : Behaviour
        {
            return container.InstantiatePrefab(gameObject, position, rotation, parent).GetComponent<TObject>();
        }
    }
}