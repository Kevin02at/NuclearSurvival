using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static int numberOfCoins;
    public TextMeshProUGUI numberOfCoinsText;

    public static int currentHealth = 100;
    public Slider healthBar;

    public static bool gameOver;

    public static float fillNumber;

    public GameObject gameOverPanel;

    public Image healthImg;

    // Start is called before the first frame update
    void Start()
    {
        numberOfCoins = 0;

        gameOver = false;
        //gameWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        //test if healthbar is working
        //currentHealth -= 1;

        numberOfCoinsText.text = "Health packs: " + numberOfCoins + "/10";
        //Debug.Log("coins:" + numberOfCoins);

        healthImg.fillAmount = fillNumber/3;

        //update slider value
        healthBar.value = currentHealth;

        //game over
        if (currentHealth < 1)
        {
            gameOver = true;
            gameOverPanel.SetActive(true);
            
        }
    }


}
