using UnityEngine;

public class ArrowsThrower : MonoBehaviour
{
    [SerializeField] private AnimationCurve _arrowFlyingYTrajectory;
    [SerializeField] private float _arrowFlyingDuration;

    //test field
    private float _t = 0;
    private float _experiedSeconds = 0;
    private Vector3 _startPositon;
    private Vector3 _targetPostion;
    private bool _canMove;




    private void Update()
    {
        if (_canMove) Move();
    }


    public void MoveArrow(Vector3 targetPostion)
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
        }


        Vector3 movePostion = Vector3.Lerp(_startPositon, _targetPostion, _t);
        movePostion += new Vector3(0, _arrowFlyingYTrajectory.Evaluate(_t), 0);

        transform.position = movePostion;

        _experiedSeconds += Time.deltaTime;
    }
}
