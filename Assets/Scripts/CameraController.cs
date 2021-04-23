using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offsetVector;

    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionGoal = target.TransformPoint(offsetVector);
        Vector3 currentPosition = transform.position;

        float distance = Vector3.Distance(currentPosition, positionGoal);
        float progress = speed / distance;

        transform.position = Vector3.Lerp(currentPosition, positionGoal, progress);
        transform.LookAt(target);
    }
}
