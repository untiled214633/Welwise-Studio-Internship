using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _targets;
    [SerializeField] private int _maxTargetsCount;
    [SerializeField] private float _targetsSpawnFrequency;
    private List<int> _indexesOfUsedTargets = new List<int>();




    private void Start()
    {
        for (int i = 0; i < _maxTargetsCount; i++)
        {
            SpawnTarget();
        }
    }

    private void SpawnTarget()
    {
        int targetIndex = Random.Range(0, _targets.Length);

        foreach (var index in _indexesOfUsedTargets)
        {
            if (targetIndex == index)
            {
                SpawnTarget();
                return;
            }
        }
        _indexesOfUsedTargets.Add(targetIndex);
        _targets[targetIndex].SetActive(true);
    }
}
