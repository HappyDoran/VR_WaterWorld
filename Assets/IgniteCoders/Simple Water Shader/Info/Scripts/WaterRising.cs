using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterRising : MonoBehaviour
{
    public GameObject Camera;

    public GameObject waterSight;

    public float targetHeight = 3.5f; // 물이 차오를 최종 높이
    public float riseTime = 70f; // 물이 차오르는 데 걸리는 시간

    private float initialHeight; // 초기 물의 높이
    private float currentHeight; // 현재 물의 높이

    private bool isRemoteRising = false; // 물이 차오르는 중인지 여부
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
            (isRemoteRising || isLightRising || isSaesuRising)
            && currentHeight < targetHeight)
        {
            var count = 0;
            if (isRemoteRising)
                count++;
            if (isLightRising)
                count++;
            if (isSaesuRising)
                count++;

            var ratio = (currentHeight - initialHeight) / (targetHeight - initialHeight);
            var countRatio = count / 3f;
            if (ratio <= countRatio)
            {
                float progress = Mathf.Clamp01(Time.deltaTime / riseTime);
                currentHeight = Mathf.Lerp(currentHeight, targetHeight, progress);

                // 물의 위치를 업데이트
                Vector3 currentPos = transform.position;
                transform.position = new Vector3(
                    currentPos.x,
                    currentHeight,
                    currentPos.z
                );
            }
        }

        if (currentHeight > Camera.transform.position.y + 2)
        {
            waterSight.SetActive(true);
        }
    }

    public void StartRemoteRising()
    {
        isRemoteRising = !isRemoteRising;
        StartRising(isRemoteRising);
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