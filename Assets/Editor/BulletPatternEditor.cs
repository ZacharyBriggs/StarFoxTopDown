using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BulletPatternScriptable))]
public class BulletPatternEditor : Editor
{

	public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BulletPatternScriptable bp = (BulletPatternScriptable)target;
        if (GUILayout.Button("Add Bullet"))
        {
            bp.AddBullet();
        }
    }
}
