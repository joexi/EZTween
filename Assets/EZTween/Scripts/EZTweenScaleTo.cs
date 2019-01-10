using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EZTweenScaleTo : EZTween {
	public Vector3 FromScale = Vector3.one;
	public Vector3 ToScale;
	private Vector3 DeltaScaleRuntime;

	protected override void Awake ()
	{
		base.Awake ();
	}

	public override void Restart ()
	{
		base.Restart ();
		DeltaScaleRuntime = ToScale - FromScale;
		this.transform.localScale = FromScale;
	}

	protected override void Update ()
	{
		base.Update ();
		if (this.IsRunning) {
			this.transform.localScale = this.Vector3TweenFunc (this.RunningTime, FromScale, DeltaScaleRuntime, this.Duration);
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
	}

}
