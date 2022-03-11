using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomColor : MonoBehaviour
{

    public static RandomColor instance;
    public bool isPlaying = false; // check whether the game is running 
    public Text HealthText;
    public GameObject Win;
    public int Health = 3; // health you have 
    private bool _isPassedLevel = false;
    public bool isPassedLevel
    {
        set
        {
            _isPassedLevel = value;
            if (_isPassedLevel)
            {
                isPlaying = false;
                Win.SetActive(true);
            }
        }
        get
        {
            return _isPassedLevel;
        }
    }


    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }



    void Start()
    {
        Brick[] Bricks = GameObject.FindObjectsOfType<Brick>();
        foreach (var item in Bricks)
        {
            item.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        } // initialize bricks color 

    }


    public void GameOver()
    {
        if (Health == 0)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(sceneName);// Game Over
        }
        else
        {
            HealthChange(-1);
            isPlaying = false;

        }
    }





    public void CheckLevelPassed() 
    {
        Brick[] Bricks = GameObject.FindObjectsOfType<Brick>();
        bool tempPassedLevel = true;
        foreach (var item in Bricks)
        {
            if (item.enabled == false)
            {
                continue;
            }
            tempPassedLevel = false;
        }

        isPassedLevel = tempPassedLevel;

    } // check whether passed this level


    private void HealthChange (int temp)
    {
        Health += temp;
        HealthText.text = "Health: " + Health;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
