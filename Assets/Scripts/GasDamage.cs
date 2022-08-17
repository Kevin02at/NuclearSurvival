using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasDamage : MonoBehaviour
{
    public float movementSpeed = 3f; //how fast the gas is moving
    public float acceleration = 0.5f; //how much faster gas moves over time

    [SerializeField] private int attackDamage = 20; //how much damage
    [SerializeField] private float attackSpeed = 1f; //so gas makes damage only once per second, not every frame
    private float canAttack; //for timer

    // Start is called before the first frame update
    void Start()
    {
        //gets activated after 10 seconds and gets executed every x seconds
        InvokeRepeating("IncreaseSpeed", 25f, 25f); 
    }

    // Update is called once per frame
    void Update()
    {
        //moving along the x-axis
        //transform.position=new Vector3(1f * Time.deltaTime , 0, 0);
        transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
        
    }

    public void IncreaseSpeed()
    {
        movementSpeed += acceleration;
    }

    //dealing damage
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("player has touched gas");
        //touching enemy
        if (other.tag == "Player") {
            //Debug.Log("player has touched gas");
            if (attackSpeed <= canAttack) {
                Attack(attackDamage);
                Debug.Log("player took damage");

                canAttack = 0f;
            }
            else {
                canAttack += Time.deltaTime;
            }
            
        }
    }

    public void Attack(int damageAmount)
    {
        PlayerManager.currentHealth -= damageAmount;
    }


}
