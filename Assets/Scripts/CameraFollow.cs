using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform toFollow;

    private Vector3 offset;

    private void Start()
    {
        offset = (Vector2)(transform.position - toFollow.position);
    }

    private void Update()
    {
        Vector2 pos = toFollow.position;
        if (pos.x < 0f)
            pos = new Vector2(0f, pos.y);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z) + offset;
    }
}
