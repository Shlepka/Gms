using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public GameObject deathEffect;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public int damage;
    private float stopTime;
    private float startStopTime;
    public float normalSpeed;
    private Player player;
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
        normalSpeed = speed;
    }
    private void Update()
    {

        if (stopTime <=0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
             
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        stopTime = startStopTime;
        health -= damage;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
             if(timeBtwAttack <=0)
            {
                anim.SetTrigger("attack");
            }
             else
            {
                timeBtwAttack -= Time.deltaTime;
            }

        }
    }
    public void OnEnemyAttack()
    {
        player.heatlh -= damage;
        timeBtwAttack = startTimeBtwAttack;

    }
}