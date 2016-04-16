using UnityEngine;
using System.Collections;

public class GroundCollider : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag.Equals( "Ball"))
        {
            //Debug.LogWarning("ground : collision entered");
            
            /*TestControl ball = (TestControl)collision.collider.GetComponent("TestControl");
            if (ball.transform.position.z < -7)*/
            if (collision.gameObject.transform.position.z < -5.3)
            {
                Debug.LogWarning("crossed the line");
                GameMaster.gm.startGame();
            }
            GameMaster.gm.reportGroundCollision();
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
