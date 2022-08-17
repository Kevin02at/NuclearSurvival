using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEnd : MonoBehaviour
{
    public static bool gameWon;

    public GameObject gameWonPannel;

    void Start()
    {


        gameWon = false;
        //gameWon = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("end reached");
            gameWon = true;
            gameWonPannel.SetActive(true);
            
        }
    }
}
