using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3;
    public float rotationSpeed = 200f;

    private Transform playerTarget;

    private Rigidbody2D rb;

    public GameObject explosion;

    [HideInInspector]
    public EnemySpawner enemySpawner;
    private void Awake()
    {
        enemySpawner = GetComponent<EnemySpawner>();

        rb = GetComponent<Rigidbody2D>();

        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (playerTarget == null)
        {
            return;
        }

        FollowToPlayer();//хз как работает но они мчаться прикольно за игроком
    }

    private void FollowToPlayer()
    {
        Vector2 pointTotarget = (Vector2)transform.position - (Vector2)playerTarget.position;
        pointTotarget.Normalize();

        float value = Vector3.Cross(pointTotarget, transform.up).z;

        rb.velocity = transform.up * speed;
        rb.angularVelocity = rotationSpeed * value;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Mine")
        {
            Debug.Log("педорахнуло миной");
           GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);

           enemySpawner.ActivateSpawning();
            Destroy(exp, 1.5f);
        }
    }
}
