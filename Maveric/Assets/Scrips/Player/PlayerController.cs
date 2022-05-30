using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{

    [SerializeField] float moveSpeed = 5f;
    
    [HideInInspector]
    Vector2 rawInput;

    [HideInInspector]
    public bool takingOver;

    [HideInInspector]
    public bool changeToCreature = false;

    [HideInInspector]

    public Vector3 newPos;

    public float HorizontalValue;
    public bool facingRight;

    void Update()
    {
        if(!takingOver) Move();
        if(takingOver){
            transform.position = Vector2.MoveTowards (transform.position, newPos, moveSpeed * 2 * Time.deltaTime);
            if (transform.position == newPos) {
                changeToCreature = true;
                takingOver = false;
            }
        }
        FlipSprite();
    }

    void Move(){
        Vector3 delta = rawInput * moveSpeed * Time.deltaTime;
        transform.position += delta;
        HorizontalValue = rawInput.x;
    }

    void OnMove(InputValue value){
        rawInput = value.Get<Vector2>();
    }

    void FlipSprite(){
        if(HorizontalValue < 0 && !facingRight || HorizontalValue > 0 && facingRight){
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }
}
