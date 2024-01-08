using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private GameObject _ball;




    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void Shoot(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Performed)
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            var raycast = Physics.Raycast(ray, out RaycastHit hitInfo);

            _ball.transform.position = hitInfo.point;
        }
    }
}
