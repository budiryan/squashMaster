using UnityEngine;
using System.Collections;

public class TestControl : MonoBehaviour {


    public Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetButtonDown ("Fire1")) {
            transform.Rotate(transform.rotation.eulerAngles + new Vector3(0f, 0.1f, 0f));
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            rigidbody.AddForce((new Vector3(0,1,0))*200, ForceMode.Force);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rigidbody.AddForce((new Vector3(0, 0.3f, 0.8f)) * 1500, ForceMode.Force);
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.position += new Vector3(h*0.1f, 0, v * 0.1f);

	}
}
