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

    private Vector2 _lastCurvePoint;




    private void Update()
    {
        if (_canMove) Move();
    }


    public void ThrowArrow(Vector3 targetPostion)
    {
        _startPositon = transform.position;
        _targetPostion = targetPostion;
        _canMove = true;
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


        /*Vector2 currentCurvePoint = new Vector2(_t, _arrowFlyingYTrajectory.Evaluate(_t));
        Vector2 delta = currentCurvePoint - _lastCurvePoint;

        float angel = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angel);
        _lastCurvePoint = currentCurvePoint;*/



        transform.position = movePostion;

        _experiedSeconds += Time.deltaTime;
    }
}
