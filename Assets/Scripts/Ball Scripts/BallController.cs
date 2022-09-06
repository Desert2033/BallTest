using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private BallModel _ballModel;

    private bool _isPressure = true;

    private void Update()
    {
        if (!_ballModel.PseudoPhysics .PseudoAddForce())
        {
            _isPressure = true;
        }
        else
        {
            BallEvents.StartMovingBall.Invoke();
        }
    }

    private void OnMouseDrag()
    {
        if (_isPressure)
        {
            Ray rayFromMouse = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(rayFromMouse, out RaycastHit hitInfo, 1000f))
            {
                this.FollowForMouse(hitInfo.point);

                BallEvents.MouseDragBall?.Invoke(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z);
                
                _ballModel.SetSpeedByDistance(transform.position, hitInfo.point);
            }
        }
    }

    private void FollowForMouse(Vector3 hitPoint)
    {
        Vector3 dir = hitPoint - transform.position;

        dir = new Vector3(dir.x, 0, dir.z);

        transform.rotation = Quaternion.LookRotation(dir);

        _ballModel.TextureBall.rotation = Quaternion.Euler(0f, 0f, 0f);
    } 

    private void OnMouseUp()
    {
        if (_isPressure)
        {
            _ballModel.PseudoPhysics.SetSpeed(_ballModel.Speed);

            _ballModel.TextureBall.rotation = transform.rotation;

            _isPressure = false;

            BallEvents.MouseUpBall?.Invoke();
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hitObject)
    {
        Ray rayFromBall = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(rayFromBall, out RaycastHit hitInfo, 1f, LayerMask.GetMask("Wall")))
        {
            _ballModel.PseudoPhysics.Ricochet(rayFromBall, hitInfo);

            BallEvents.BlowOnWallEvent?.Invoke();
        }

    }


}
