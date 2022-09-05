using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private Transform _childModel;

    private CharacterController _personCharacterController;

    private float _speed = 0f;
    private float _debufSpeed = 0.01f;
    private bool _isMoving = false;


    private void Start()
    {
        _personCharacterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (_isMoving)
        {
            _personCharacterController.Move(transform.forward * Time.deltaTime * _speed);
            _childModel.Rotate( 1f, 0f, 0f);
            _speed -= _debufSpeed;
            if(_speed <= 0f)
            {
                _isMoving = false;
            }
        }
    }

    private void OnMouseDrag()
    {

        Ray rayFromMouse = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rayFromMouse, out RaycastHit hitInfo, 1000f))
        {

            Vector3 dir = hitInfo.point - transform.position;
            dir = new Vector3(dir.x, 0, dir.z);
            transform.rotation = Quaternion.LookRotation(dir);
            _childModel.rotation = Quaternion.Euler(0f, 0f, 0f);

            _speed = Vector3.Distance(transform.position, hitInfo.point) * 2;
        }


        Debug.DrawRay(transform.position, hitInfo.point, color: Color.green);
        Debug.DrawRay(transform.position, transform.forward * 100f, Color.black);
        //Debug.Log(_speed);
    }

    private void OnMouseUp()
    {
        _isMoving = true;
    }

    private void OnControllerColliderHit(ControllerColliderHit hitObject)
    {
        Ray rayFromBall = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(rayFromBall, out RaycastHit hitInfo, 1f))
        {
            Vector3 reflectDir = Vector3.Reflect(rayFromBall.direction, hitInfo.normal);
            float deg = 90 - Mathf.Atan2(reflectDir.z, reflectDir.x) * Mathf.Rad2Deg;
            transform.eulerAngles = new Vector3(0, deg, 0);
        }

    }


}
