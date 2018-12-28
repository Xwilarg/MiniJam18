﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private const float speed = 300f;
    private const float jumpMinDistY = .5f;
    private const float jumpMinDistX = .4f;
    private const float jumpForce = 5f;
    private const float wallJumpForce = 25f;
    private const float xDrag = 1.1f;

    private DreamManager dm;

    private NPC npcInterraction;

    private float externalX;

    [SerializeField]
    private bool isMain;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        dm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<DreamManager>();
        npcInterraction = null;
        externalX = 0f;
    }

    private enum XDirection
    {
        None,
        Left,
        Right
    }

    private void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * speed + externalX, rb.velocity.y);
        externalX /= xDrag;
        XDirection dir = XDirection.None;
        if (rb.velocity.x < -float.Epsilon)
        {
            sr.flipX = true;
            dir = XDirection.Left;
        }
        else if (rb.velocity.x > float.Epsilon)
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
            if (raycastDir != null)
            {
                RaycastHit2D hitWall = Physics2D.Raycast(transform.position, raycastDir.Value, jumpMinDistX, 1 << 8);
                if (hitWall.distance > float.Epsilon)
                {
                    externalX += -raycastDir.Value.x * wallJumpForce;
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
            }
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, jumpMinDistY, 1 << 8);
            if (hit.distance > float.Epsilon)
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isMain)
                dm.LoadMain();
            else if (npcInterraction != null)
                dm.LoadScene(npcInterraction.Id);
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
