using UnityEngine;

public class ArrowsThrower : MonoBehaviour
{
    [SerializeField] private Arrow _arrowPrefab;




    public void ThrowArrow(Vector3 spwanPoint, Vector3 targetPosition)
    {
        Arrow arrow = Instantiate(_arrowPrefab, spwanPoint, Quaternion.Euler(0,0,0), null);
        arrow.ThrowArrow(targetPosition);
    }
}
