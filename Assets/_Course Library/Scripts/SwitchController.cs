using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchController : MonoBehaviour
{
    public Light targetLight; // 스위치로 제어할 라이트 컴포넌트
    public XRBaseInteractable interactable;
    private bool isOn = false; // 스위치 상태

    private void Start()
    {
        interactable.selectEntered.AddListener(ToggleSwitch);
    }

    private void ToggleSwitch(BaseInteractionEventArgs args)
    {
        isOn = !isOn;
        targetLight.enabled = isOn;
        if (isOn)
        {
            Debug.Log("Toggle ON");
        }
        else
        {
            Debug.Log("Toggle OFF");
        }
    }
}