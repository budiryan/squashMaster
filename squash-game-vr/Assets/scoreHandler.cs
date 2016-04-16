using UnityEngine;
using System.Collections;

public class scoreHandler : MonoBehaviour {

    public GameMaster gm;
    public int stuff;

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag.Equals("Ball"))
        {
            //Debug.LogWarning("SCORE!!! ");
            GameMaster.gm.reportScoring();
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
