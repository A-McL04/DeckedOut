using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;

    public Player _player;
    public UI_Shop _uiShop;
    public GameObject activeGameObject;
    public EnemySpawner _enemySpawnerUp;
    public EnemySpawner _enemySpawnerDown;
    public EnemySpawner _enemySpawnerLeft;
    public EnemySpawner _enemySpawnerRight;
    
    

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

    public void Spawn()
    {
        activeGameObject.SetActive(true);
        Debug.Log("Dealer Spawns");
    }

    public void Despawn()
    {
        Debug.Log("Dealer Despawned");
        _enemySpawnerUp.NewWave();
        _enemySpawnerDown.NewWave();
        _enemySpawnerLeft.NewWave();
        _enemySpawnerRight.NewWave();
        activeGameObject.SetActive(false);
        
    }

}
