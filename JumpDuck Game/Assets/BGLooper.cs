using UnityEngine;
using System.Collections;

public class BGLooper : MonoBehaviour {

	int numBGPanels = 5;


	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log ("Triggered: " + collider.name);

		float width = ((BoxCollider2D)collider).size.x;

		Vector3 pos = collider.transform.position;

		pos.x += width * numBGPanels - width/4;

		collider.transform.position = pos;
	}
}