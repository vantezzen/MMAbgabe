using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomObjects : MonoBehaviour
{
    public Transform coin;

    // Start is called before the first frame update
    void Start()
    {
        // Erzuge 10 Coins mit Rotation
        for(int i = 0; i < 10; i++) {
            Transform coinObj = Instantiate(coin, new Vector3(
                Random.Range(-4, 4),
                3,
                Random.Range(-4, 4)
            ), Quaternion.identity);
            coinObj.transform.rotation = Quaternion.Euler(Random.Range(0, 365), Random.Range(0, 365), Random.Range(0, 365));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}