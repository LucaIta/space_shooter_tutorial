using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    void Start() {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent <GameController>();
        } else {
            Debug.Log("cannot finf 'gameController script' ");
        }
    }

    // Destroy everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {
    	// on the first frame, the asteroid collides with the Boundary. So before destroying both, we check what we are colliding with.
    	if (other.tag != "Boundary") {
            // Destroy, marks object to be destroyed, they actually get destoyed at the end of the frame
            // here we destroy the object with which the asteroid collided
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
	        // destroy the asteroid itself
	        Destroy(gameObject);
            gameController.incrementScore(scoreValue);
            if (other.tag == "Player") {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            }
    	}
    }
}
