using UnityEngine;
using System.Collections;

public class muzzle : MonoBehaviour {

    public GameObject muzzleFlare;

    public float frequency = 1f;
    private float lastOccruance = 0f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            if (Time.time > lastOccruance + frequency)
            {
                GameObject flareInstance = Instantiate(muzzleFlare);
                flareInstance.transform.position = this.transform.position;
                lastOccruance = Time.time;
            }
        }
	}
}
