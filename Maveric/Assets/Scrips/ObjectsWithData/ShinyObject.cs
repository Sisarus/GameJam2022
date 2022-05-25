using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShinyObject : MonoBehaviour
{
    public GameObject VFX_Prefabs;
        public GameObject VFX_Prefabs_second;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero, 20f);
        if(hit.collider == gameObject.GetComponent<Collider2D>()) {
            VFX_Prefabs.SetActive(false);
            VFX_Prefabs_second.SetActive(true);
        } else{
            VFX_Prefabs.SetActive(true);
            VFX_Prefabs_second.SetActive(false);
        }
    }
}
