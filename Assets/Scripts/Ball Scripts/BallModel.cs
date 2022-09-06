using UnityEngine;

public class BallModel : MonoBehaviour
{

    [SerializeField] private Transform _textureBall;

    [SerializeField] private CharacterController _ballCharacterController;

    private PseudoPhysics _pseudoPhysics;

    private float _speed = 0f;

    private float _speedMax = 20f;


    public Transform TextureBall => _textureBall;

    public CharacterController BallCharacterController => _ballCharacterController;

    public PseudoPhysics PseudoPhysics => _pseudoPhysics;

    public float Speed => _speed;


    private void Awake()
    {
        _pseudoPhysics = new PseudoPhysics(_ballCharacterController, _speed);
    }

    public void SetSpeed(float speed) 
    {
        _speed = _speedMax >= speed ? speed : _speedMax;
    }
    
    public void SetSpeedByDistance(Vector3 firstVector, Vector3 secondVector) 
    {
        this.SetSpeed(Vector3.Distance(firstVector, secondVector) * 2);
    }


}
