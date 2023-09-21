using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveTime;
    public float moveDuration;

    public float speed;

    public Vector2 targetPoint;

    private Vector2 prePos;
    private Vector2 nextPos;

    public Vector3 startPos;
    public Vector3 midPos;
    public Vector3 endPos;

    public Vector2 direction;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (moveTime < moveDuration)
        {
            Move();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveTime += Time.deltaTime;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        //Debug.Log(angle);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

    private void Move()
    {
        float t = moveTime / moveDuration;
        Vector2 pos = transform.position;
        targetPoint = CalculateBezierPoint(startPos, midPos, endPos, t);
        transform.position = targetPoint;

        direction = (targetPoint - pos).normalized;

    }

    private Vector2 CalculateBezierPoint(Vector2 start, Vector2 passingPos, Vector2 end, float t)
    {
        float u = 1.0f - t;
        float tt = t * t;
        float uu = u * u;
        float uuu = uu * u;
        float ttt = tt * t;

        Vector2 p = uuu * start;
        p += 3 * uu * t * passingPos;
        p += 3 * u * tt * end;
        p += ttt * end;
        return p;
    }

    public void SetWaveType(int waveType, Transform[] pos)
    {
        startPos = pos[0].position;
        midPos = pos[1].position;
        endPos = pos[2].position;
    }
}
