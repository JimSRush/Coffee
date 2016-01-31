using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class UpateUI : MonoBehaviour {

	public GameObject gameController;
	public List<string> Metrics;
	private MetricController metricController;
	public Text metric1;
	public Text metric2;
	public Text metric3;

	// Use this for initialization
	void Start () {
		metricController = gameController.GetComponent<MetricController>();
		Metrics = metricController.GetMetrics();

		metric1.text = Metrics [0];
		metric2.text = Metrics [1];
		metric3.text = Metrics [2];
		//update metrics here

	}

}
