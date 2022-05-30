using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectData : MonoBehaviour {
    [SerializeField]
    public string nameObject;

    public bool isCreature;

    [SerializeField]
    public string data;

    public float energy;

    [SerializeField]
    public float maxEnergy;

    [SerializeField]
    public LayerMask canSelectToShowLayer;

    public GameObject canvasGO;

    CanvasGroup canvasUI;

    public Slider slider;

    private bool playerInRange = false;

    // Start is called before the first frame update
    void Start () {

        energy = maxEnergy;
        slider.value = CalculateEnergy ();
        canvasUI = canvasGO.GetComponent<CanvasGroup> ();
        Hide ();
    }

    // Update is called once per frame
    void Update () {
        // if (Input.GetMouseButtonDown (0)) {
        //     Vector2 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        //     RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero, 20f, canSelectToShowLayer);
        //     if (hit.collider == gameObject.GetComponent<Collider2D> ()) {
        //         PlayerIsNow pin = FindObjectOfType<PlayerIsNow> ();
        //         if (pin.creatureNumber == 0) {
        //             PopUpSystem pop = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<PopUpSystem> ();
        //             pop.PopUp (data, nameObject);
        //         }
        //     }
        // }

        if (playerInRange) {
            if (energy < maxEnergy) {
                slider.value = CalculateEnergy ();
            }

            if (energy <= 0) {
                Destroy (gameObject);
            }
            if (energy > maxEnergy) energy = maxEnergy;

            if (Input.GetKeyDown (KeyCode.Space)) {
                Debug.Log ("NAm NAm");
                PlayerIsNow pin = FindObjectOfType<PlayerIsNow>();
                if(pin.creatureNumber != 0){
                    PlayerData PD = FindObjectOfType<PlayerData>();
                    PD.MofifyEnergyPoints(1);
                    energy--;
                } else {
                    playerInRange = false;
                }
            }
        }
    }

    float CalculateEnergy () {
        return energy / maxEnergy;
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.tag == "ant") {
            playerInRange = true;
            Show ();
        }
    }

    private void OnTriggerExit2D (Collider2D other) {
        if (other.tag == "ant") {
            playerInRange = true;
            Hide ();
        }
    }

    void Hide () {
        canvasUI.alpha = 0f;
    }

    void Show () {
        canvasUI.alpha = 1f;
    }

}