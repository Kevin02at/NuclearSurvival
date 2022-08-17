using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbilities : MonoBehaviour
{
    public Animator animator;
    public Transform model;

    public CharacterController controller;
    public Collider CapsuleColliderBig;
    GameObject player;


    bool canRoll = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        //CapsuleColliderBig = player.GetComponent<CapsuleCollider>();
        CapsuleColliderBig.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //rolling PC
        if (Input.GetButtonDown("Roll"))
        {
            Rolling();
        }

        
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Sprinting Forward Roll"))
        {
            //Debug.Log("anim is playing");
            //CapsuleColliderBig.enabled = false;
            controller.height = 1.5f;
            controller.center = new Vector3(0, -0.25f, 0);
        }
        else 
        {
            //CapsuleColliderBig.enabled = true;
            controller.height = 2.6f;
            controller.center = new Vector3(0, 0.3f, 0);
        }
        
    }

    //rolling mobile
    public void RollButton()
    {
        Rolling();
    }


    void Rolling()
    {
        if (canRoll)
        {
            //Debug.Log("player is rolling");
            animator.SetTrigger("isRollingT"); 
            //CapsuleColliderBig.enabled = false;
        }
    }

    //enable rolling when player collects rolling pickup
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AbilityRolling")
        {
            canRoll = true;
            Destroy(other.gameObject); 
            Debug.Log("rolling enabled");
        }
    }



}
