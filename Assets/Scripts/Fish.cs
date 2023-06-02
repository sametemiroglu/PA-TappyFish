using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fish : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed;
    int angle;
    int maxAngle = 15;
    int minAngle = -20;
    public Score score;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;
    public ObstacleSpawner obstacleSpawner;
    [SerializeField] private AudioSource swim, hit, point;
    


    bool touchedGround;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
         sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        FishSwim();
    }


    private void FixedUpdate()
    {
        FishRotation();
    }
    
    
    
    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0)  && GameManager.gameOver == false )
        {
            if (GameManager.gameStarted == false) 
            {
                swim.Play();
                _rb.gravityScale = 3f;
                _rb.velocity = Vector3.zero;
                _rb.velocity = new Vector3(_rb.velocity.x, speed, 0);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            else
            {
                _rb.velocity = Vector3.zero;
                _rb.velocity = new Vector2(_rb.velocity.x, speed);
            }
            
        }
    }
    void FishRotation()
    {
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
                angle = angle - 2;
            }
        }   
        if (touchedGround == false )
        {
            transform.rotation = Quaternion.Euler(0,0, angle);
        }
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {      
            if (collision.CompareTag("Obstacle"))
            {
                    point.Play();
                    score.Scored();
                    
            }
            else if (collision.CompareTag("Column") && GameManager.gameOver == false)
            {
                    hit.Play();
                    gameManager.GameOver();

            }
           
    }



    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false )
            {
                //gameManager.gameOver();
                hit.Play();
                gameManager.GameOver();
                GameOver();
            }
            else
            {
                GameOver(); 
            }
            
        }
    }

    void GameOver()
    {
        touchedGround = true;
        sp.sprite = fishDied;
        anim.enabled = false;
        transform.rotation = Quaternion.Euler (0, 0, -90);
    }

   

}
