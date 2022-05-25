using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUpSystem : MonoBehaviour
{
    public GameObject popUpBoxPrefab;

    public Animator animator;
    public TMP_Text popUpText;

    public TMP_Text popUpTitle;

    public void PopUp(string text, string title){
        popUpText.text = text;
        popUpTitle.text = title;
        animator.SetTrigger("pop");
    }

}
