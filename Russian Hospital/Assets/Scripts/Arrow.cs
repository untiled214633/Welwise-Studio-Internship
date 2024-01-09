using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private AnimationCurve _arrowFlyingYTrajectory;
    [SerializeField] private float _arrowFlyingDuration;

    private float _t = 0;
    private float _experiedSeconds = 0;

    private Vector3 _startPositon;
    private Vector3 _targetPostion;
    private bool _canMove;




    private void Update()
    {
        if (_canMove) Move();
    }


    public void ThrowArrow(Vector3 targetPostion)
    {
        _startPositon = transform.position;
        _targetPostion = targetPostion;
        RotateToTarget();

        _canMove = true;
    }


    private void RotateToTarget()
    {
        Vector3 delta = _targetPostion - _startPositon;
        float yAngel = Mathf.Atan2(delta.normalized.x, delta.normalized.z) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, yAngel, 0);
    }


    private void Move()
    {
        _t = _experiedSeconds / _arrowFlyingDuration;

        if (_t > 1)
        {
            _t = 1;
            _canMove = false;
            _rigidbody.isKinematic = false;
        }

        Vector3 movePostion = Vector3.Lerp(_startPositon, _targetPostion, _t);
        movePostion += new Vector3(0, _arrowFlyingYTrajectory.Evaluate(_t), 0);

        transform.position = movePostion;

        _experiedSeconds += Time.deltaTime;
    }
}
