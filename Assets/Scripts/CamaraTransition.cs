using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraTransition : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private List<Transform> positions;
    [SerializeField] private float TransitionSpeed;
    [SerializeField] private GameObject Walls, WinUI, tutorialObjects;
    [SerializeField] private TimeController timeController;
    [SerializeField] private SpawnManager spawnManager;
    [SerializeField] private PuzzleManagment puzzleManagment;
    [SerializeField] private PlayerController playerController;
    bool canMove;
    public bool puzzleStart;
    int target;
    // Start is called before the first frame update
    void Start()
    {
        cameraPosition.position = new Vector3(positions[0].position.x, positions[0].position.y, cameraPosition.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove && cameraPosition.position!=positions[target].position)
        {            
            cameraPosition.position = Vector3.MoveTowards(cameraPosition.position, new Vector3(positions[target].position.x, positions[target].position.y, cameraPosition.position.z), TransitionSpeed * Time.deltaTime);
        }
        else if(cameraPosition.position == positions[target].position)
        {
            
            canMove = false;
        }
        
    }

    public void moveTo(int i)
    {
        canMove = true;
        target = i;
        if (i == 2 && !puzzleStart)
        {
            puzzleStart = true;
            AtivateWalls();
            timeController.startCount();
            spawnManager.CreateObjects();
            puzzleManagment.createSolution();
            Object.Destroy(tutorialObjects);
        }
        else if(i==4)
        {
            WinUI.SetActive(true);
            playerController.enabled = false;
        }
    }

    public void AtivateWalls()
    {
        Walls.SetActive(true);
    }
    public void DesativateWalls()
    {
        Walls.SetActive(false);
    }
}
