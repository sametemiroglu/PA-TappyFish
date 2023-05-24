using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeftMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    BoxCollider2D box;
    float groundWidht;
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        groundWidht = box.size.x;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x-speed*Time.deltaTime, transform.position.y, 0);

        if(transform.position.x <= -groundWidht)
        {
            transform.position = new Vector3(transform.position.x + 2 * groundWidht, transform.position.y, 0);
        }
    }

    
}
