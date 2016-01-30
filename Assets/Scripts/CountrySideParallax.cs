using UnityEngine;
using System.Collections.Generic;

public struct CountrySideParallaxMember
{
	public GameObject member;
	public int depth;
}


public class CountrySideParallax : MonoBehaviour {

	public List<CountrySideParallaxMember> members; 
	public Vector3 speed;

	// Use this for initialization
	void Start () {

		// Add all the child objects with their given depth from the camera
		members = new List<CountrySideParallaxMember> ();
		members.Add (new CountrySideParallaxMember{
			member = this.transform.Find("train_bg_0").gameObject,
			depth = 100000000
		});
		members.Add (new CountrySideParallaxMember{
			member = this.transform.Find("train_bg_1").gameObject,
			depth = 100
		});
		members.Add (new CountrySideParallaxMember{
			member = this.transform.Find ("train_bg_2").gameObject,
			depth = 10
		});
		members.Add (new CountrySideParallaxMember{
			member = this.transform.Find ("train_bg_3").gameObject,
			depth = 1
		});

		// Make a copy of each member so that you don't see any joins when the scene wraps
		int oiginalMembers = members.Count;
		for (int i = 0; i < oiginalMembers; i++) {

			CountrySideParallaxMember m = members[i];
			GameObject wrapHelper = Instantiate(m.member);

			Transform t = wrapHelper.transform;
			t.parent = this.transform;
			t.position.Set(-wrapHelper.GetComponent<SpriteRenderer>().bounds.size.x,t.position.y,t.position.z);

			members.Add(new CountrySideParallaxMember{
				member = wrapHelper,
				depth = m.depth
			});
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (CountrySideParallaxMember m in members) {
			m.member.transform.position += speed * 1f / m.depth;

			float wrapDist = m.member.GetComponent<SpriteRenderer>().bounds.size.x;
			if (m.member.transform.position.x > wrapDist*0.5) {
				m.member.transform.position.Set (m.member.transform.position.x - wrapDist, 
				                                 m.member.transform.position.y, 
				                                 m.member.transform.position.z);
			}
		}
	}
}
