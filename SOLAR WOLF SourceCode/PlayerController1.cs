using UnityEngine;
using System.Collections;

public class PlayerController1 : MonoBehaviour {
	
	public float speed;
	
	public float xMin;
	public float xMax;
	public float zMin;
	public float zMax;
	
	public bool up;
	public bool down;
	public bool left;
	public bool right;
	
	public bool destroyed;
	
	public GameObject box1;
	public GameObject box2;
	public GameObject box3;
	
	public Vector3 lastPosition;
	public Quaternion lastRotation;
	
	private GameControllerSOLAR controller;
	
	public float minSwipeDistY;
	public float minSwipeDistX;
	private Vector2 startPos;
	
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if(gameControllerObject != null)
		{
			controller = gameControllerObject.GetComponent<GameControllerSOLAR>();
			//Debug.Log("Not Null");
		}
		else{
			//Debug.Log("It is Null");
		}
		destroyed = false;
	}
	
	//if(Input.GetKeyDown("up"))
	public void swipeUp()
	{
		up = true;
		down = false;
		left = false;
		right = false;
	}
	
	//if(Input.GetKeyDown("down"))
	public void swipeDown()
	{
		up = false;
		down = true;
		left = false;
		right = false;
	}
	
	//if(Input.GetKeyDown("left"))
	public void swipeLeft()
	{
		up = false;
		down = false;
		left = true;
		right = false;
	}
	
	//if(Input.GetKeyDown("right"))
	public void swipeRight()
	{
		up = false;
		down = false;
		left = false;
		right = true;
	}
	
	void Update()
	{
		
		if (Input.touchCount > 0)
		{
			Touch touch = Input.touches[0];
			switch (touch.phase)
			{
			case TouchPhase.Began:
				startPos = touch.position;
				break;
			case TouchPhase.Ended:
				float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
				if (swipeDistVertical > minSwipeDistY)
				{
					float swipeValue = Mathf.Sign(touch.position.y - startPos.y);
					if (swipeValue > 0)//up swipe
					{
						swipeUp();
						//Jump ();
					}
					else if (swipeValue < 0)//down swipe
					{
						swipeDown();
						//Shrink ();
					}
				}
				float swipeDistHorizontal = (new Vector3(touch.position.x,0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
				if (swipeDistHorizontal > minSwipeDistX)
				{
					float swipeValue = Mathf.Sign(touch.position.x - startPos.x);
					if (swipeValue > 0)//right swipe
					{
						swipeRight();
						//MoveRight ();
					}
					else if (swipeValue < 0)//left swipe
					{
						swipeLeft();
						//MoveLeft ();
					}
				}
				break;
			}
		}
		
		if(up)
		{
			transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
			transform.Translate(new Vector3(0, 0, 1 * speed) * Time.deltaTime);
		}
		
		if(down)
		{
			transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
			transform.Translate(new Vector3(0, 0, 1 * speed) * Time.deltaTime);
		}
		
		if(left)
		{
			transform.rotation = Quaternion.Euler(0.0f, 270.0f, 0.0f);
			transform.Translate(new Vector3(0, 0, 1 * speed) * Time.deltaTime);
		}
		
		if(right)
		{
			transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
			transform.Translate(new Vector3(0, 0, 1 * speed) * Time.deltaTime);
		}
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(destroyed)
		{
			return;
		}
		
		if(other.gameObject.tag == "Box3")
		{
			lastPosition = other.transform.position;
			lastRotation = other.transform.rotation;
			Destroy(other.gameObject);
			Instantiate(box2, lastPosition, lastRotation);
			audio.Play();
			destroyed = true;
		}
		
		if(other.gameObject.tag == "Box2")
		{
			lastPosition = other.transform.position;
			lastRotation = other.transform.rotation;
			Destroy(other.gameObject);
			Instantiate(box1, lastPosition, lastRotation);
			audio.Play();
			destroyed = true;
		}
		
		else if(other.gameObject.tag == "Box1")
		{
			Destroy(other.gameObject);
			controller.DecreaseBoxesLeft();
			audio.Play ();
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		destroyed = false;
	}
	
	void FixedUpdate()
	{
		rigidbody.position = new Vector3
			(
				Mathf.Clamp (rigidbody.position.x, xMin, xMax), 
				0.0f, 
				Mathf.Clamp (rigidbody.position.z, zMin, zMax)
				);
	}
	
}
