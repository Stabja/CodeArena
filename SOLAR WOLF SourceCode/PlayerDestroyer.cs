using UnityEngine;
using System.Collections;

public class PlayerDestroyer : MonoBehaviour {             //This script is attached to BOLT prefab

	public GameObject explosion;
	private GameControllerSOLAR controller;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if(gameControllerObject != null)
		{
			controller = gameControllerObject.GetComponent<GameControllerSOLAR>();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Boundary")
		{
			return;
		}

		if(other.gameObject.tag == "Player")
		{
			Instantiate(explosion, other.transform.position, other.transform.rotation);
			audio.Play();
			Destroy(other.gameObject);
			controller.DecreaseLives();
		}

	}

}
