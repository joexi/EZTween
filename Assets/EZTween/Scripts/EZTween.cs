using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EZTween : MonoBehaviour {
	public bool IsLocal;
	public float Delay;
	public float Duration;
	public bool PingPong;
	public int RepeatCount = 1;


	protected int LifeCount;
	protected float LifeTime;
	protected float LeftTime;

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
	}

	public virtual void End() {
		if (this.PingPong) {
			if (!this.IsPingponging) {
				BeginPingpong ();
				return;
			}
		}

		this.IsRunning = false;
	}

	public virtual void BeginPingpong() {
		IsPingponging = true;
	}

	public virtual void Restart () {
		LifeTime = 0;
		IsRunning = true;
		LifeCount++;
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
}
