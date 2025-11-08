using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 20f;        // 전/후진 속도
    public float turnSpeed = 80f;        // 기본 회전 속도

    public float driftFactor = 0.85f;    // 드리프트 때 미끄러짐 정도
    public float normalFactor = 0.2f;    // 일반 주행 시 미끄러짐 감소
    public float driftTurnMultiplier = 1.5f; // 드리프트 시 회전 증가

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // 차량 옆으로 넘어지는 것 방지
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal"); // A, D
        float v = Input.GetAxisRaw("Vertical");   // W, S

        bool drifting = Input.GetKey(KeyCode.LeftShift);

        // === 1. 전진/후진 ===
        Vector3 forwardMove = transform.forward * v * moveSpeed;
        rb.linearVelocity = new Vector3(forwardMove.x, rb.linearVelocity.y, forwardMove.z);

        // === 2. 회전 (전진할 때만) ===
        if (v != 0)
        {
            float turn = h * turnSpeed * Time.fixedDeltaTime;

            // 드리프트 중이면 회전 더 강하게
            if (drifting)
                turn *= driftTurnMultiplier;

            transform.Rotate(0, turn * (v > 0 ? 1 : -1), 0);
        }

        // === 3. 드리프트 슬라이드 (핵심 부분) ===
        Vector3 localVel = transform.InverseTransformDirection(rb.linearVelocity);

        if (drifting)
        {
            // 드리프트 = 좌우 속도 거의 유지 → 미끄러짐 커짐
            localVel.x *= driftFactor;
        }
        else
        {
            // 일반 주행 = 좌우 미끄러짐 줄이기
            localVel.x *= normalFactor;
        }

        rb.linearVelocity = transform.TransformDirection(localVel);
    }
}
