using UnityEngine;

public class ArrowsThrower : MonoBehaviour
{
    [SerializeField] private AnimationCurve _arrowFlyingYTrajectory;
    [SerializeField] private float _arrowFlyingDuration;





    public void MoveArrow(Vector3 targetPostion)
    {
        float t = 0;
        float experiedSeconds = 0;

        t = experiedSeconds / _arrowFlyingDuration;
        experiedSeconds += Time.deltaTime;



        Vector3 movePostion = Vector3.Lerp(transform.position, targetPostion, t);

        movePostion += new Vector3(0, _arrowFlyingYTrajectory.Evaluate(t), 0);
    }
}
