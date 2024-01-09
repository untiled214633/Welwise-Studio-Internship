using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private UIShellController _shellController;
    [SerializeField] private ArrowsThrower _arrowThrower;
    [SerializeField] private Transform _arrowSpawnPointTransform;
    [SerializeField] private int _maxShellsCount = 5;
    public int MaxShellsCount => _maxShellsCount;
    private int _shellsCount;




    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _shellsCount = _maxShellsCount;
    }


    public void Shoot(InputAction.CallbackContext callbackContext)
    {
        if (_shellsCount == 0) return;

        if (callbackContext.phase == InputActionPhase.Performed)
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hitInfo);

            _arrowThrower.ThrowArrow(_arrowSpawnPointTransform.position, hitInfo.point);
            RemoveShell();
        }
    }


    public void AddShell()
    {
        _shellsCount++;
        Mathf.Clamp(_shellsCount, 0, _maxShellsCount);

        _shellController.AddShell(_shellsCount);
    }


    public void RemoveShell()
    {
        _shellController.RemoveShell(_shellsCount);

        _shellsCount--;
        Mathf.Clamp(_shellsCount, 0, _maxShellsCount);
    }
}
