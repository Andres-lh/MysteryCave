using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]   private float speed;
    private Vector2 moveInput;
    private Rigidbody2D playerRB;
    private PickUp pickUpScript;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        pickUpScript = gameObject.GetComponent<PickUp>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        SetPlayerDirection();
    }

    private void FixedUpdate()
    {
        playerRB.MovePosition(playerRB.position + moveInput * speed * Time.deltaTime);
    }

    private void PlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveInput = new Vector2(horizontal, vertical).normalized;
    }

    private void SetPlayerDirection()
    {
        if (moveInput.sqrMagnitude > 0.1f)
        {
            pickUpScript.PlayerDirection = moveInput;
        }
    }
}
