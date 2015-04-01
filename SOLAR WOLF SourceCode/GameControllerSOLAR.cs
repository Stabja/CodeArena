using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControllerSOLAR : MonoBehaviour {

	public GameObject box1;
	public GameObject box2;
	public GameObject box3;
	public GameObject player;
	public GameObject p;

	public GUIText playerLivesText;      //Same As score
	public GUIText boxLeftText;          //Same As score
	public GUIText gameOverText;
	public GUIText retryText;
	public GUIText mainMenuText;

	public int playerLives;
	public int currentLevel;
	public int numBoxes;         //Total number of boxes
	public int boxesLeft;     
	public int numRedBoxes;
	public int numYellowBoxes;
	public int numGreenBoxes;

	public bool playerDead; //
	public bool gameOver;   //
	public bool retry;      //
	public bool mainMenu;   //
	public bool startShooting;

	public GameObject Bolt;
	public GameObject leftObject;
	public GameObject rightObject;
	public GameObject topObject;
	public GameObject bottomObject;

	private Mover moverScript;
	private Canon_Left leftScript;
	private Canon_Right rightscript;
	private Canon_Top topscript;
	private Canon_Bottom bottomscript;

	public AudioSource gameoverAudio;
	public AudioSource levelCompleteAudio;
	public List <Vector3> boxList;

	//public GameObject lev1;
	//public GameObject lev2;
	//public GameObject lev3;

	//private Level1Code level1;
	//private Level2Code level2;
	//private Level3Code level3;

	void Awake()
	{
		gameOverText.text = "";
		retryText.text = "";
		mainMenuText.text = "";

		playerLives = 3;
		currentLevel = 1;

		playerDead = false;
		gameOver = false;
		retry = false;
		mainMenu = false;
		startShooting = false;

		//GameObject moverObject = GameObject.FindGameObjectWithTag ("Bullet");
		moverScript = Bolt.GetComponent<Mover> ();
		if(moverScript != null)
		{
			//Debug.Log ("Not Null");
		}
		else{
			//Debug.Log("It is Null");
		}

		leftScript = leftObject.GetComponent<Canon_Left>();
		if(leftScript != null)
		{
			//Debug.Log ("Not Null");
		}
		else{
			//Debug.Log("It is Null");
		}
		rightscript = rightObject.GetComponent<Canon_Right>();
		topscript = topObject.GetComponent<Canon_Top>();
		bottomscript = bottomObject.GetComponent<Canon_Bottom>();

		LoadLevel();
	}
	
	public void LoadLevel()
	{
		startShooting = false;
		if(currentLevel == 1)
		{
			setParametersOne();
			LoadBoxesOne();
		}
		else if(currentLevel == 2)
		{
			setParametersTwo();
			LoadBoxesTwo();
		}
		else if(currentLevel == 3)
		{
			setParametersThree();
			LoadBoxesThree();
		}
		else if(currentLevel == 4)
		{
			setParametersFour();
			LoadBoxesFour();
		}
		else if(currentLevel == 5)
		{
			setParametersFive();
			LoadBoxesFive();
		}
		else if(currentLevel == 6)
		{
			setParametersSix();
			LoadBoxesSix();
		}
		else if(currentLevel == 7)
		{
			setParametersSeven();
			LoadBoxesSeven();
		}

		/*numBoxes = boxList.Count;
		boxesLeft = numBoxes;*/

		UpdateLives ();
		UpdateBoxesLeft ();
		StartCoroutine (SpawnBoxes());
	}

	void setParametersOne()
	{
		numBoxes = 16;
		boxesLeft = 16;
		numRedBoxes = 0;
		numYellowBoxes = 0; 
		numGreenBoxes = 16;

		moverScript.speed = 15;
		leftScript.freqOfFire = 400;
		rightscript.freqOfFire = 400;
		topscript.freqOfFire = 400;
		bottomscript.freqOfFire = 400;
		//Debug.Log(leftScript.freqOfFire);
		//Debug.Log (mover.speed);
	}

	void LoadBoxesOne()
	{
		boxList.Add (new Vector3( 3, 0, 0));
		boxList.Add (new Vector3( 6, 0, 0));
		boxList.Add (new Vector3( 9, 0, 0));
		boxList.Add (new Vector3(-3, 0, 0));
		boxList.Add (new Vector3(-6, 0, 0));
		boxList.Add (new Vector3(-9, 0, 0));
		boxList.Add (new Vector3( 0, 0, 3));
		boxList.Add (new Vector3( 0, 0, 6));
		boxList.Add (new Vector3( 0, 0, 9));
		boxList.Add (new Vector3( 0, 0,-3));
		boxList.Add (new Vector3( 0, 0,-6));
		boxList.Add (new Vector3( 0, 0,-9));
		boxList.Add (new Vector3( 3, 0, 3));
		boxList.Add (new Vector3(-3, 0, 3));
		boxList.Add (new Vector3(-3, 0,-3));
		boxList.Add (new Vector3( 3, 0,-3));
	}

	void setParametersTwo()
	{
		numBoxes = 24;
		boxesLeft = 24;
		numRedBoxes = 0;
		numYellowBoxes = 4; 
		numGreenBoxes = 20;

		moverScript.speed = 16;             //BulletSpeed
		leftScript.freqOfFire = 350;
		rightscript.freqOfFire = 350;
		topscript.freqOfFire = 350;
		bottomscript.freqOfFire = 350;
		//Debug.Log(leftScript.freqOfFire);
		//Debug.Log (mover.speed);
	}
	
	void LoadBoxesTwo()
	{
		boxList.Add (new Vector3(-9, 0, 6));
		boxList.Add (new Vector3(-6, 0, 6));
		boxList.Add (new Vector3(-3, 0, 6));
		boxList.Add (new Vector3( 0, 0, 6));
		boxList.Add (new Vector3( 3, 0, 6));
		boxList.Add (new Vector3( 6, 0, 6));
		boxList.Add (new Vector3( 9, 0, 6));    //
		boxList.Add (new Vector3(-9, 0,-6));    
		boxList.Add (new Vector3(-6, 0,-6));
		boxList.Add (new Vector3(-3, 0,-6));
		boxList.Add (new Vector3( 0, 0,-6));
		boxList.Add (new Vector3( 3, 0,-6));
		boxList.Add (new Vector3( 6, 0,-6));
		boxList.Add (new Vector3( 9, 0,-6));    //
		boxList.Add (new Vector3(-3, 0, 3));
		boxList.Add (new Vector3( 0, 0, 3));
		boxList.Add (new Vector3( 3, 0, 3));
		boxList.Add (new Vector3( 3, 0, 0));
		boxList.Add (new Vector3( 3, 0,-3));
		boxList.Add (new Vector3( 0, 0,-3));
		boxList.Add (new Vector3(-3, 0,-3));
		boxList.Add (new Vector3(-3, 0, 0));
		boxList.Add (new Vector3( 0, 0, 9));
		boxList.Add (new Vector3( 0, 0,-9));
	}

	void setParametersThree()
	{
		numBoxes = 32;
		boxesLeft = 32;
		numRedBoxes = 0;
		numYellowBoxes = 12; 
		numGreenBoxes = 20;

		moverScript.speed = 18;
		leftScript.freqOfFire = 300;
		rightscript.freqOfFire = 300;
		topscript.freqOfFire = 300;
		bottomscript.freqOfFire = 300;
		//Debug.Log(leftScript.freqOfFire);
		//Debug.Log (mover.speed);
	}
	
	void LoadBoxesThree()
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

	void setParametersFour()
	{
		numBoxes = 32;
		boxesLeft = 32;
		numRedBoxes = 2;
		numYellowBoxes = 10; 
		numGreenBoxes = 20;
		
		moverScript.speed = 20;
		leftScript.freqOfFire = 240;
		rightscript.freqOfFire = 240;
		topscript.freqOfFire = 240;
		bottomscript.freqOfFire = 240;
	}
	
	void LoadBoxesFour()
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

	void setParametersFive()
	{
		numBoxes = 32;
		boxesLeft = 32;
		numRedBoxes = 8;
		numYellowBoxes = 8; 
		numGreenBoxes = 16;
		
		moverScript.speed = 22;
		leftScript.freqOfFire = 160;
		rightscript.freqOfFire = 160;
		topscript.freqOfFire = 160;
		bottomscript.freqOfFire = 160;
	}
	
	void LoadBoxesFive()
	{
		boxList.Add (new Vector3(-12, 0, 9));
		boxList.Add (new Vector3( -9, 0, 9));
		boxList.Add (new Vector3( -6, 0, 9));
		boxList.Add (new Vector3( -3, 0, 9));
		boxList.Add (new Vector3(  0, 0, 9));
		boxList.Add (new Vector3(  3, 0, 9));
		boxList.Add (new Vector3(-12, 0, 6));
		boxList.Add (new Vector3(  3, 0, 6));
		boxList.Add (new Vector3(-12, 0, 3));
		boxList.Add (new Vector3( -6, 0, 3));
		boxList.Add (new Vector3( -3, 0, 3));
		boxList.Add (new Vector3(  3, 0, 3));
		boxList.Add (new Vector3(-12, 0, 0));
		boxList.Add (new Vector3( -6, 0, 0));
		boxList.Add (new Vector3( -3, 0, 0));
		boxList.Add (new Vector3(  3, 0, 0));
		boxList.Add (new Vector3(-12, 0,-3));
		boxList.Add (new Vector3( -6, 0,-3));
		boxList.Add (new Vector3( -3, 0,-3));
		boxList.Add (new Vector3(  0, 0,-3));
		boxList.Add (new Vector3(  3, 0,-3));
		boxList.Add (new Vector3(  6, 0,-3));
		boxList.Add (new Vector3(-12, 0,-6));
		boxList.Add (new Vector3(  9, 0,-6));
		boxList.Add (new Vector3(-12, 0,-9));
		boxList.Add (new Vector3( -9, 0,-9));
		boxList.Add (new Vector3( -6, 0,-9));
		boxList.Add (new Vector3( -3, 0,-9));
		boxList.Add (new Vector3(  0, 0,-9));
		boxList.Add (new Vector3(  3, 0,-9));
		boxList.Add (new Vector3(  6, 0,-9));
		boxList.Add (new Vector3(  9, 0,-9));
	}

	void setParametersSix()
	{
		numBoxes = 31;
		boxesLeft = 31;
		numRedBoxes = 12;
		numYellowBoxes = 12; 
		numGreenBoxes = 7;
		
		moverScript.speed = 20;
		leftScript.freqOfFire = 100;
		rightscript.freqOfFire = 100;
		topscript.freqOfFire = 100;
		bottomscript.freqOfFire = 100;
	}
	
	void LoadBoxesSix()
	{
		boxList.Add (new Vector3( 0, 0, 9));
		boxList.Add (new Vector3( 3, 0, 9));
		boxList.Add (new Vector3(-9, 0, 6));
		boxList.Add (new Vector3(-3, 0, 6));
		boxList.Add (new Vector3( 0, 0, 6));
		boxList.Add (new Vector3( 3, 0, 6));
		boxList.Add (new Vector3( 6, 0, 6));
		boxList.Add (new Vector3(-12, 0, 3));
		boxList.Add (new Vector3(-9, 0, 3));
		boxList.Add (new Vector3(-6, 0, 3));
		boxList.Add (new Vector3(-3, 0, 3));
		boxList.Add (new Vector3( 0, 0, 3));
		boxList.Add (new Vector3( 3, 0, 3));
		boxList.Add (new Vector3( 6, 0, 3));
		boxList.Add (new Vector3( 9, 0, 3));
		boxList.Add (new Vector3( 12, 0, 3));
		boxList.Add (new Vector3(-12, 0, 0));
		boxList.Add (new Vector3(-9, 0, 0));
		boxList.Add (new Vector3(-6, 0, 0));
		boxList.Add (new Vector3(-3, 0, 0));
		boxList.Add (new Vector3( 3, 0, 0));
		boxList.Add (new Vector3( 6, 0, 0));
		boxList.Add (new Vector3( 9, 0, 0));
		boxList.Add (new Vector3(12, 0, 0));
		boxList.Add (new Vector3(-9, 0,-3));
		boxList.Add (new Vector3(-3, 0,-3));
		boxList.Add (new Vector3( 0, 0,-3));
		boxList.Add (new Vector3( 3, 0,-3));
		boxList.Add (new Vector3( 6, 0,-3));
		boxList.Add (new Vector3( 0, 0,-6));
		boxList.Add (new Vector3( 3, 0,-6));
	}

	void setParametersSeven()
	{
		numBoxes = 34;
		boxesLeft = 34;
		numRedBoxes = 20;
		numYellowBoxes = 14; 
		numGreenBoxes = 0;
		
		moverScript.speed = 25;
		leftScript.freqOfFire = 80;
		rightscript.freqOfFire = 80;
		topscript.freqOfFire = 80;
		bottomscript.freqOfFire = 80;
	}
	
	void LoadBoxesSeven()
	{
		boxList.Add (new Vector3( -6, 0, 9));
		boxList.Add (new Vector3( -3, 0, 9));
		boxList.Add (new Vector3(  3, 0, 9));
		boxList.Add (new Vector3(  6, 0, 9));
		boxList.Add (new Vector3( -9, 0, 6));
		boxList.Add (new Vector3( -6, 0, 6));
		boxList.Add (new Vector3(  0, 0, 6));
		boxList.Add (new Vector3(  6, 0, 6));
		boxList.Add (new Vector3(  9, 0, 6));
		boxList.Add (new Vector3( -9, 0, 3));
		boxList.Add (new Vector3( -3, 0, 3));
		boxList.Add (new Vector3(  0, 0, 3));
		boxList.Add (new Vector3(  3, 0, 3));
		boxList.Add (new Vector3(  9, 0, 3));
		boxList.Add (new Vector3( -9, 0, 0));
		boxList.Add (new Vector3( -6, 0, 0));
		boxList.Add (new Vector3(  6, 0, 0));
		boxList.Add (new Vector3(  9, 0, 0));
		boxList.Add (new Vector3(-12, 0,-3));
		boxList.Add (new Vector3( -6, 0,-3));
		boxList.Add (new Vector3( -3, 0,-3));
		boxList.Add (new Vector3(  0, 0,-3));
		boxList.Add (new Vector3(  3, 0,-3));
		boxList.Add (new Vector3(  6, 0,-3));
		boxList.Add (new Vector3( 12, 0,-3));
		boxList.Add (new Vector3(-12, 0,-6));
		boxList.Add (new Vector3( 12, 0,-6));
		boxList.Add (new Vector3( -9, 0,-9));
		boxList.Add (new Vector3( -6, 0,-9));
		boxList.Add (new Vector3( -3, 0,-9));
		boxList.Add (new Vector3(  0, 0,-9));
		boxList.Add (new Vector3(  3, 0,-9));
		boxList.Add (new Vector3(  6, 0,-9));
		boxList.Add (new Vector3(  9, 0,-9));
	}
	
	void UpdateLives()
	{
		playerLivesText.text = "LivesLeft : " + playerLives;
	}
	
	void UpdateBoxesLeft()
	{
		boxLeftText.text = "BoxesLeft : " + boxesLeft;
	}

	IEnumerator SpawnBoxes()
	{
		yield return new WaitForSeconds (2);
	
		for(int i = 0; i < numGreenBoxes; i++)
		{
			Vector3 temp = boxList[i];
			Instantiate(box1, temp, Quaternion.identity);
			yield return new WaitForSeconds(0.2f);
		}

		for(int i = 0; i < numYellowBoxes; i++)
		{
			Vector3 temp = boxList[numGreenBoxes + i];
			Instantiate(box2, temp, Quaternion.identity);
			yield return new WaitForSeconds(0.2f);
		}

		for(int i = 0; i < numRedBoxes; i++)
		{
			Vector3 temp = boxList[numGreenBoxes + numYellowBoxes + i];
			Instantiate(box3, temp, Quaternion.identity);
			yield return new WaitForSeconds(0.2f);
		}

		InitializePlayer ();
		startShooting = true;
	}

	public void InitializePlayer()
	{
		player.SetActive (true);
		p = (GameObject)Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
	}

	public void DecreaseLives()             //Called by BOLT Prefab when it hits the player
	{
		playerLives--;
		UpdateLives();

		startShooting = false;
		StartCoroutine (pauseAfterDeath());
		//yield return new WaitForSeconds (3);

	}

	IEnumerator pauseAfterDeath()
	{
		if(playerLives > 0)
		{
			yield return new WaitForSeconds (3);
			InitializePlayer();
			startShooting = true;
		}
		else if(playerLives == 0)
		{
			yield return new WaitForSeconds (1.2f);
			gameoverAudio.Play();
			playerDead = true;
			gameOver = true;
			startShooting = false;
		}
	}

	public void DecreaseBoxesLeft()        //Called by PLAYER Prefab when it hits the boxes
	{
		boxesLeft--;
		UpdateBoxesLeft();
	}

	void Update()
	{
		if(gameOver == false)
		{
			UpdateLevel();
		}
		else if(gameOver)
		{
			ShowRestartMenu();
		}
	}

	void UpdateLevel()             ///This will perform same functiion as Start()
	{
		if(boxesLeft == 0 && playerLives > 0)
		{
			currentLevel++;
			Debug.Log(currentLevel);
			Destroy(p);
			levelCompleteAudio.Play();
			boxList.Clear();
			LoadLevel();
		}
	}

	void ShowRestartMenu()
	{
		gameOverText.text = "Game Over!";
		retryText.text = "R : Retry";
		mainMenuText.text = "M : MainMenu";

		if(Input.GetKeyDown(KeyCode.R))
		{
			gameOver  = false;
			Application.LoadLevel(1);
		}
		else if(Input.GetKeyDown(KeyCode.M))
		{
			gameOver = false;
			Application.LoadLevel(0);
		}
	}

}

