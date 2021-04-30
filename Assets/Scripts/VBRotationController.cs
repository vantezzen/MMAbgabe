using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBRotationController : MonoBehaviour
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
        // Rotieren
        player.Rotate(new Vector3(0, bewegung, 0));
        ButtonObject.GetComponent<Renderer>().material.color = Color.blue;
        Invoke("resetColor", 1);
    }
}
