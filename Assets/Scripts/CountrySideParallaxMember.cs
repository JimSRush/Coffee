using UnityEngine;
using System.Collections;

public class CountrySideParallaxMember
{
	public GameObject member;
	public float depth;
	public float width;
	
	public CountrySideParallaxMember(GameObject member, float depth)
	{
		this.member = member;
		this.depth = depth;
		SpriteRenderer sr = member.GetComponent<SpriteRenderer> ();
		if (sr != null) {
			this.width = sr.bounds.size.x;
		} else {
			// Width can not be determined - just go for a default that wont break things.
			this.width = 1;
		}
	}
	
	public CountrySideParallaxMember(GameObject member, float depth, float wrapWidth)
	{
		this.member = member;
		this.depth = depth;
		this.width = wrapWidth;
	}
}