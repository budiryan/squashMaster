using UnityEngine;
using System.Collections;

public class TestControl : MonoBehaviour {


    
    public Transform shootTarget;
    public Transform shootTargetSecondary;
    public Transform player;


    private Rigidbody rigidbody;

    private Vector3 objectVector;
    private float objectDistanceMagnitude;

    // power = 0~1, angleOffset = 0~1
    public void shoot(float power, float horizontalAngleOffset) {
        GameMaster.gm.reportServe();
        //primary target
        Vector3 targetDirection = shootTarget.position - this.transform.position;
        float distanceToTarget = targetDirection.magnitude;
        targetDirection.Normalize();
        targetDirection.x += horizontalAngleOffset;
        targetDirection.Normalize();
        Debug.LogWarning(targetDirection+", "+ distanceToTarget);

        //secondary target
        Vector3 targetDirectionSecondary = shootTargetSecondary.position - this.transform.position;
        targetDirectionSecondary.Normalize();
        targetDirectionSecondary.x += horizontalAngleOffset;
        targetDirectionSecondary.Normalize();

        // use primary target. If you are too close to wall, use secondary target as reference direction
        if (distanceToTarget>11.6)
            rigidbody.AddForce(targetDirection * rigidbody.mass * Mathf.Max(1, power)*1000, ForceMode.Force);
        else
            rigidbody.AddForce(targetDirectionSecondary * rigidbody.mass * Mathf.Max(1, power) * 800, ForceMode.Force);
    }



	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        objectVector = player.position - this.transform.position;
        objectDistanceMagnitude = objectVector.magnitude;
    }
	
	// Update is called once per frame
	void Update () {
        objectVector = player.position - this.transform.position;
        objectDistanceMagnitude = objectVector.magnitude;

        if (Input.GetButtonDown ("Fire1")) {
            transform.Rotate(transform.rotation.eulerAngles + new Vector3(0f, 0.1f, 0f));
        }

        /*if (Input.GetKeyDown(KeyCode.Space)) {
            rigidbody.AddForce((new Vector3(0,1,0))*rigidbody., ForceMode.Force);
        }*/
        if (objectDistanceMagnitude < 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shoot(1, 0);
            }
            if (Input.GetKeyDown(KeyCode.H))
            {
                shoot(0.8f, -0.3f);
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                shoot(0.6f, -0.15f);
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                shoot(0.6f, 0.15f);
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                shoot(0.8f, 0.3f);
            }
        }

        
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        //transform.position += new Vector3(h*0.1f, 0, v * 0.1f);
    }
}
