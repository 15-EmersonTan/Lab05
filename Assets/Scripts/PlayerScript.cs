using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int Score;
    public GameObject Player;
    public GameObject ScoreText;
    public GameObject Timertext;
    public static float timeremaining;
    // Start is called before the first frame update
    void Start()
    {
        timeremaining = 20;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.GetComponent<Text>().text = "Score : " + Score;
        Timertext.GetComponent<Text>().text = "Timer : " + timeremaining.ToString("F2");

        timeremaining -= Time.deltaTime;

        if (timeremaining <= 0)
        {
            SceneManager.LoadScene("GameLoseScene");
        }

        if (Score == 60)
        {
            SceneManager.LoadScene("GameWinScene");
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Score+= 10;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("GameLoseScene");
        }

    }
}
