using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public float geschwindigkeit = 3f;
    public float drehGeschwindigkeit = 5f;

    private int gesammelt = 0;
    private float currentRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * drehGeschwindigkeit;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * geschwindigkeit;

        // Testkommandos
        //transform.Rotate(0, moveHorizontal, 0);
        //float angle = transform.forward.y + moveHorizontal;
        //transform.position += transform.forward * moveVertical;

        // Finde heraus, wo das neue "Vorne" ist mit Hilfe der Formeln
        currentRotation += moveHorizontal;
        Vector3 targetDirection = new Vector3(
            Mathf.Sin(currentRotation),
            0,
            Mathf.Cos(currentRotation)
        );
        Quaternion vorne = Quaternion.LookRotation(
            // Nach vorne
            targetDirection,
            // Nach oben
            Vector3.up
        );
        transform.rotation = vorne;

        // Bewegen
        transform.position += targetDirection * moveVertical;
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Coin")) {
            other.gameObject.SetActive(false);
            gesammelt++;
            Debug.Log(gesammelt);
        }
    }
}
