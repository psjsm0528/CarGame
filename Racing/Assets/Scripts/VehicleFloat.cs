using UnityEngine;

public class VehicleFloat : MonoBehaviour
{
    private Rigidbody rb;
    private bool isFloating = false;
    private float floatEndTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isFloating)
        {
            // 중력 비활성화
            rb.useGravity = false;

            // 일정 시간이 지나면 중력 복원
            if (Time.time >= floatEndTime)
            {
                rb.useGravity = true;
                isFloating = false;
            }
        }
    }

    // 외부에서 호출하여 공중 상태 시작
    public void StartFloating(float duration)
    {
        isFloating = true;
        floatEndTime = Time.time + duration;

        // 순간 위로 떠오르는 힘는 Item.cs에서 주었음
    }
}
