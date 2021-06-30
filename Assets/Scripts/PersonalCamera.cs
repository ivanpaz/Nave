using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalCamera : MonoBehaviour
{

    [SerializeField]
    Transform target ;

    [SerializeField]
    Transform camPoint;

    float distance = 10f;
    float rotSpeed = 5f;

    Vector3 camPosition;

    Vector3 smoothTransition;

    float smoothTime = 1f;
    float angle;

       
       
    void FixedUpdate()
    {
        CameraFinal();
    }

    void CameraFixa()
    {
        transform.position = camPoint.position;
        transform.rotation = camPoint.rotation;
    }

    void CameraTop()
    {
        transform.position = target.position + target.up * distance + target.forward * (distance * 0.3f);
        transform.rotation = target.rotation * Quaternion.Euler(90f, 0, 0);
    }

    void CameraFinal()
    {
        camPosition = target.position - (target.forward * distance) + target.up * distance /3;
        smoothTransition = Vector3.Lerp(transform.position, camPosition, smoothTime);
        transform.position = smoothTransition;

        angle = Mathf.Abs(Quaternion.Angle(transform.rotation, target.rotation));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target.rotation, (rotSpeed + angle ) * Time.deltaTime);
    }


}
