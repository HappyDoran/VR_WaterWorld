using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterRising : MonoBehaviour
{
    public GameObject Camera;
//    public GameObject Obj_water;
    public GameObject waterSight;

    public float targetHeight = 4f; // 물이 차오를 최종 높이
    public float riseTime = 30f; // 물이 차오르는 데 걸리는 시간

    private float initialHeight; // 초기 물의 높이
    private float currentHeight; // 현재 물의 높이
    private bool isRising = false; // 물이 차오르는 중인지 여부
    private float elapsedTime = 0f; // 경과한 시간

    public static bool isWater = false;
    public Color waterColor;
    public float waterFogDensity;

    private Color originColor;
    private float OriginFogDensity;

    private void Awake()
    {
        waterSight.SetActive(false);
    }

    private void Start()
    {
        initialHeight = transform.position.y;
        currentHeight = initialHeight;

        originColor = RenderSettings.fogColor;
        OriginFogDensity = RenderSettings.fogDensity;
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
        if (currentHeight > Camera.transform.position.y+1.7125)
        {
            waterSight.SetActive(true);

            // waterSight.transform.position = new Vector3(Camera.transform.position.x, Camera.transform.position.y, Camera.transform.position.z);
            // waterSight.transform.rotation = new Quaternion(-90, Camera.transform.rotation.y, Camera.transform.rotation.z, Camera.transform.rotation.w);
        }
    }

    public void StartRising()
    {
        isRising = !isRising;

        if (isRising)
        {
            // riseTime 값을 조금씩 감소시킴
            riseTime -= 2f;

            if (riseTime < 1f)
            {
                riseTime = 1f; // 최소값으로 제한 (0 이하로 내려가지 않도록 함)
            }
        }
    }

    public void StopRising()
    {
        isRising = false;
    }
}
