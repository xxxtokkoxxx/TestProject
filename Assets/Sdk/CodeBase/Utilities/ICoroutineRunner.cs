using System.Collections;

namespace Sdk.CodeBase.Utilities
{
    public interface ICoroutineRunner
    {
        void RunCoroutine(IEnumerator coroutine);
    }
}