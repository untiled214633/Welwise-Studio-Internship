using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private ArrowsThrower _arrowThrower;
    [SerializeField] private Transform _arrowSpawnPointTransform;




    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void Shoot(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Performed)
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hitInfo);

            _arrowThrower.ThrowArrow(_arrowSpawnPointTransform.position, hitInfo.point);
        }
    }
}
