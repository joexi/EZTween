using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EZTweenMoveTo : EZTween {
	public Vector3 FromPostion;
	public Vector3 ToPosition;
	private Vector3 Speed;

	protected override void Awake ()
	{
		base.Awake ();
	}

	public override void Restart ()
	{
		base.Restart ();
		Speed = (ToPosition - FromPostion) / Duration;
		if (IsLocal) {
			this.transform.localPosition = FromPostion;
		} else {
			this.transform.position = FromPostion;
		}
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
		Speed = (FromPostion - ToPosition) / Duration;
		LeftTime = Duration;
	}
}
