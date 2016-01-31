using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
		Debug.Log("Total cups consumed: " + totalCupsConsumed.ToString("N1") + " cups");
		Debug.Log("Total time drinking coffee: " + totalTimeDrinking.ToString("N1") + " seconds");
		Debug.Log("Average sip length: ");

		string sipMessage = totalCupsConsumed.ToString("N1");
		if (sipMessage.CompareTo("0.0") == 1) sipMessage = "N/A";
		else sipMessage = (totalTimeIdle/totalCupsConsumed).ToString("N1") + " seconds";
		Debug.Log("Average time between sips: " + sipMessage);
	}



	public List<string> GetMetrics(){
		List<string> metrics = new List<string>();
		metrics.Add("Total cups consumed: " + totalCupsConsumed.ToString("N1") + " cups");
		metrics.Add("Total time drinking coffee: " + totalTimeDrinking.ToString("N1") + " seconds");

		string sipMessage = totalCupsConsumed.ToString("N1");
		if (sipMessage.CompareTo("0.0") == 1) sipMessage = "N/A";
		else sipMessage = (totalTimeIdle/totalCupsConsumed).ToString("N1") + " seconds";
		metrics.Add("Average time between sips: " + sipMessage);
			return metrics;
	}
}

public interface IMetric {
	void UpdateMetrics();
}
