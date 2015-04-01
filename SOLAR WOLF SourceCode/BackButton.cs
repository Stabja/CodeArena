using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	public Vector3 target;
	public bool menuPage;

	public GameObject creditsButton;
	public MenuSliding menuScript;

	public void Awake()
	{
		menuScript = creditsButton.GetComponent<MenuSliding>();
	}

	void OnMouseUp()
	{
		menuPage = true;
		menuScript.creditsPage = false;
	}
	
	void Update()
	{
		if(menuPage)
		{
			transform.parent.position = Vector3.Lerp(transform.parent.position, target, Time.deltaTime * 2);
		}
	}

}
