using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private float originalX;
    private float maxOffset = 5.0f;
    private float enemyPatroltime = 2.0f;
    private int moveRight = -1;
    private Vector2 velocity;
    private Rigidbody2D enemyBody;
    public Vector3 startPosition = new Vector3(0.0f, 0.0f, 0.0f);
    public Animator goombaAnimator;
    public GameManager gameManager;
    [System.NonSerialized]
    public bool alive = true;
    public AudioSource stompAudio;

    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        // get the starting position
        originalX = transform.position.x;
        ComputeVelocity();
    }
    void ComputeVelocity()
    {
        velocity = new Vector2((moveRight) * maxOffset / enemyPatroltime, 0);
    }
    void Movegoomba()
    {
        enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime);
    }

    void Update()
    {
        if (alive)
        {
            if (Mathf.Abs(enemyBody.position.x - originalX) < maxOffset)
            {// move goomba
                Movegoomba();
            }
            else
            {
                // change direction
                moveRight *= -1;
                ComputeVelocity();
                Movegoomba();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // collision.transform is mario
            // transform is the block
            // if mario collides with the box while moving up
            // then hit the right direction
            if (collision.transform.DotTest(transform, Vector2.down))
            {
                alive = false;
                stompAudio.PlayOneShot(stompAudio.clip);
                goombaAnimator.Play("goomba-stomp");
            }
        }
    }

    void StompGoomba()
    {
        gameManager.IncreaseScore(5);
        Debug.Log("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        gameObject.SetActive(false);
    }

    public void GameRestart()
    {
        transform.localPosition = startPosition;
        originalX = transform.position.x;
        moveRight = -1;
        ComputeVelocity();
        gameObject.SetActive(true);
        alive = true;
    }

}