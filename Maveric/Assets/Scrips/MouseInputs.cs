using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputs : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            Debug.Log("Click hiiri");
        }
    }
}
