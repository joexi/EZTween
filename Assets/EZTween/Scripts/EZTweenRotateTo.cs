using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EZTweenRotateTo : EZTween {

	public Vector3 ToEulerAngles;
	private Vector3 FromEulerAnglesRuntime;
	private Vector3 DeltaEulerAnglesRuntime;

	protected override void Awake ()
	{
		base.Awake ();
	}

	public override void Restart ()
	{
		base.Restart ();
		if (IsLocal) {
			FromEulerAnglesRuntime = this.transform.localEulerAngles;
			DeltaEulerAnglesRuntime = ToEulerAngles - this.transform.localEulerAngles;
		} else {
			FromEulerAnglesRuntime = this.transform.eulerAngles;
			DeltaEulerAnglesRuntime = ToEulerAngles - this.transform.eulerAngles;
		}
	}

	protected override void Update ()
	{
		base.Update ();
		if (this.IsRunning) {
			if (IsLocal) {
				this.transform.localEulerAngles = this.Vector3TweenFunc (this.RunningTime, FromEulerAnglesRuntime, DeltaEulerAnglesRuntime, this.Duration);
			} else {
				this.transform.eulerAngles = this.Vector3TweenFunc (this.RunningTime, FromEulerAnglesRuntime, DeltaEulerAnglesRuntime, this.Duration);
			}
		}
	}

	public override void End ()
	{
		base.End ();
	}

	public override void BeginPingpong ()
	{
		base.BeginPingpong ();
	}
}
