using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax_efect : MonoBehaviour
{
    [SerializeField] GameObject camera_fl;
    [SerializeField] Vector2 speed;
    Vector3 lastpositioncamera;
    private void Start()
    {
        lastpositioncamera=camera_fl.transform.position;
        transform.position = new Vector2(transform.position.x,camera_fl.transform.position.y);    }
    private void LateUpdate()
    {

        Vector3 deltaposition = camera_fl.transform.position - lastpositioncamera;
        transform.position += new Vector3(deltaposition.x*speed.x,deltaposition.y*speed.y);
        lastpositioncamera = camera_fl.transform.position;
    }
}
