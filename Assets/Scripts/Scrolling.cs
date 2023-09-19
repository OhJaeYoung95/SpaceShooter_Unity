using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public float speed = 5f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
