using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    public Player _player;
    public UI_Shop _uiShop;
    

    void Start()
    {
        
    }

    
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.down * _speed * Time.deltaTime);
        transform.position = new Vector2(0, Mathf.Clamp(transform.position.y, 2.5f, 6));

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _uiShop.Display();
        }
    }

}
