using UnityEngine;

namespace Sdk.CodeBase.Utilities
{
    public class SpawnPointProvider : MonoBehaviour, ISpawnPointProvider
    {
        [SerializeField] private Transform _uiSpawnPoint;

        public Transform UiSpawnPoint => _uiSpawnPoint;
    }
}