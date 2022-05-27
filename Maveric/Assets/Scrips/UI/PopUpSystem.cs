using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpSystem : MonoBehaviour {
    // Start is called before the first frame update
    public Animator animator;
    public TMP_Text popUpText;
    public TMP_Text popUpTitle;

    public bool isOpen = false;

    public void PopUp (string text, string title) {
        popUpText.text = text;
        popUpTitle.text = title;
        animator.SetTrigger ("pop");
        isOpen = true;
    }

    public void Close(){
        isOpen = false;
        Debug.Log("Sulkeutuu");
    }

}