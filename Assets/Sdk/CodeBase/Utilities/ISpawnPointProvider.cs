using UnityEngine;

namespace Sdk.CodeBase.Utilities
{
    public interface ISpawnPointProvider
    {
        Transform UiSpawnPoint { get; }
    }
}