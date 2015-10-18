using UnityEngine;
using System.Collections;

public class Objective1 : MonoBehaviour {
	
	public GameObject Sphere_of_influence;
	bool grabable = false;
	public GameObject plant;
    public GameObject hand;
    public bool grabbing = false;
	
	// Use this for initialization
	void Start () 
	{
        //hand = transform.Find("the hand art").gameObject;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag=="Plant_1")
		{
			grabable = true;
			
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag=="Plant_1")
		{
			grabable = false;
		}
	}
	// Update is called once per frame
	void Update () 
	{
		if (grabable == true) {
            if (Input.GetMouseButtonDown(1) && !grabbing)
            {
                //plant.SetActive(false);
                grabbing = true;
            }
            else if (Input.GetMouseButtonDown(1)) {
                plant.GetComponent<Rigidbody>().velocity = Vector3.zero;
                grabbing = false;
            }
        }
        if (grabbing) {
            plant.transform.position = Sphere_of_influence.transform.position; //+ new Vector3(-.34f, .26f, 0);
        }
	}

    void OnTriggerStay(Collision coll) {

    }
}
