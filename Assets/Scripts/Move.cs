using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    [SerializeField] private float _speed = 10f;
    [SerializeField] private CharacterController _personCharacterController;

    void Update()
    {
        Vector3 mousePositionScreen = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f);
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);

        Ray ray = new Ray(transform.position, mousePositionWorld);

        RaycastHit hit;
        Debug.Log(mousePositionWorld);

        Debug.DrawRay(transform.position, mousePositionWorld, color: Color.red);
        if (Input.GetMouseButton(0))
        {
            Debug.Log(transform.position - mousePositionWorld);
        //    Debug.Log(mousePositionWorld);
            /*if(Physics.Raycast())
            {

            }*/
        }
    }

    private void OnMouseDrag()
    {
        // Vector3 vector3 = new Vector3(0, 0, 1);
        // _personCharacterController.Move(vector3 * Time.deltaTime * _speed);

        Ray ray = new Ray(transform.position, transform.forward);
        
        Debug.DrawRay(transform.position,transform.forward * 100f, color: Color.red);
    }
}
