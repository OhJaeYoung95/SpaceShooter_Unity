using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public Transform bg1;
    public Transform bg2;

    private Vector3 startPos;
    private Vector3 endPos;

    private float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        endPos = bg1.transform.position;
        startPos = endPos * 2;
    }

    // Update is called once per frame
    void Update()
    {
        bg1.transform.localPosition += Vector3.down * speed * Time.deltaTime;
        bg2.transform.localPosition += Vector3.down * speed * Time.deltaTime;

        if(Vector3.Distance(bg1.transform.localPosition, endPos) < 0.1f)
        {
            bg1.transform.localPosition = startPos;
        }
        if(Vector3.Distance(bg2.transform.localPosition, endPos) < 0.1f)
        {
            bg2.transform.localPosition = startPos;
        }
    }
}
