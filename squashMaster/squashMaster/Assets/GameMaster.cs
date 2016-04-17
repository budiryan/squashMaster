using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMaster : MonoBehaviour {
    
    public Rigidbody ball;
    
    public int score;
    public int topScore;
    public bool bounceOnce;

    public bool showScore;

    GUIStyle style = new GUIStyle();
    GUIStyle style2 = new GUIStyle();

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
        //ball.useGravity = true;
    }

    public void startGame()
    {
        score = 0;
        //ball.useGravity = false;
    }

    // Use this for initialization
    void Start () {
        startGame();
        style.alignment = TextAnchor.MiddleCenter;
        style.fontSize = 65;
        style2.alignment = TextAnchor.MiddleCenter;
        style2.fontSize = 20;

    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnGUI()
    {
        //"TOP = "+ topScore
        //score + " Points"
        GUI.Box(new Rect(Screen.width / 4, Screen.height / 5, 100, 55),score+" ",style);
        GUI.Box(new Rect((Screen.width / 4 * 3) + 10, Screen.height / 5, 100, 45),score + " ",style);
        GUI.Box(new Rect(Screen.width / 4, Screen.height / 12, 100, 85), "TOP = " + topScore, style2);
        GUI.Box(new Rect((Screen.width / 4 * 3) + 10, Screen.height / 12, 100, 75), "TOP = " + topScore, style2);
        //if (showScore)
        //{
            //GUIStyle style = new GUIStyle(GUI.skin.box);
            //style.normal.textColor = Color.green;
            //style.alignment = TextAnchor.MiddleCenter;
            //style.fontSize = 14;
            //GUI.Box();
        //}
    }
}
