using UnityEngine;
using System.Collections;

public class MenuSliding : MonoBehaviour {

	public Vector3 target;
	public bool creditsPage;

	public GameObject backButton;
	public BackButton backScript;

	public void Awake()
	{
		backScript = backButton.GetComponent<BackButton>();
	}

	void OnMouseUp()
	{
		creditsPage = true;
		backScript.menuPage = false;
	}

	void Update()
	{
		if(creditsPage)
		{
			transform.parent.position = Vector3.Lerp(transform.parent.position, target, Time.deltaTime * 2);
		}
	}

}
