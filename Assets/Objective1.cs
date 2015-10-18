using UnityEngine;
using System.Collections;

public class Objective1 : MonoBehaviour {
	
	public GameObject Sphere_of_influence;
	bool grabable = false;
	public GameObject plant;
	
	// Use this for initialization
	void Start () 
	{
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
			if (Input.GetButtonDown("Submit"))
				plant.SetActive(false);
		}
	}
}
