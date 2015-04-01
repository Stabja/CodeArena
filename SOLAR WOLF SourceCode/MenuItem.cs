using UnityEngine;
using System.Collections;

public class MenuItem : MonoBehaviour {

	public bool playButton;
	public bool quitButton;

	void OnMouseEnter()
	{
		renderer.material.color = Color.red;
	}

	void OnMouseExit()
	{
		renderer.material.color = Color.white;
	}

	void OnMouseUp()
	{
		audio.Play ();
		if(playButton)
		{
		    Application.LoadLevel(1);
		}
		if(quitButton)
		{
			Application.Quit();
		}
	}

}
