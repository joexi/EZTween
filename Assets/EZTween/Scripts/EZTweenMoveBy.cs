using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EZTweenMoveBy : EZTween {
	public Vector3 DeltaPosition;
	private Vector3 Speed;

	protected override void Awake ()
	{
		base.Awake ();
	}

	public override void Restart ()
	{
		base.Restart ();
		Speed = DeltaPosition / Duration;
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
				if (IsLocal) {
					this.transform.localPosition += Speed * Time.deltaTime;
				} else {
					this.transform.position += Speed * Time.deltaTime;
				}
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
		Speed = - DeltaPosition / Duration;
		LeftTime = Duration;
	}
}
