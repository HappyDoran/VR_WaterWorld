// using UnityEngine;

// public class WaterRising : MonoBehaviour
// {
//     public float targetHeight = 1f; // 물이 차오를 최종 높이
//     public float riseTime = 5f; // 물이 차오르는 데 걸리는 시간

//     private float initialHeight; // 초기 물의 높이
//     private float currentHeight; // 현재 물의 높이

//     private void Start()
//     {
//         initialHeight = transform.position.y;
//         currentHeight = initialHeight;
//     }

//     private void Update()
//     {
//         if (currentHeight < targetHeight)
//         {
//             // 물이 최종 높이까지 차오르는 비율을 계산
//             float progress = Mathf.Clamp01(Time.deltaTime / riseTime);

//             // 물의 현재 높이를 증가시킴
//             currentHeight = Mathf.Lerp(currentHeight, targetHeight, progress);

//             // 물의 위치를 업데이트
//             Vector3 newPosition = transform.position;
//             newPosition.y = currentHeight;
//             transform.position = newPosition;
//         }
//     }
// }
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterRising : MonoBehaviour
{
    public float targetHeight = 4f; // 물이 차오를 최종 높이
    public float riseTime = 30f; // 물이 차오르는 데 걸리는 시간

    private float initialHeight; // 초기 물의 높이
    private float currentHeight; // 현재 물의 높이
    private bool isRising = false; // 물이 차오르는 중인지 여부
    private float elapsedTime = 0f; // 경과한 시간

    private void Start()
    {
        initialHeight = transform.position.y;
        currentHeight = initialHeight;
    }

    private void Update()
    {
        if (isRising && currentHeight < targetHeight)
        {
            // 물이 최종 높이까지 차오르는 비율을 계산
            float progress = Mathf.Clamp01(Time.deltaTime / riseTime);

            // 물의 현재 높이를 증가시킴
            currentHeight = Mathf.Lerp(currentHeight, targetHeight, progress);

            // 물의 위치를 업데이트
            Vector3 newPosition = transform.position;
            newPosition.y = currentHeight;
            transform.position = newPosition;
        }
    }

    public void StartRising()
    {
        isRising = true;
    }

    public void StopRising()
    {
        isRising = false;
    }
}
