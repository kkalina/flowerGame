using UnityEngine;
using System.Collections;

public class Objective1 : MonoBehaviour {
	
	public GameObject Sphere_of_influence;
	public bool grabable = false;
	public GameObject plant;
    public GameObject hand;
    public bool grabbing = false;
    public bool dropped = false;
	
	// Use this for initialization
	void Start () 
	{
        //hand = transform.Find("the hand art").gameObject;
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject == plant) //Current Target
		{
			grabable = true;
			
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject == plant) //Current Target
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
                dropped = false;
                grabbing = true;
            }
            else if (Input.GetMouseButtonDown(1)) {
                plant.GetComponent<Rigidbody>().velocity = Vector3.zero;
                grabbing = false;
                dropped = true;
            }
        }
        if (grabbing) {
            plant.transform.position = Sphere_of_influence.transform.position; //+ new Vector3(-.34f, .26f, 0);
        }
	}
}
