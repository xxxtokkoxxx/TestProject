using UnityEngine;

namespace SDK.Sdk.CodeBase.Utilities
{
    public interface ISpawnPointProvider
    {
        Transform UiSpawnPoint { get; }
    }
}