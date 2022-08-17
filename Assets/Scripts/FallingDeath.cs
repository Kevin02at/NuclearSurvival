using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingDeath : MonoBehaviour
{
    [SerializeField] private int hurt = 110; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        //when player touches death-bar
        if (other.tag == "Player") {
            Debug.Log("player has touched death");
            Attack(hurt);
            //Debug.Log("player took damage");
        }
    }

    public void Attack(int hurt)
    {
        PlayerManager.currentHealth -= hurt;
    }
}
