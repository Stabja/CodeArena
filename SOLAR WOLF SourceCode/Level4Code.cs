using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Level4Code : MonoBehaviour {

	public float freqOfFire = 240;
	public float bulletSpeed = 20;
	
	public int numBoxes = 32;
	public int boxesLeft = 32;
	public int numRedBoxes = 2;
	public int numYellowBoxes = 10;
	public int numGreenBoxes = 20;
	
	public GameObject bolt;                    //Reference to GameObjects
	public GameObject canonLeft;
	public GameObject canonRight;
	public GameObject canonTop;
	public GameObject canonBottom;
	
	private Mover mover;                        //Reference to Scripts
	private Canon_Left left;                    
	private Canon_Right right;
	private Canon_Top top;
	private Canon_Bottom bottom;
	
	public GameObject gameController;
	private GameControllerSOLAR controller;
	
	void Awake()
	{
		/*GameObject g1 = GameObject.FindGameObjectWithTag ("EnemyLeft");
		left = g1.GetComponent<Canon_Left> ();
		GameObject g2 = GameObject.FindGameObjectWithTag ("EnemyRight");
		right = g2.GetComponent<Canon_Right>();
		GameObject g3 = GameObject.FindGameObjectWithTag ("EnemyTop");
		top = g3.GetComponent<Canon_Top> ();
		GameObject g4 = GameObject.FindGameObjectWithTag ("EnemyBottom");
		bottom = g4.GetComponent<Canon_Bottom> ();
		GameObject g = GameObject.FindGameObjectWithTag ("Bullet");
		mover = g.GetComponent<Mover>();
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if(gameControllerObject != null)
		{
			controller = gameControllerObject.GetComponent<GameControllerSOLAR>();
		}*/
	}
	
	public void LoadBoxes(List <Vector3> boxList)
	{
		boxList.Add (new Vector3(-12, 0, 9));
		boxList.Add (new Vector3( -9, 0, 9));
		boxList.Add (new Vector3( -6, 0, 9));
		boxList.Add (new Vector3( -3, 0, 9));
		boxList.Add (new Vector3(-12, 0, 6));
		boxList.Add (new Vector3( -9, 0, 6));
		boxList.Add (new Vector3( -6, 0, 6));
		boxList.Add (new Vector3( -3, 0, 6));
		boxList.Add (new Vector3( -6, 0, 3));
		boxList.Add (new Vector3( -3, 0, 3));
		boxList.Add (new Vector3(  3, 0, 3));
		boxList.Add (new Vector3(  6, 0, 3));
		boxList.Add (new Vector3( -6, 0, 0));
		boxList.Add (new Vector3( -3, 0, 0));
		boxList.Add (new Vector3( 3, 0, 0));
		boxList.Add (new Vector3( 6, 0, 0));
		boxList.Add (new Vector3( 9, 0, 0));
		boxList.Add (new Vector3(-3, 0,-3));
		boxList.Add (new Vector3( 0, 0, -3));
		boxList.Add (new Vector3( 3, 0, -3));
		boxList.Add (new Vector3( 6, 0, -3));
		boxList.Add (new Vector3( 9, 0, -3));
		boxList.Add (new Vector3(12, 0, -3));
		boxList.Add (new Vector3(-3, 0, -6));
		boxList.Add (new Vector3( 0, 0, -6));
		boxList.Add (new Vector3( 9, 0, -6));
		boxList.Add (new Vector3(12, 0, -6));
		boxList.Add (new Vector3(-6, 0, -9));
		boxList.Add (new Vector3(-3, 0, -9));
		boxList.Add (new Vector3( 0, 0, -9));
		boxList.Add (new Vector3( 9, 0, -9));
		boxList.Add (new Vector3(12, 0, -9));
	}
	
	public void setParameters()
	{
		numBoxes = numBoxes;
		boxesLeft = numBoxes;
		numRedBoxes = numRedBoxes;
		numYellowBoxes = numYellowBoxes;
		numGreenBoxes = numGreenBoxes;
		
		left.freqOfFire = freqOfFire;
		right.freqOfFire = freqOfFire;
		top.freqOfFire = freqOfFire;
		bottom.freqOfFire = freqOfFire;
		mover.speed = bulletSpeed;
	}
}
