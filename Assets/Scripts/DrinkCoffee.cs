using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class DrinkCoffee : MonoBehaviour, IMetric {

	public AudioClip[] drinkingClips;

	private AudioSource audioSource;
	private Animator animator;
	private bool hasStartedDrinking = false;
	private bool isDrinking = false;

	// Metrics
	private int numberOfTimesIdle = 0;
	private int totalNumberOfSips = 0;
	private float totalTimeSpentDrinking = 0.0f;

	void Start () {
		animator = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}

	void Update () {
		if (Input.GetKeyDown("space") && GameController.IsInputEnabled) {
			isDrinking = true;
			animator.SetBool("IsDrinkingCoffee", isDrinking);
			Debug.Log("Total drunk: " + GameController.totalTimeSpentDrinkingCoffee);
		}
		else if (Input.GetKeyUp("space") || (!GameController.IsInputEnabled && isDrinking)) {
			if (isDrinking) numberOfTimesIdle++;
			isDrinking = false;
			animator.SetBool("IsDrinkingCoffee", false);
			Debug.Log("Total drunk: " + GameController.totalTimeSpentDrinkingCoffee);
		}
		if (!animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).IsName("Paris_Drink_Coffee")) {
			float timeSpent = 1.0f * Time.deltaTime;
			GameController.totalTimeSpentDrinkingCoffee += timeSpent;
			totalTimeSpentDrinking += timeSpent;

			if (hasStartedDrinking == false) {
				hasStartedDrinking = true;
				totalNumberOfSips++;
			}

	        if (!audioSource.isPlaying) {
				audioSource.PlayOneShot(drinkingClips[Random.Range(0, drinkingClips.Length)]);
	        }
		}
	}

	public bool IsDrinking () {
		return isDrinking;
	}

	public bool HasStartedDrinking () {
		return hasStartedDrinking;
	}

	public void UpdateMetrics () {
		GameController gc = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
		MetricController mc = gc.MetricController();
		mc.numberOfTimesIdle += numberOfTimesIdle;
		mc.numberOfSips += totalNumberOfSips;
	}
}
