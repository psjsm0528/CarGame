using UnityEngine;

public class CameraFollowSimple : MonoBehaviour
{
    public Transform target;          // 자동차
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smooth = 5f;         // 부드럽게 따라오는 정도

    void LateUpdate()
    {
        if (!target) return;

        // 1. 차 기준 오프셋 방향 계산 (회전 포함)
        Vector3 desiredPosition = target.position + target.rotation * offset;

        // 2. 부드럽게 위치 이동
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smooth * Time.deltaTime);

        // 3. 차가 바라보는 방향으로 카메라도 회전
        Quaternion desiredRot = Quaternion.LookRotation(target.forward, Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRot, smooth * Time.deltaTime);
    }
}
