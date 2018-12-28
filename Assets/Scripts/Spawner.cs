using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject toSpawn;

    private const int maxCrate = 5;

    private List<GameObject> allGos;

    private void Start()
    {
        allGos = new List<GameObject>();
    }

    private void OnDisable()
    {
        foreach (GameObject go in allGos)
            Destroy(go);
        allGos = new List<GameObject>();
    }

    public void Spawn()
    {
        allGos.Add(Instantiate(toSpawn, transform.position, Quaternion.identity));
        if (allGos.Count > maxCrate)
        {
            Destroy(allGos[0]);
            allGos.RemoveAt(0);
        }
    }
}
