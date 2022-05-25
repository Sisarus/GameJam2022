using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;

    Vector2 rawInput;

    public bool takingOver;

    [HideInInspector]
    public Vector3 newPos;

    void Update()
    {
        if(!takingOver) Move();
        if(takingOver){
            transform.position = Vector2.MoveTowards (transform.position, newPos, moveSpeed * 2 * Time.deltaTime);
            if (transform.position == newPos) {
                takingOver = false;
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
