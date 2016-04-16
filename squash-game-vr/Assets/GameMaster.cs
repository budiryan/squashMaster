using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMaster : MonoBehaviour {

    public static GameMaster gm = new GameMaster();

    public static Rigidbody ballRef;
    public Rigidbody ball;
    
    public static int score;
    public static int topScore;
    public static bool bounceOnce;

    public void reportGroundCollision()
    {
        if (!bounceOnce)
            bounceOnce = true;
        else
        {
            startGame();
        }
    }

    public void reportScoring()
    {
        if (bounceOnce)
        {
            score++;
            if (score>topScore)
            {
                topScore = score;
            }
            bounceOnce = false;
        }
        else
        {
            startGame();
        }
        //scoreText1.text = " points";
        //scoreText2.text = " points";
        //Debug.LogWarning("SCORE!!! ");
    }

    public void reportServe()
    {
        ballRef.useGravity = true;
    }

    public void startGame()
    {
        score = 0;
    }

    // Use this for initialization
    void Start () {
        if (ball)
            ballRef = ball;
        startGame();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 4 - 60, Screen.height / 8, 100, 100), "TOP = "+topScore);
        GUI.Label(new Rect(Screen.width / 4 * 3, Screen.height / 8, 100, 100), "TOP = " + topScore);
        GUI.Label(new Rect(Screen.width / 4-60, Screen.height/6, 100, 100), score + " Points");
        GUI.Label(new Rect(Screen.width / 4 * 3, Screen.height / 6, 100, 100), score + " Points");
        
    }
}
