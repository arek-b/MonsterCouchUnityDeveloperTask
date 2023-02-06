using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Enemy.Spawner))]
public class EnemySpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var myScript = (Enemy.Spawner)target;

        const string BUTTON_TEXT = "Spawn enemies";

        if (GUILayout.Button(BUTTON_TEXT))
        {
            Undo.RecordObject(myScript, BUTTON_TEXT);
            myScript.Spawn();
        }
    }
}