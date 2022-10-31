using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Vector2 moveInput;
    private Rigidbody2D playerRB;
    private PickUp pickUpScript;
    private float horizontal, vertical;
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
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (horizontal > 0.1)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
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
