using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour
{
    [SerializeField] private List<GameObject> clues;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deactivateAll()
    {
        foreach (GameObject i in clues)
        {
            i.SetActive(false);
        }
    }

    public void ActivateClue(int i)
    {
        clues[i-1].SetActive(true);
    }
}
