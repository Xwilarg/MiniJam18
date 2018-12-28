using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform toFollow;

    private void Update()
    {
        float x = toFollow.position.x;
        if (x < 0f)
            x = 0f;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
