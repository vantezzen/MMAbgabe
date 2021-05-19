using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRandomObjects : MonoBehaviour
{
    public Transform coin;
    public GameObject boden;

    public float range = 4;

    // Start is called before the first frame update
    void Start()
    {
        // Erzuge 10 Coins mit Rotation
        for(int i = 0; i < 10; i++) {
            Transform coinObj = Instantiate(coin, boden.transform.position, Quaternion.identity);
            
            // coinObj.transform.SetParent(coin.transform);
            coinObj.localPosition = new Vector3(
                coinObj.localPosition.x + Random.Range(-1 * range / 1000, range / 1000),
                coinObj.localPosition.y,
                coinObj.localPosition.z + Random.Range(-1 * range / 1000, range / 1000)
            );

            coinObj.transform.localRotation = Quaternion.Euler(Random.Range(0, 365), Random.Range(0, 365), Random.Range(0, 365));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}