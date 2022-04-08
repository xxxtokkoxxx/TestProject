using System.Collections;

namespace SDK.Sdk.CodeBase.Utilities
{
    public interface ICoroutineRunner
    {
        void RunCoroutine(IEnumerator coroutine);
    }
}