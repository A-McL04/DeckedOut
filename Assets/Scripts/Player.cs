using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float _speed = 3.5f;

    public Rigidbody2D rb2d;
    public TrailRenderer tr;

    private float _activeMoveSpeed;
    [SerializeField]
    private float _dashSpeed;

    [SerializeField]
    private float _dashLenght = 0.5f;
    [SerializeField]
    private float _dashCooldown = 1f;

    private float _dashCounter;
    private float _dashCoolCounter;

    [SerializeField]
    private int _lives = 3;

    private Transform m_transform;

    private float timeBtwAttack;
    [SerializeField]
    private float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private int damage;


    void Start()
    {
        _activeMoveSpeed = _speed;

        m_transform = this.transform;
    }

    
    void Update()
    {

        CalculateMovement();

        Dash();

        LAMouse();

        Attack();


    }

    void CalculateMovement()
    {
        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * _activeMoveSpeed;

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -8.65f, 8.65f), Mathf.Clamp(transform.position.y, -4.5f, 4.5f));
    }
 
        
    
    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           if(_dashCoolCounter <=0 && _dashCounter <= 0)
           {
               tr.emitting = true;
               _activeMoveSpeed = _dashSpeed;
               _dashCounter = _dashLenght;
           }

           
                
            
        }

        if (_dashCounter > 0)
        {
            _dashCounter -= Time.deltaTime;

            if (_dashCounter <= 0)
            {
                tr.emitting = false;
                _activeMoveSpeed = _speed;
                _dashCoolCounter = _dashCooldown;
            }
        }
        
        if (_dashCoolCounter > 0)
        {
            _dashCoolCounter -= Time.deltaTime;
        }

        
    }

    public void Damage()
    {
        _lives--;

        if (_lives < 1)
        {
            Destroy(this.gameObject);
        }

    }

    private void LAMouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        m_transform.rotation = rotation;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    void Attack()
    {
        
        if(timeBtwAttack <= 0)
        {
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);

            for (int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }

            timeBtwAttack = startTimeBtwAttack;
        }

        else
        {
            timeBtwAttack -= Time.deltaTime;
        }

    }


    public void DashSlowDebuff()
    {
        _speed--;
    }

    public void DashSpeedBuff()
    {
        _speed++;
    }

}
