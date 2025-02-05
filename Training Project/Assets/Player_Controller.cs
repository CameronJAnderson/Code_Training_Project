using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInput _input;
    private Rigidbody2D _rigidbody;
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
            Debug.Log("Fire activated!");
        }
    }

    private void FixedUpdate()
    {
        //set direction to the Move action's Vector2 value
        var dir = _input.actions["Move"].ReadValue<Vector2>();

        //change the velocity to match the Move (every physics update)
        _rigidbody.velocity = dir * 5;
    }
}

