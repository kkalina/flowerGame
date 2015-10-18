using UnityEngine;
using System.Collections;

public class Driver : MonoBehaviour {
    public GameObject sphere;
    public AudioSource welcome;
    public bool playAudio = true;
    private bool pickADaisy = true;
    private bool waterPlants = false;
    
	// Use this for initialization
	void Update() {
        if (pickADaisy) {
            if (playAudio) {
                welcome.Play();
                playAudio = false;
            }
            if (sphere.GetComponent<Objective1>().grabbing) {
                pickADaisy = false;
                playAudio = true;
                waterPlants = true;
            }
        }

        //CHANGE THE THING WE CAN PICK UP
        
	}
	
	
}
