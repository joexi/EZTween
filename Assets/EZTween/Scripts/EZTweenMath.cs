using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EZTweenMath {

	public static Vector3 QuadEaseOut(float t, Vector3 b, Vector3 c, float d)  
	{  
		return -c * (t /= d) * (t - 2) + b;  
	}  

	public static Vector3 QuadEaseIn(float t, Vector3 b, Vector3 c, float d)  
	{  
		return c * (t /= d) * t + b;  
	}

	public static Vector3 Linear(float t, Vector3 b, Vector3 c, float d)  
	{  
		Vector3 a = c * t / d + b;
		return c * t / d + b;  
	}  

	public static float QuadEaseOut(float t, float b, float c, float d)  
	{  
		return -c * (t /= d) * (t - 2) + b;  
	}  

	public static float QuadEaseIn(float t, float b, float c, float d)  
	{  
		return c * (t /= d) * t + b;  
	}

	public static float Linear(float t, float b, float c, float d)  
	{  
		return c * t / d + b;  
	}  
}
