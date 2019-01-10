using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EZTweenMoveBy : EZTween {
	public Vector3 DeltaPosition;
	private Vector3 FromPostionRuntime;
	private Vector3 DeltaPositionRuntime;
	protected override void Awake ()
	{
		base.Awake ();
	}

	public override void Restart ()
	{
		base.Restart ();
		if (IsLocal) {
			FromPostionRuntime = this.transform.localPosition;
		} else {
			FromPostionRuntime = this.transform.position;
		}
		DeltaPositionRuntime = DeltaPosition;
	}

	protected override void Update ()
	{
		base.Update ();
		if (IsRunning) {
			if (IsLocal) {
				this.transform.localPosition = this.Vector3TweenFunc (this.RunningTime, FromPostionRuntime, DeltaPositionRuntime, this.Duration);
			} else {
				this.transform.position = this.Vector3TweenFunc (this.RunningTime, FromPostionRuntime, DeltaPositionRuntime, this.Duration);
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
