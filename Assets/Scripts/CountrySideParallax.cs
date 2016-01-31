using UnityEngine;
using System.Collections.Generic;

public class CountrySideParallax : MonoBehaviour {

	public List<CountrySideParallaxMember> members; 
	public Vector3 speed;

	public float sky_depth;
	public float mountains_depth;
	public float hills_depth;
	public float powerlines_depth;
	public float trees_depth;

	public float trees_wrap_width;

	// Use this for initialization
	void Start () {

		GameObject tbg0 = this.transform.Find ("train_bg_0").gameObject;
		GameObject tbg1 = this.transform.Find ("train_bg_1").gameObject;
		GameObject tbg2 = this.transform.Find ("train_bg_2").gameObject;
		GameObject tbg3 = this.transform.Find ("train_bg_3").gameObject;
		GameObject tbg4 = this.transform.Find ("train_bg_4").gameObject;

		// Add all the child objects with their given depth from the camera
		members = new List<CountrySideParallaxMember> ();
		members.Add (new CountrySideParallaxMember(tbg0,sky_depth));
		members.Add (new CountrySideParallaxMember (tbg1, mountains_depth));
		members.Add (new CountrySideParallaxMember (tbg2, hills_depth));
		members.Add (new CountrySideParallaxMember (tbg3, powerlines_depth));
		members.Add (new CountrySideParallaxMember (tbg4, trees_depth, trees_wrap_width));

		// Make a copy of each member so that you don't see any joins when the scene wraps
		int oiginalMembers = members.Count;
		for (int i = 0; i < oiginalMembers; i++) {

			CountrySideParallaxMember m = members[i];
			GameObject wrapHelper = Instantiate(m.member);

			Transform t = wrapHelper.transform;
			Transform mt = m.member.transform;
			t.parent = mt.parent;
			t.localPosition = new Vector3(mt.localPosition.x-m.width*0.5f, mt.localPosition.y,mt.localPosition.z);
			members.Add(new CountrySideParallaxMember(wrapHelper,m.depth,m.width));
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (CountrySideParallaxMember m in members) {

			// Move the backgrounds - higher depth = slower movement
			m.member.transform.position += speed * 1f / m.depth;

			// Wrap the backgrounds if they pass outside the screen
			float wrapDist = m.width;
			Vector3 lp = m.member.transform.localPosition;
			if (lp.x > wrapDist*0.5f) {
				m.member.transform.localPosition = new Vector3(lp.x - wrapDist,lp.y,lp.z);
			}
			else if (lp.x < -wrapDist*0.5f) {
				m.member.transform.localPosition = new Vector3(lp.x + wrapDist,lp.y,lp.z);
			}
		}
	}
}
