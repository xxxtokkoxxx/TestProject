using UnityEngine;

namespace SDK.Sdk.CodeBase.UI
{
    public abstract class BaseView : MonoBehaviour
    {
        public abstract ViewType ViewType { get; }
    }
}