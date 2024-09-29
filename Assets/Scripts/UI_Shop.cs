using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Shop : MonoBehaviour
{
    public Player _player;
    public GameObject activeGameObject;
    public Dealer _dealer;
    
    
    
    [SerializeField]
    private int _buffs = 1;
    [SerializeField]
    private int _debuff = 1;
    
    
    
    
    public void Purchase()
    {
        
        float RandomChange = Random.Range(0, 3);
        
        if (RandomChange <= 1)
        {
            Debug.Log("Buff Gained");
            _player.DashSpeedBuff();
            
        }
        else if (RandomChange > 1)
        {
            Debug.Log("Debuff Gained");
            _player.DashSlowDebuff();
        }

        activeGameObject.SetActive(false);
        _dealer.Despawn();

    }

    public void Display()
    {
        activeGameObject.SetActive(true);
    }
    

}
