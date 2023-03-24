using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 100f;
    [SerializeField] private float _rotationSpeed = 360f;
    private Rigidbody _playerRb;
    private Vector3 direction;

    // Start is called before the first frame update
    private void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        // Move the player based on input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 lookDirection = direction + gameObject.transform.position;
        direction.Normalize();
        

        // Rotate the player to face the direction of movement
        if(direction != Vector3.zero)
        {
            if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                _playerRb.velocity = direction * _speed * Time.fixedDeltaTime; // Move the player only
                gameObject.transform.LookAt(lookDirection);
            }
            else
            {
                Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _rotationSpeed * Time.fixedDeltaTime); // Rotate the player only
                _playerRb.velocity = direction * _speed * Time.fixedDeltaTime; // Move the player only
                gameObject.transform.LookAt(lookDirection);
            }
        }
        else
        {
            _playerRb.velocity = Vector3.zero;
        }
    }

    public void StartTimer(float time)
    {
        if(direction != Vector3.zero)
        {
            time = Time.deltaTime;
        }
    }
}
