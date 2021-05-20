using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomObjects : MonoBehaviour
{
    public Transform coin;
    public Transform boden;

    public float range = 4;

    // Start is called before the first frame update
    void Start()
    {
        // Erzuge 10 Coins mit Rotation
        for(int i = 0; i < 10; i++) {
            Transform coinObj = Instantiate(coin, coin.transform.position, Quaternion.identity, boden);
            
            coinObj.localPosition = new Vector3(
                coinObj.localPosition.x + Random.Range(-1 * range, range),
                coinObj.localPosition.y,
                coinObj.localPosition.z + Random.Range(-1 * range, range)
            );

            coinObj.transform.localRotation = Quaternion.Euler(Random.Range(0, 365), Random.Range(0, 365), Random.Range(0, 365));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}