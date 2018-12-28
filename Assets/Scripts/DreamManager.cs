using UnityEngine;

public class DreamManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainWorld;

    [SerializeField]
    private GameObject[] dreams;

    private GameObject current;

    private void Start()
    {
        mainWorld.SetActive(true);
        foreach (GameObject go in dreams)
            go.SetActive(false);
        current = mainWorld;
    }

    public void LoadMain()
    {
        current.SetActive(false);
        mainWorld.SetActive(true);
        current = mainWorld;
    }

    public void LoadScene(int id)
    {
        current.SetActive(false);
        current = dreams[id];
        current.SetActive(true);
    }
}
