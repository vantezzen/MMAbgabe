using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Transform target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentLocation = transform.position;
        Vector3 targetPosition = target.position;

        float distance = Vector3.Distance(currentLocation, targetPosition);
        float progress = (speed / 1000) / distance;

        Vector3 moveToPosition = Vector3.Lerp(currentLocation, targetPosition, progress);
        transform.position = moveToPosition;
        transform.LookAt(target);
    }
}
