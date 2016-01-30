using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	public float amountToDrink;
	private float beginningAmount;

	// Use this for initialization
	void Start () {
		beginningAmount = GameController.totalTimeSpentDrinkingCoffee;
	}
	
	// Update is called once per frame
	void Update () {
		float amountDrunkThisScene = GameController.totalTimeSpentDrinkingCoffee - beginningAmount;
		if (amountDrunkThisScene > amountToDrink) {
			// Proceed to next scene
		}
	}
}
