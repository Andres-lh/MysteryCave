using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private LayerMask pickUpMask;
    [SerializeField] private Transform handsPosition;
    public Vector3 PlayerDirection { get; set; }
    private GameObject itemHolding;
    private float pickUpRadious = 0.2f;
    public bool isPicked;
    // Update is called once per frame
    void Update()
    {
        PickUpItem();
    }

    private void PickUpItem()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemHolding)
            {
                
                if(itemHolding.transform.position.y >= 10)
                {
                    itemHolding.transform.position = handsPosition.position - new Vector3(0, 2f, 0);
                }
                else
                {
                    itemHolding.transform.position = handsPosition.position + PlayerDirection;
                }
                itemHolding.transform.parent = null;
                itemHolding = null;
                isPicked = false;
            }
            else
            {
                Collider2D pickedUpItem = Physics2D.OverlapCircle(transform.position + PlayerDirection, pickUpRadious, pickUpMask);

                if (pickedUpItem)
                {
                    itemHolding = pickedUpItem.gameObject;
                    itemHolding.transform.position = handsPosition.position;
                    itemHolding.transform.parent = transform;
                    isPicked = true;
                }
            }
        }
    }
}
