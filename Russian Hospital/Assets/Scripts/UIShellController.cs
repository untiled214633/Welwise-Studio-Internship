using System.Collections.Generic;
using UnityEngine;

public class UIShellController : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    [SerializeField] private GameObject _uIShellPrefab;
    private List<GameObject> _uIShells = new List<GameObject>();




    private void Start()
    {
        for (int i = 0; i < _controller.MaxShellsCount; i++ )
        {
            var shell = Instantiate(_uIShellPrefab, transform);
            _uIShells.Add(shell);
        }
    }


    public void AddShell(int countOfShells)
    {
        int index = countOfShells - 1;
        _uIShells[index].SetActive(true);
    }


    public void RemoveShell(int countOfShells)
    {
        int index = countOfShells - 1;
        _uIShells[index].SetActive(false);
    }
}
