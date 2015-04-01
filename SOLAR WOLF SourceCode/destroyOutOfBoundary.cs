using UnityEngine;
using System.Collections;

public class destroyOutOfBoundary : MonoBehaviour {
	  
	void OnTriggerExit(Collider other)
	{
		Destroy (other.gameObject);
	}

}
