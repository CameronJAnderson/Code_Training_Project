using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _direction = Vector2.right;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PatrolCoroutine());
    }

    private void FixedUpdate()
    {

        //keep resetting the velocity to the
        //direction * speed even if nudged
        //_rigidbody.velocity = _direction * 2;
        //REPLACE _rigidbody.velocity = _direction * 2; with:
        if (GameManager.Instance.State == GameState.Playing)
        {
            _rigidbody.velocity = _direction * 2;
        }
        else
        {
            _rigidbody.velocity = Vector2.zero;
        }
    }

    //IEnumerator return type for coroutine
    //that can yield for time and come back
    IEnumerator PatrolCoroutine()
    {
        //change the direction every second
        while (true)
        {
            _direction = new Vector2(1, -1);
            yield return new WaitForSeconds(1);
            _direction = new Vector2(-1, 1);
            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
