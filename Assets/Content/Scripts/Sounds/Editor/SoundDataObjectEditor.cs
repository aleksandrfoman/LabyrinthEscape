using System;
using System.Collections;
using System.Collections.Generic;
using Sounds;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SoundDataSO))]
public class SoundDataObjectEditor :UnityEditor.Editor
{
    private void OnEnable()
    {
        SoundDataSO soundDataSO = (SoundDataSO) target;
        soundDataSO.AssignListNames();
        EditorUtility.SetDirty(soundDataSO);
    }
}
