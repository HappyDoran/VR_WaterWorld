using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterRising : MonoBehaviour
{
    public GameObject Camera;

    public GameObject waterSight;

    public float targetHeight = 4f; // 물이 차오를 최종 높이
    public float riseTime = 50f; // 물이 차오르는 데 걸리는 시간

    private float initialHeight; // 초기 물의 높이
    private float currentHeight; // 현재 물의 높이

    private bool isRemoteRising = false; // 물이 차오르는 중인지 여부
    private bool isShowerRising = false; // 물이 차오르는 중인지 여부
    private bool isLightRising = false; // 물이 차오르는 중인지 여부
    private bool isSaesuRising = false; // 물이 차오르는 중인지 여부

    private void Awake()
    {
        waterSight.SetActive(false);
    }

    private void Start()
    {
        initialHeight = transform.position.y;
        currentHeight = initialHeight;
    }

    private void Update()
    {
        if (
            (isRemoteRising || isShowerRising || isLightRising || isSaesuRising)
            && currentHeight < targetHeight)
        {
            // 물이 최종 높이까지 차오르는 비율을 계산
            float progress = Mathf.Clamp01(Time.deltaTime / riseTime);

            // 물의 현재 높이를 증가시킴
            currentHeight = Mathf.Lerp(currentHeight, targetHeight, progress);

            // 물의 위치를 업데이트
            Vector3 currentPos = transform.position;
            transform.position = new Vector3(
                currentPos.x,
                currentHeight,
                currentPos.z
            );
        }

        if (currentHeight > Camera.transform.position.y + 1.7125)
        {
            waterSight.SetActive(true);
        }
    }

    public void StartRemoteRising()
    {
        isRemoteRising = !isRemoteRising;
        StartRising(isRemoteRising);
    }

    public void StartShowerRising()
    {
        isShowerRising = !isShowerRising;
        StartRising(isShowerRising);
    }

    public void StartLightRising()
    {
        isLightRising = !isLightRising;
        StartRising(isLightRising);
    }

    public void StartSaesuRising()
    {
        isSaesuRising = !isSaesuRising;

        StartRising(isSaesuRising);
    }

    private void StartRising(Boolean boolRising)
    {
        if (boolRising)
        {
            // riseTime 값을 조금씩 감소시킴
            riseTime -= 3f;

            if (riseTime < 1f)
            {
                riseTime = 1f; // 최소값으로 제한 (0 이하로 내려가지 않도록 함)
            }
        }
        else
        {
            // riseTime 값을 조금씩 감소시킴
            riseTime += 3f;

            if (riseTime > 40f)
            {
                riseTime = 40f; // 최소값으로 제한 (0 이하로 내려가지 않도록 함)
            }
        }
    }
}