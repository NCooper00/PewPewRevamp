using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;
    public GameObject player;

    public int Health = 100;
    public int Damage = 15;
    public float Speed = 10f;

    public float offset = 0f;

    private Transform playerPos;

    private float enemyRot;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = player.GetComponent<Transform>();
    }

    private void Start() {
        anim.SetBool("flying", true);
    }

    private void FixedUpdate() {
        Vector3 difference = playerPos.position - rb.transform.position;
        difference.Normalize();
        enemyRot = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rb.transform.rotation = Quaternion.Euler(0f, 0f, enemyRot + offset);

        rb.AddForce(transform.up * Speed);

    }

    public void TakeDamage(int damage) {
        Health -= damage;
        anim.SetTrigger("hit");

        if (Health <= 0) {
            Die();
        }
    }

    void Die() {
        anim.SetBool("dead", true);
        anim.SetBool("flying", false);
    }

    public void DestroyObject() {
        Destroy(gameObject);
    }
}
