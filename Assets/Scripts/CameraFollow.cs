using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform _target;

    private Vector3 _offset = new Vector3(0, 13, -5);

    private void Update()
    {
        transform.position = _target.position + _offset;
    }

}
