using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBMovingController : MonoBehaviour
{
    public Transform player;
    public Transform ButtonObject;
    public float bewegung;

    /// <summary>
    /// Called when the scene is loaded
    /// </summary>
    void Start() {
        gameObject.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
    }
    void resetColor() {
        ButtonObject.GetComponent<Renderer>().material.color = Color.black;
    }

    /// <summary>
    /// Called when the virtual button has just been pressed:
    /// </summary>
    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        // Bewegen
        player.transform.position += player.transform.forward * bewegung;
        ButtonObject.GetComponent<Renderer>().material.color = Color.blue;
        Invoke("resetColor", 1);
    }
}
