using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraTransition : MonoBehaviour
{
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private List<Transform> positions;
    [SerializeField] private float TransitionSpeed;
    bool canMove;
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
    }
}
