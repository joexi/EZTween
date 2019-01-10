using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EZTweenRotateTo : EZTween {

	public Vector3 ToEulerAngles;
	private Vector3 Speed;

	protected override void Awake ()
	{
		base.Awake ();
	}

	public override void Restart ()
	{
		base.Restart ();
		if (IsLocal) {
			Speed = (ToEulerAngles - this.transform.localEulerAngles) / Duration;
		} else {
			Speed = (ToEulerAngles - this.transform.eulerAngles) / Duration;
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
					this.transform.localEulerAngles += Speed * Time.deltaTime;
				} else {
					this.transform.eulerAngles += Speed * Time.deltaTime;
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
		Speed *= -1;
		LeftTime = Duration;
	}
}
