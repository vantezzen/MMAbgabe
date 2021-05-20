using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VBRotationController : MonoBehaviour
{
    public Transform player;
    public Transform ButtonObject;
    public float bewegung;

    private bool isPressed = false;

    /// <summary>
    /// Called when the scene is loaded
    /// </summary>
    void Start() {
        gameObject.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        gameObject.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
    }
    void FixedUpdate() {
        if (isPressed) {
            // Drehen
            player.Rotate(new Vector3(0, bewegung / 100, 0));
        }
    }

    /// <summary>
    /// Called when the virtual button has just been pressed:
    /// </summary>
    public void OnButtonPressed(VirtualButtonBehaviour vb) {
        isPressed = true;
        ButtonObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) {
        isPressed = false;
        ButtonObject.GetComponent<Renderer>().material.color = Color.black;
    }
}
