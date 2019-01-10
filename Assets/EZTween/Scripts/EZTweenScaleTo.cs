using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EZTweenScaleTo : EZTween {
	public Vector3 FromScale = Vector3.one;
	public Vector3 ToScale;
	private Vector3 Speed;

	protected override void Awake ()
	{
		base.Awake ();
	}

	public override void Restart ()
	{
		base.Restart ();
		Speed = (ToScale - FromScale) / Duration;
		this.transform.localScale = FromScale;
		LeftTime = Duration;
	}

	protected override void Update ()
	{
		base.Update ();
		if (this.LeftTime > 0) {
			this.LeftTime -= Time.deltaTime;
			if (this.LeftTime <= 0) {
				this.End ();
			} else {
				this.transform.localScale += Speed * Time.deltaTime;
			}
		}
	}

	public override void End ()
	{
		if (IsPingponging) {
			this.transform.localScale = FromScale;
		} else {
			this.transform.localScale = ToScale;
		}
		base.End ();
	}

	public override void BeginPingpong ()
	{
		base.BeginPingpong ();
		Speed = (FromScale - ToScale) / Duration;
		LeftTime = Duration;
	}

}
