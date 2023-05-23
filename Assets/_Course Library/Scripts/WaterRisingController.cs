using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterRisingController : MonoBehaviour
{
    public float targetHeight = 1f; // 물이 차오를 최종 높이
    public float riseTime = 5f; // 물이 차오르는 데 걸리는 시간
    public float delayTime = 120f; // 특정 조건 충족 후 지연되는 시간


    private float initialHeight; // 초기 물의 높이
    private float currentHeight; // 현재 물의 높이
    private bool startRising; // 물이 차오르기 시작했는지 여부
    private float elapsedTime; // 경과한 시간

    public XRGrabInteractable grabInteractable;
    public UnityEvent onActivate;
    public UnityEvent onDeactivate;

    private void Start()
    {
        initialHeight = transform.position.y;
        currentHeight = initialHeight;
        startRising = false;
        elapsedTime = 0f;

        grabInteractable.activated.AddListener(OnActivated);
        grabInteractable.deactivated.AddListener(OnDeactivated);
    }

    private void Update()
    {
        if (!startRising)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= delayTime)
            {
                startRising = true;
                elapsedTime = 0f;
            }
        }
        else
        {
            if (currentHeight < targetHeight)
            {
                float progress = Mathf.Clamp01(Time.deltaTime / riseTime);
                currentHeight = Mathf.Lerp(currentHeight, targetHeight, progress);

                Vector3 newPosition = transform.position;
                newPosition.y = currentHeight;
                transform.position = newPosition;
            }
        }
    }

    private void OnActivated(ActivateEventArgs args)
    {
        onActivate.Invoke();
    }

    private void OnDeactivated(DeactivateEventArgs args)
    {
        onDeactivate.Invoke();
    }
}
