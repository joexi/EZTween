﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EZTweenType {
	None = 0,
	Linear = 1,
	QuadEaseOut = 2,
	QuadEaseIn = 3,
}

public class EZTween : MonoBehaviour {
	protected delegate float EZTweenDelegateFloat (float t, float b, float c, float d);
	protected delegate Vector3 EZTweenDelegateVector3 (float t, Vector3 b, Vector3 c, float d);
	protected EZTweenDelegateFloat FloatTweenFunc;
	protected EZTweenDelegateVector3 Vector3TweenFunc;

	public EZTweenType TweenType;
	public bool IsLocal;
	public float Delay;
	public float Duration;
	public bool PingPong;
	public int RepeatCount = 1;


	protected int LifeCount;
	protected float LifeTime;
	protected float RunningTime;

	protected bool IsRunning;
	protected bool IsPingponging;

	protected virtual void Awake() {

	}

	protected virtual void Start () {

	} 

	protected virtual void OnEnable () {

	}

	protected virtual void OnDisable () {

	}

	protected virtual void Update () {
		LifeTime += Time.deltaTime;
		if (!IsRunning) {
			if (LifeTime >= Delay && LifeCount < RepeatCount) {
				this.Restart ();
			}
		}
		if (IsPingponging) {
			if (this.RunningTime > 0) {
				this.RunningTime -= Time.deltaTime;
				if (this.RunningTime <= 0) {
					this.End ();
				}
			}
		} else {
			if (this.RunningTime < Duration) {
				this.RunningTime += Time.deltaTime;
				if (this.RunningTime >= Duration) {
					this.End ();
				}
			}
		}
	}

	public virtual void End() {
		if (this.PingPong) {
			if (!this.IsPingponging) {
				BeginPingpong ();
				return;
			} else {
				EndPingpong ();
			}
		}

		this.IsRunning = false;
	}

	public virtual void BeginPingpong() {
		IsPingponging = true;
	}

	public virtual void EndPingpong() {
		IsPingponging = false;
	}

	public virtual void Restart () {
		RunningTime = 0;
		LifeTime = 0;
		IsRunning = true;
		LifeCount++;
		switch (this.TweenType) {
		case EZTweenType.None:
		case EZTweenType.Linear:
			{
				this.FloatTweenFunc = EZTweenMath.Linear;
				this.Vector3TweenFunc = EZTweenMath.Linear;
				break;
			}
		case EZTweenType.QuadEaseIn:
			{
				this.FloatTweenFunc = EZTweenMath.QuadEaseIn;
				this.Vector3TweenFunc = EZTweenMath.QuadEaseIn;
				break;
			}
		case EZTweenType.QuadEaseOut:
			{
				this.FloatTweenFunc = EZTweenMath.QuadEaseOut;
				this.Vector3TweenFunc = EZTweenMath.QuadEaseOut;
				break;
			}
		}
	}

	public virtual void Stop () {

	}

	public virtual void Resume () {

	}

	public virtual void Clear() {
		LifeTime = 0;
		LifeCount = 0;
		IsRunning = false;
	}

	public virtual void Finshed() {
		
	}


}
