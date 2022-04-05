using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LightningManager : MonoBehaviour
{
    // References
    [SerializeField] private Light DirectionLight;
    [SerializeField] private LightningPreset Preset;
    // Variables
    [SerializeField, Range(0, 24)] private float TimeOfDay;

    private void Update()
    {
        if (Preset == null)
        {
            return;
        }

        if (Application.isPlaying)
        {
            TimeOfDay += Time.deltaTime * 0.1f;
            TimeOfDay %= 24; // Clamp between 0-24
            UpdateLighting(TimeOfDay / 24f);
        }
        else
        {
            UpdateLighting(TimeOfDay / 24f);
        }
    }


    private void UpdateLighting(float timePercent)
    {
        RenderSettings.ambientLight = Preset.ambientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePercent);

        if(DirectionLight != null)
        {
            DirectionLight.color = Preset.DirectionalColor.Evaluate(timePercent);
            DirectionLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170f, 0));
        }
    }


    private void OnValidate()
    {
        if (DirectionLight != null)
        {
            return;
        }

        if (RenderSettings.sun!=null)
        {
            DirectionLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    DirectionLight = light;
                    return;
                }
            }
        }
    }
}
