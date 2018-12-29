using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private const float speed = 300f;
    private const float jumpMinDistY = .5f;
    private const float jumpMinDistX = .4f;
    private const float jumpForce = 5f;
    private const float wallJumpForce = 25f;
    private const float xDrag = 1.1f;

    private DreamManager dm;

    private NPC npcInterraction;
    private Interruptor inter;

    private float externalX;

    [SerializeField]
    private bool isMain;

    private Vector2 spawnPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        npcInterraction = null;
        inter = null;
        externalX = 0f;
        spawnPos = transform.position;
        dm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DreamManager>();
    }

    private enum XDirection
    {
        None,
        Left,
        Right
    }

    private bool CompareFloat(float x, float value)
    {
        return (x > (value - .01f) && x < (value + .01f));
    }

    private void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * speed + externalX, rb.velocity.y);
        externalX /= xDrag;
        XDirection dir = XDirection.None;

        if (rb.velocity.x > 0.1f || rb.velocity.x < -0.1f && CompareFloat(rb.velocity.y, 0)) {
            anim.SetBool("moving", true);
        } else {
            anim.SetBool("moving", false);
        }

        if (CompareFloat(rb.velocity.y, 0)) {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", false);

        }
        else if (rb.velocity.y > 0) {
            anim.SetBool("jumping", true);
        }
        else {
            anim.SetBool("jumping", false);
            anim.SetBool("falling", true);
        }

        if (rb.velocity.x < -1)
        {   
            sr.flipX = true;
            dir = XDirection.Left;
        }
        else if (rb.velocity.x > 1)
        {
            sr.flipX = false;
            dir = XDirection.Right;
        }
        if (Input.GetButtonDown("Jump"))
        {
            
            Vector2? raycastDir = null;
            if (dir == XDirection.Right)
                raycastDir = transform.right;
            else if (dir == XDirection.Left)
                raycastDir = -transform.right;
            bool isDone = false;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, jumpMinDistY, 1 << 8);
            bool onFloor = (hit.distance > float.Epsilon);
            if (raycastDir != null && !onFloor)
            {
                RaycastHit2D hitWall = Physics2D.Raycast(transform.position, raycastDir.Value, jumpMinDistX, 1 << 8);
                if (hitWall.distance > float.Epsilon)
                {
                    externalX += -raycastDir.Value.x * wallJumpForce;
                    rb.velocity = new Vector2(rb.velocity.x, 0f);
                    rb.AddForce(Vector2.up * jumpForce * 1.75f, ForceMode2D.Impulse);
                    isDone = true;
                }
            }
            if (!isDone && onFloor)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isMain)
            {
                Die();
                dm.LoadMain();
            }
            else if (npcInterraction != null)
                dm.LoadScene(npcInterraction.Id);
        }
        if (Input.GetKeyDown(KeyCode.Q) && inter != null)
        {
            inter.Activate();
        }
    }

    private void Die()
    {
        transform.position = spawnPos;
        if (inter != null)
        {
            inter.transform.GetChild(0).gameObject.SetActive(false);
            inter = null;
        }
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Spikes"))
        {
            var c = go.GetComponent<EnemyController>();
            if (c != null)
                c.ResetAll();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            npcInterraction = collision.GetComponent<NPC>();
            collision.transform.GetChild(0).gameObject.SetActive(true);
        }
        else if (collision.CompareTag("Spikes"))
            Die();
        else if (collision.CompareTag("Button"))
        {
            inter = collision.GetComponent<Interruptor>();
            collision.transform.GetChild(0).gameObject.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            npcInterraction = null;
            collision.transform.GetChild(0).gameObject.SetActive(false);
        }
        else if (collision.CompareTag("Button"))
        {
            inter = null;
            collision.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
