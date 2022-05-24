using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    Vector2 rawInput;
    
    [SerializeField]
    public LayerMask objectLayer;
    [SerializeField]

    void Update()
    {
        Move();
        
        if(Input.GetMouseButtonDown(0)){ 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.green, 2f); // only draws once. Re-clicking does nothing
            Debug.Log("mouse clicked"); 

            Debug.Log(Input.mousePosition);
            if (Physics.Raycast(ray, Mathf.Infinity)) {
                Debug.Log("You selected the ");
            } else {
                Debug.Log("ei toimi");
            }

        }
    }


    void Move(){
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
    }

    void OnMove(InputValue value){
        rawInput = value.Get<Vector2>();
        
    }
}
