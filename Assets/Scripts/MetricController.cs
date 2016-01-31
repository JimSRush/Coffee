﻿using UnityEngine;
using System.Collections;

public class MetricController : MonoBehaviour {

	public float totalCupsConsumed = 0.0f;
	public float totalTimeDrinking = 0.0f;
	public float totalTimeIdle = 0.0f;
	public int numberOfSips = 0;
	public int numberOfTimesIdle = 0;
//	private float averageTimePerCup = 0.0f;
//	private float averageSipLength = 0.0f;
//	private float averageTimeBetweenSips = 0.0f;

	public void PrintMetrics () {
		Debug.Log("Total cups consumed: " + totalCupsConsumed.ToString("#.0") + " cups");
		Debug.Log("Total time drinking coffee: " + totalTimeDrinking.ToString("#.0") + " seconds");
		Debug.Log("Average sip length: ");

		string sipMessage = totalCupsConsumed.ToString("#.0");
		if (sipMessage.CompareTo("0.0") == 1) sipMessage = "N/A";
		else sipMessage = (totalTimeIdle/totalCupsConsumed).ToString("#.00") + " seconds";
		Debug.Log("Average time between sips: " + sipMessage);
	}
}

public interface IMetric {
	void UpdateMetrics();
}
