using UnityEngine;

public class BallView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleBlowOnWall;

    [SerializeField] private BallModel _ballModel;

    private LineRenderer _line;

    private Animation _animationBall;

    private void Start()
    {
        _animationBall = GetComponent<Animation>();

        _line = GetComponent<LineRenderer>();

        BallEvents.BlowOnWallEvent.AddListener(BlowOnWallEffects);

        BallEvents.StartMovingBall.AddListener(RotateBall);

        BallEvents.MouseDragBall.AddListener(LineRenderDraw);

        BallEvents.MouseUpBall.AddListener(LineRenderDisable);
    }

    public void BlowOnWallEffects()
    {
        _animationBall.Play();

        _particleBlowOnWall.transform.position = transform.position;

        _particleBlowOnWall.Play();

        _ballModel.TextureBall.rotation = transform.rotation;
    }

    public void RotateBall()
    {
        _ballModel.TextureBall.Rotate(1f, 0f, 0f);
    }

    public void LineRenderDraw(float x, float y, float z)
    {
        _line.positionCount = 2;
        Vector3 secondVector = new Vector3(x, y + 1f, z);
        _line.SetPosition(0, transform.position);
        _line.SetPosition(1, secondVector);
    }

    public void LineRenderDisable()
    {
        _line.positionCount = 0;
    }

}
