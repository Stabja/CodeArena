using UnityEngine;
using System.Collections;

public class BoxRotator : MonoBehaviour {

	public float tumble;

	void Start()
	{
		rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}

}
