using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;
    public Vector3 CurrentPos { get; private set; }
    public bool IsMove { get; private set; }
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            IsMove = true;

        if (Input.GetButtonUp("Fire1"))
            IsMove = false;

        if (Input.GetButton("Fire1"))
        {
            //Debug.Log(Input.mousePosition);
            CurrentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
    }
}
