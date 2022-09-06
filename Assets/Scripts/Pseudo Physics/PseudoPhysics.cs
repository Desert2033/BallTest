using UnityEngine;

public class PseudoPhysics
{

    private CharacterController _objectCharacterController;
    private Transform _objectTransform;
    private float _speed = 0f;
    private float _debufSpeed = 0.01f;

    public PseudoPhysics(CharacterController objectCharacterController, float speed)
    {
        _objectCharacterController = objectCharacterController;
        _objectTransform = objectCharacterController.transform;
        _speed = speed;
    }

    public bool PseudoAddForce()
    {
        if (_speed > 0)
        {
            _objectCharacterController.Move(_objectTransform.forward * Time.deltaTime * _speed);
            _speed -= _debufSpeed;
        }

        return _speed > 0;
    }

    public void Ricochet(Ray rayFromObject, RaycastHit hitInfo)
    {
        Vector3 reflectDir = Vector3.Reflect(rayFromObject.direction, hitInfo.normal);
        float deg = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
        deg = deg == 0 ? 30 : deg;
        _objectTransform.eulerAngles = new Vector3(0, deg, 0);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
