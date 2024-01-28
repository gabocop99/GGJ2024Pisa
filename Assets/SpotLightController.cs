using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightController : MonoBehaviour
{
    private Light _light;
    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    public void TurnOffLight()
    {
        _light.enabled = false;
    }

    public void TurnOnLight()
    {
        _light.enabled = true;
    }
}
