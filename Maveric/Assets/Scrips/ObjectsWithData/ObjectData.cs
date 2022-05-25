using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectData : MonoBehaviour
{
    [SerializeField]
    public string nameObject;

    [SerializeField]
    public string data;

    [SerializeField]
    public float energy;

    [SerializeField]
    public float eatedLevel;

        
    [SerializeField]
    public LayerMask canSelectToShowLayer;

    [Header("Player Control")]
    [SerializeField] bool playerCanControl = false;

    bool isPopUpShowing = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){ 
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, 20f, canSelectToShowLayer);
            if(hit.collider == gameObject.GetComponent<Collider2D>()) {
                PopUpSystem pop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PopUpSystem>();
                pop.PopUp(data, nameObject);
            }
        }
    }

}
