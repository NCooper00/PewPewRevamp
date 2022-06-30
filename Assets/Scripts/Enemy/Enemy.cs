using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator anim;

    public GameObject player;

    public int Health = 100;
    public int Damage = 15;

    public float offset = 0f;

    private Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 difference = playerPos.position - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);

        // Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        // difference.Normalize();
        // float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        // transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + offset);
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
    }

    public void DestroyObject() {
        Destroy(gameObject);
    }
}
