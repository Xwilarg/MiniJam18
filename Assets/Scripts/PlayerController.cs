using System.Collections.Generic;
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

    private DreamManager dm;

    private NPC npcInterraction;

    [SerializeField]
    private bool isMain;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        dm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DreamManager>();
        npcInterraction = null;
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isMain)
                dm.LoadMain();
            else if (npcInterraction != null)
            {
                dm.LoadScene(npcInterraction.Id);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC"))
        {
            npcInterraction = collision.GetComponent<NPC>();
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
    }
}
