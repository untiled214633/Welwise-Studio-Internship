using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;

    [SerializeField] private GameObject[] _targets;
    [SerializeField] private int _startTargetsCount;
    [SerializeField] private float _targetsSpawnFrequency;
    private List<int> _indexesOfUsedTargets = new List<int>();




    private void Start()
    {
        for (int i = 0; i < _startTargetsCount; i++)
        {
            SpawnTarget();
        }

        StartCoroutine(IFrequencyTargetSpawner());
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


    public void RemoveUsingTarget(GameObject target)
    {
        int index = 0;

        for (int i = 0; i < _targets.Length; i++)
        {
            if (target == _targets[i])
            {
                index = i;
                break;
            }
        }

        _indexesOfUsedTargets.Remove(index);
        _targets[index].SetActive(false);

        _controller.AddShell();
    }


    private IEnumerator IFrequencyTargetSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(_targetsSpawnFrequency);
            SpawnTarget();
        }
    }
}
