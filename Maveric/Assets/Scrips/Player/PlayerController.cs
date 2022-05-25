using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    Vector2 rawInput;
    
    [SerializeField]
    public LayerMask canSelectToShowLayer;


    void Update()
    {
        Move();
        
        if(Input.GetMouseButtonDown(0)){ 
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, 20f, canSelectToShowLayer);
            if(hit.collider != null) {
                Debug.Log("osui");
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
