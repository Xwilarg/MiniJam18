using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CameraFollow camFollow;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private const float speed = 300f;
    private const float jumpMinDist = .5f;
    private const float jumpForce = 5f;

    private List<GameObject> colliders;

    private bool inDream;

    private NPC npcInterraction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        npcInterraction = null;
        colliders = new List<GameObject>();
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
            inDream = !inDream;
            camFollow.enabled = !camFollow.enabled;
            npcInterraction.transform.GetChild(0).gameObject.SetActive(false);
            if (colliders.Count > 0)
            {
                foreach (GameObject go in colliders)
                    Destroy(go);
                colliders.RemoveAll(x => true);
            }
            else
            {
                GameObject go = new GameObject("Collider left", typeof(BoxCollider2D));
                go.transform.position = new Vector2(Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, 10f)).x, 0f);
                go.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 10f);
                colliders.Add(go);
                go = new GameObject("Collider right", typeof(BoxCollider2D));
                go.transform.position = new Vector2(Camera.main.ViewportToWorldPoint(new Vector3(1f, 0f, 10f)).x, 0f);
                go.GetComponent<BoxCollider2D>().size = new Vector2(0.01f, 10f);
                colliders.Add(go);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inDream)
            return;
        if (collision.CompareTag("NPC"))
        {
            npcInterraction = collision.GetComponent<NPC>();
            collision.transform.GetChild(0).gameObject.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (inDream)
            return;
        if (collision.CompareTag("NPC"))
        {
            npcInterraction = null;
            collision.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
