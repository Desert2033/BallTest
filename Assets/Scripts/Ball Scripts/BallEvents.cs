using UnityEngine.Events;

public static class BallEvents
{

    public static UnityEvent BlowOnWallEvent = new UnityEvent();

    public static UnityEvent StartMovingBall = new UnityEvent();

    public static UnityEvent<float, float, float> MouseDragBall = new UnityEvent<float, float, float>();

    public static UnityEvent MouseUpBall = new UnityEvent();

}
