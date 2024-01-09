using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private TargetSpawner _spawner;




    private void OnTriggerEnter(Collider other)
    {
        var arrowComponent = other.GetComponent<Arrow>();
        if (arrowComponent)
        {
            _spawner.RemoveUsingTarget(gameObject);
        }
    }
}
