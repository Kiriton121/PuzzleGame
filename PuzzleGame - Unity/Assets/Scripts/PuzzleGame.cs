using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum GameMode
{
    idle,
    playing,
    levelEnd
}

public class PuzzleGame : MonoBehaviour
{
    static private PuzzleGame S; // a private Singleton

    [Header("Set in Inspector")]
    public Text uitLevel; // The UIText_Level Text
    public Vector3 castlePos; // The place to put castles
    public GameObject[] bricks; // An array of the castles

    [Header("Set in Dynamically")]
    public int level; // The current level
    public int levelMax; // The number of levels
    public GameObject brick; // The current Castle
    public GameMode mode = GameMode.idle;
 

    // Start is called before the first frame update
    void Start()
    {
        S = this; // Define the Singleton

        levelMax = bricks.Length;
        StartLevel();
    } // end start

    void StartLevel()
    {
        if (bricks != null) // get rid of the old castle if one exists
        {
            Destroy(brick);
        } // end if

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject pTemp in gos)
        {
            Destroy(pTemp);
        }

        brick = Instantiate<GameObject>(bricks[level]);
        brick.transform.position = castlePos;

       
        UpdateGUI();

        mode = GameMode.playing;
    } // end StartLevel

    void UpdateGUI()
    {
        uitLevel.text = "Level: " + (level + 1) + "of" + levelMax;
    } // end UpdateGUI()

    // Update is called once per frame
    void Update()
    {
        UpdateGUI();

        if (RandomColor.instance.isPassedLevel)
        {
            mode = GameMode.levelEnd; // change mode to stop checking for level end
            Invoke("NextLevel", 2f);
        } // end if
    } // end Update

    void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            level = 0;
        }
        StartLevel();
    } // end NextLevel()



}
