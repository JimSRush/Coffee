using UnityEngine;
using System.Collections.Generic;

public struct CountrySideParallaxMember
{
	public GameObject member;
	public float depth;
}


public class CountrySideParallax : MonoBehaviour {

	public List<CountrySideParallaxMember> members; 
	public Vector3 speed;

	public float sky_depth;
	public float mountains_depth;
	public float hills_depth;
	public float powerlines_depth;

	// Use this for initialization
	void Start () {

		// Add all the child objects with their given depth from the camera
		members = new List<CountrySideParallaxMember> ();
		members.Add (new CountrySideParallaxMember{
			member = this.transform.Find("train_bg_0").gameObject,
			depth = sky_depth
		});
		members.Add (new CountrySideParallaxMember{
			member = this.transform.Find("train_bg_1").gameObject,
			depth = mountains_depth
		});
		members.Add (new CountrySideParallaxMember{
			member = this.transform.Find ("train_bg_2").gameObject,
			depth = hills_depth
		});
		members.Add (new CountrySideParallaxMember{
			member = this.transform.Find ("train_bg_3").gameObject,
			depth = powerlines_depth
		});

		// Make a copy of each member so that you don't see any joins when the scene wraps
		int oiginalMembers = members.Count;
		for (int i = 0; i < oiginalMembers; i++) {

			CountrySideParallaxMember m = members[i];
			GameObject wrapHelper = Instantiate(m.member);

			Transform t = wrapHelper.transform;
			Transform mt = m.member.transform;
			t.parent = mt.parent;
			t.localPosition = new Vector3(mt.localPosition.x-wrapHelper.GetComponent<SpriteRenderer>().bounds.size.x/mt.parent.localScale.x, mt.localPosition.y,mt.localPosition.z);
			members.Add(new CountrySideParallaxMember{
				member = wrapHelper,
				depth = m.depth
			});
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (CountrySideParallaxMember m in members) {

			// Move the backgrounds - higher depth = slower movement
			m.member.transform.position += speed * 1f / m.depth;

			// Wrap the backgrounds if they pass outside the screen
			float wrapDist = m.member.GetComponent<SpriteRenderer>().bounds.size.x/m.member.transform.parent.localScale.x * 2;
			Vector3 lp = m.member.transform.localPosition;
			if (lp.x > wrapDist*0.5) {
				m.member.transform.localPosition = new Vector3(lp.x - wrapDist,lp.y,lp.z);
			}
			else if (lp.x < -wrapDist*0.5) {
				m.member.transform.localPosition = new Vector3(lp.x + wrapDist,lp.y,lp.z);
			}
		}
	}
}
