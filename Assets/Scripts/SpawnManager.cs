using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<BoxCollider2D> rooms;
    [SerializeField] private List<GameObject> spawnObject;
    //  [SerializeField] private List<GameObject> targets;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void CreateObjects()
    {
        foreach (GameObject i in spawnObject)
        {
            int randomRoom = Random.Range(0, rooms.Count);
            Vector3 point = RandomPointInBounds(rooms[randomRoom].bounds);
            Instantiate(i, point, i.transform.rotation);
        }
    }

    private static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            0
        );
    }
}
