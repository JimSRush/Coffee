using UnityEngine;
using System.Collections;

public class SunsetMovement : MonoBehaviour {
	public float MovementTime;

	// Use this for initialization
	void Start () {
		Debug.Log ("Moving sunset");	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.up * Time.deltaTime/180f, Space.World);
		 
		//this.transform.position.y = this.transform.position.y + (MovementTime * Time.deltaTime); 
		//transform.Translate(new Vector2(Vector2.up)

		//		transform.Translate(new Vector2(direction.y * Time.deltaTime * speed, direction.y * Time.deltaTime * speed));
	}
}
