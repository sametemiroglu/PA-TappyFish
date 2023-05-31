using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fish : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]
    private float speed;
    int angle;
    int maxAngle = 15;
    int minAngle = -20;
    public Score score;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, speed);
        }
        if (_rb.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }         
        }

        else if (_rb.velocity.y < -2.5f)
        {
            if (angle > minAngle)
            {
                angle = angle - 2 ;
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
    private void OnTriggerEnter2D(Collider2D Collision)
    {
        {
            score.Scored();
            Debug.Log("scored");
        }
    }
}
