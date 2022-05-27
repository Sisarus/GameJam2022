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

    public GameObject energyBarUI;

    public Slider slider;

    // Start is called before the first frame update
    void Start () {
        energy = maxEnergy;
        if (!isCreature) {
            slider.value = CalculateEnergy ();
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown (0)) {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero, 20f, canSelectToShowLayer);
            if (hit.collider == gameObject.GetComponent<Collider2D> ()) {
                PlayerIsNow pin = FindObjectOfType<PlayerIsNow> ();
                if (pin.creatureNumber == 0) {
                    PopUpSystem pop = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<PopUpSystem> ();
                    pop.PopUp (data, nameObject);
                }
            }
        }

        if (!isCreature) {
            if (energy < maxEnergy) {
                energyBarUI.SetActive (true);
                slider.value = CalculateEnergy ();
            }

            if (energy <= 0) {
                Destroy (gameObject);
            }
            if (energy > maxEnergy) energy = maxEnergy;
        }
    }

    float CalculateEnergy () {
        return energy / maxEnergy;
    }

}