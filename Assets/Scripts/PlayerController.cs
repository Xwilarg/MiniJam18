using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private const float speed = 300f;
    private const float jumpMinDist = .5f;
    private const float jumpForce = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * speed, rb.velocity.y);
        if (rb.velocity.x < -float.Epsilon)
            sr.flipX = true;
        else if (rb.velocity.x > float.Epsilon)
            sr.flipX = false;
        if (Input.GetButtonDown("Jump"))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, jumpMinDist, 1 << 8);
            if (hit.distance > float.Epsilon)
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
