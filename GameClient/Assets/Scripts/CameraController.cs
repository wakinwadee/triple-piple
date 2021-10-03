using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    public Transform targetTransform;
    [Range(0f, 100f)]
    public float distanceFromTarget;
    [Range(0f, 90f)]
    public float viewPointAngle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 offset = new Vector3(0f,
                                     distanceFromTarget * Mathf.Sin(viewPointAngle * Mathf.Deg2Rad),
                                     distanceFromTarget * Mathf.Cos(viewPointAngle * Mathf.Deg2Rad));
        Camera.main.transform.position = targetTransform.transform.position + offset;
        Camera.main.transform.LookAt(targetTransform);
        
    }
}
