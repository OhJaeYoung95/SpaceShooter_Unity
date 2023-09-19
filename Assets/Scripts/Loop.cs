using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loop : MonoBehaviour
{
    private float height;
    private void Awake()
    {
        var boxCollider = GetComponent<BoxCollider2D>();
        height = boxCollider.size.y;
    }

    private void Update()
    {
        if ((transform.position.y < -height))
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        var offset = new Vector2(0, height * 2f);
        transform.position = (Vector2)transform.position + offset;
    }
}
