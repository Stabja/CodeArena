using UnityEngine;
using System.Collections;

public class Canon_Bottom : MonoBehaviour {

	public float time;
	public float num;
	public float freqOfFire;                 //Keep the value of this variable between 0 and 500
	public float speed;                      //For difficult levels, it will be < 100

	public GameObject fireBall;
	public Transform shotSpawn;

	public AudioSource shootSound;

	public GameControllerSOLAR controller;

	void Start()
	{
		time = 0;
		num = Random.Range (0, freqOfFire);

		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if(gameControllerObject != null)
		{
			controller = gameControllerObject.GetComponent<GameControllerSOLAR>();
		}
	}

	void Update()
	{
		float swing = Mathf.PingPong (Time.time * speed, 48);
		transform.position= new Vector3( (24 - swing), transform.position.y, transform.position.z);

		time += Time.deltaTime;
		//Debug.Log (time);

		if(time > (num/100.0f) - 0.05 && time < (num/100.0f) + 0.05)
		{
			time = 0;
			num = Random.Range(0, freqOfFire);
			if(controller.startShooting)
			{
				Instantiate(fireBall, shotSpawn.position, shotSpawn.rotation);
				shootSound.Play();
			}
		}
	}
}
