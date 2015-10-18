using UnityEngine;
using System.Collections;

public class Driver : MonoBehaviour {
    public GameObject sphere;
    public Objective1 grabDriver;
    //public AudioSource welcome;
    public bool playAudio = true;
    private bool pickADaisy = true;
    private bool waterPlants = false;
    private bool sunPlants = false;
    private bool smellRoses = false;
    private bool pickRifle = false;
    private bool fightTrex = false;


    void Start() {
        grabDriver = sphere.GetComponent<Objective1>();
    }
    //Pick a daisy
    //Water the flower (pick it up lol)
    //move the flower into the sunlight (pick it up lol)
    //smell the roses
    // //stop the assasination????
    //Pick up assault rifle
    //Fight the trex
    //Pick your favorite flower
    //Move the cactus
    //Pet the daisy
    //Relocate rock to more zen location
        //You dummy
    //Pick another daisy

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
            if (playAudio)
            {
                //welcome.Play();
                playAudio = false;
            }
            if (grabDriver.dropped)
            {
                waterPlants = false;
                //playAudio = true;
                sunPlants = true;
            }
        }
        else if (sunPlants)
        {
            grabDriver.plant = GameObject.Find("flower02");
            if (playAudio)
            {
                //welcome.Play();
                playAudio = false;
            }
            if (grabDriver.dropped)
            {
                sunPlants = false;
                //playAudio = true;
                smellRoses = true;
            }
        }
        else if (sunPlants)
        {
            grabDriver.plant = GameObject.Find("flower02");
            if (playAudio)
            {
                //welcome.Play();
                playAudio = false;
            }
            if (grabDriver.dropped)
            {
                sunPlants = false;
                //playAudio = true;
                fightTrex = true;
            }
        }
    }
	
	
}
