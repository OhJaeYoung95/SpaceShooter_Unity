using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class RotateRing : MonoBehaviour
{
    public GameObject outRing;
    public float rotateSpeed =5f;
    public float zRotate;

    private void Start()
    {

        zRotate = outRing.transform.rotation.z;
        //zRotate = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        if (zRotate < -360)
            zRotate += 360;
        zRotate -= rotateSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, zRotate));
        outRing.transform.rotation = rotation;
    }
}
