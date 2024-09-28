using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    private Player _player;

    public float _speed;

    private float distance;
    [SerializeField]
    private int health = 1;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    
    void Update()
    {
        Chase();
    }

    void Chase()
    {
        distance = Vector2.Distance(transform.position, _player.transform.position);
        Vector2 direction = _player.transform.position - transform.position;

        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, _player.transform.position, _speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
            }

            Destroy(this.gameObject);

        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
