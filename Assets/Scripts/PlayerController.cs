using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    private Rigidbody birdRigidBody;

    public float jumpPower = 8f;

    public float jumpInterval = 0.7f;

    private float jumpCooldown = 0f;

    // Start is called before the first frame update
    void Start()
    {
        birdRigidBody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        jumpCooldown -= Time.deltaTime;
        bool canJump = jumpCooldown <= 0 && GameManager.Instance.isGameActive();

        if (canJump)
        {
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if (jumpInput)
            {
                Jump();
            }
        }

        birdRigidBody.useGravity = GameManager.Instance.isGameActive();    

    }

    private void Jump()
    {
        jumpCooldown = jumpInterval;

        //Apply force
        birdRigidBody.velocity = Vector3.zero;
        birdRigidBody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        onCustomCollisionEnter(other.gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        onCustomCollisionEnter(other.gameObject);
    }

    private void onCustomCollisionEnter(GameObject other)
    {
        bool isSensorPoint = other.CompareTag("SensorPoint");
        if (isSensorPoint)
            GameManager.Instance.score++;
        else
            GameManager.Instance.EndGame();
    }
}
