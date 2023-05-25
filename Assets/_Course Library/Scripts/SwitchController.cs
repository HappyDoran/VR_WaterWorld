using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchController : MonoBehaviour
{
    public List<Light> targetLights;
    public XRBaseInteractable interactable;
    private bool isOn = false; // 스위치 상태

    private void Start()
    {
        // interactable.selectEntered.AddListener(ToggleSwitch);
    }

    public void ToggleSwitch(BaseInteractionEventArgs args)
    {
        isOn = !isOn;
        foreach (var light in targetLights)
        {
            light.enabled = isOn;
        }
    }
}