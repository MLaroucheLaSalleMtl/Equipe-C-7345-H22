using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptables/Lighting Preset",order =1)]
public class LightningPreset : ScriptableObject
{
    public Gradient ambientColor;
    public Gradient DirectionalColor;
    public Gradient FogColor;
}
