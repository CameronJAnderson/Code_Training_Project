using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D _rigidbody;
    void Start()
    {
        transform.position = new Vector2(3, -2);
        //_rigidbody = GetComponent<Rigidbody2D>();
        //_rigidbody.velocity = Vector2.right * 5f;
        Invoke(nameof(AcceptDefeat), 12);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AcceptDefeat()
    {
        Destroy(gameObject);
    }
}
