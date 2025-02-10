using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;
    public GameObject Ball;
    private Vector2 _facingVector = Vector2.right;
    void Start()
    {
        //transform.position = new Vector2(3, -2);
        //_rigidbody = GetComponent<Rigidbody2D>();
        //_rigidbody.velocity = Vector2.right * 5f;
        //Invoke(nameof(AcceptDefeat), 12);
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.velocity = new Vector2(2, 4);
        _rigidbody.gravityScale = 3f;
        _rigidbody.constraints =
            RigidbodyConstraints2D.FreezeRotation;
    }

    void AcceptDefeat()
    {
        Destroy(gameObject);
    }


// Update is called once per frame
void Update()
    {
        if (_input.actions["Fire"].WasPressedThisFrame())
        {
            //create a new object that is a clone of the ballPrefab
            //at this object's position and default rotation
            //and use a new variable (ball) to reference the clone
            var ball = Instantiate(Ball,
                                transform.position,
                                Quaternion.identity);
            //Get the Rigidbody 2D component from the new ball 
            //and set its velocity to x:-10f, y:0, z:0
            //ball.GetComponent<Rigidbody2D>().velocity = Vector2.left * 10f;
            ball.GetComponent<Rigidbody2D>().velocity =
            _facingVector.normalized * 10f;
            ball.GetComponent<BallController>()?.SetDirection(_facingVector);

        }
    }

    private void FixedUpdate()
    {
        //set direction to the Move action's Vector2 value
        var dir = _input.actions["Move"].ReadValue<Vector2>();

        //change the velocity to match the Move (every physics update)
        _rigidbody.velocity = dir * 5;
        if (dir.magnitude > 0.5)
        {
            _facingVector = _rigidbody.velocity;
        }
    }
}

