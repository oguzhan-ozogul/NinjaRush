using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameManager managerGame;
    public PlayerController playerController;

    public Slider _slider;
    
   
   public void SetMaxHealth(int health)
    {
        _slider.maxValue = health;
        _slider.value = health;
    } 
    
    public void SetHealth(int health)
    {
        _slider.value = health;
        
    }
    private void Update()
    {
        if (_slider.value <= 0)
        {
            managerGame.deadMenu.SetActive(true);
           
            
            
        }
    }
}
