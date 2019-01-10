using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class NewBehaviourScript : Editor {

	[MenuItem("aaa/bbb")]
	public static void bbb() {
		
		BuildPipeline.BuildAssetBundles (Application.dataPath + "/", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.iOS);
	}
}
