using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;
    private const float speed = 200f;
    private bool goLeft;
    private const float leftLimit = 1f;
    private const float holeLimit = 2f;

    private Vector2 spawnPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        goLeft = true;
        spawnPos = transform.position;
    }

    private void Update()
    {
        rb.velocity = new Vector2(speed * Time.deltaTime * ((goLeft) ? (-1f) : (1f)), rb.velocity.y);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left * ((goLeft) ? (1f) : (-1f)), leftLimit, 1 << 8);
        if (hit.distance > float.Epsilon)
            goLeft = !goLeft;
        hit = Physics2D.Raycast(transform.position, Vector2.left * ((goLeft) ? (1f) : (-1f)) + Vector2.down, holeLimit, 1 << 8);
        if (hit.distance < float.Epsilon)
            goLeft = !goLeft;
    }

    public void ResetAll()
    {
        transform.position = spawnPos;
        goLeft = true;
    }
}
