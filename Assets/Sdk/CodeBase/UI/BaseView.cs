using UnityEngine;

namespace Sdk.CodeBase.UI
{
    public abstract class BaseView : MonoBehaviour
    {
        public abstract ViewType ViewType { get; }
    }
}