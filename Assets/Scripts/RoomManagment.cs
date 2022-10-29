using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManagment : MonoBehaviour
{
    [SerializeField] private CamaraTransition moveCamera;
    [SerializeField] private int RoomNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            moveCamera.moveTo(RoomNumber);
        }
    }
}
