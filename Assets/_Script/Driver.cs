using UnityEngine;
using System.Collections;

public class Driver : MonoBehaviour {
    public GameObject sphere;
    public Objective1 grabDriver;
    //public AudioSource welcome;
    public bool playAudio = true;
    private bool pickADaisy = true;
    private bool waterPlants = false;

    void Start() {
        grabDriver = sphere.GetComponent<Objective1>();
    }

	// Use this for initialization
	void Update() {
        if (pickADaisy)
        {
            if (playAudio)
            {
                //welcome.Play();
                playAudio = false;
            }
            if (grabDriver.dropped)
            {
                pickADaisy = false;
                //playAudio = true;
                waterPlants = true;
            }
        }

        //CHANGE THE THING WE CAN PICK UP
        else if (waterPlants) {
            grabDriver.plant = GameObject.Find("flower02");
            //grabDriver.grabable = true;
        }
	}
	
	
}
