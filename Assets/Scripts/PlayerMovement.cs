using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRigid;
    public float moveSpeed = 10f;

    public float posXClampMin = -9f;
    public float posXClampMax = 9f;
    public float posYClampMin = -8.6f;
    public float posYClampMax = 25.4f;

    private void Awake()
    {
        playerRigid = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(PlayerInput.instance.IsMove)
        {
            Vector3 movePos = Vector3.Lerp(playerRigid.position, PlayerInput.instance.CurrentPos, moveSpeed * Time.deltaTime);
            movePos.x = Mathf.Clamp(movePos.x, posXClampMin, posXClampMax);
            movePos.y = Mathf.Clamp(movePos.y, posYClampMin, posYClampMax);
            playerRigid.MovePosition(movePos);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
