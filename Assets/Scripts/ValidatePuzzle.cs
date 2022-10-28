using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidatePuzzle : MonoBehaviour
{
    [SerializeField] private PickUp itemHolding;
    [SerializeField] private ObjectInteractable piece;
    bool isTaken;
    int value;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTaken && !itemHolding.isPicked)
        {            
            Debug.Log("Validado");
            value = piece.value;
            piece.GetComponent<Transform>().position= transform.position;
            Debug.Log("Valor "+value);
        }
        else
        {
            value = 0;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Object"))
        {
            piece = collision.GetComponent<ObjectInteractable>();
            isTaken = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Object"))
        {
            piece = null;
            isTaken = false;
        }
    }
}
