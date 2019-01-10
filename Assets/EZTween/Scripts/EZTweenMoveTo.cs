using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EZTweenMoveTo : EZTween {
	public Vector3 FromPostion;
	public Vector3 ToPosition;
	private Vector3 FromPostionRuntime;
	private Vector3 DeltaPositionRuntime;
	protected override void Awake ()
	{
		base.Awake ();
	}

	public override void Restart ()
	{
		base.Restart ();
		FromPostionRuntime = FromPostion;
		DeltaPositionRuntime = ToPosition - FromPostion;
		if (IsLocal) {
			this.transform.localPosition = FromPostionRuntime;
		} else {
			this.transform.position = FromPostionRuntime;
		}
	}

	protected override void Update ()
	{
		base.Update ();
		if (this.IsRunning) {
			if (IsLocal) {
				this.transform.localPosition = this.Vector3TweenFunc (this.RunningTime, FromPostionRuntime, DeltaPositionRuntime, this.Duration);
			} else {
				this.transform.position = this.Vector3TweenFunc (this.RunningTime, FromPostionRuntime, DeltaPositionRuntime, this.Duration);
			}
		}
	}

	public override void End ()
	{
		if (IsPingponging) {
			if (IsLocal) {
				this.transform.localPosition = FromPostion;
			} else {
				this.transform.position = FromPostion;
			}
		} else {
			if (IsLocal) {
				this.transform.localPosition = ToPosition;
			} else {
				this.transform.position = ToPosition;
			}
		}
		base.End ();
	}

	public override void BeginPingpong ()
	{
		base.BeginPingpong ();
	}
}
