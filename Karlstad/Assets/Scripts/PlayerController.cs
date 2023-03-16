using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 move;
    private Vector3 playerVelocity;
    public Rigidbody rb;
    public float jumpAmount = 10;
    private bool isJumping;

    // Start is called before the first frame update

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    //Player characters movement
    public void movePlayer()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        Vector3 cameraRight = Camera.main.transform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        Vector3 movement = cameraForward * move.y + cameraRight * move.x;
        movement.Normalize();
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
        }
    }

    //Player characters jump
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!isJumping)
        {
            Debug.Log("Jump");
            rb.AddForce(Vector2.up * jumpAmount, ForceMode.Impulse);
            isJumping = true;
        }
    }

    //checks is the player is on the ground
     void OnCollisionEnter(Collision other)
    {
      if (other.gameObject.CompareTag("floor"))
     {
        isJumping = false;
     }
    }

}
