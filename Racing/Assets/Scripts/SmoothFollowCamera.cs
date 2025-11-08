using UnityEngine;

public class SmoothFollowCamera : MonoBehaviour
{
    [Header("Target Settings")]
    public Transform target; // 따라갈 대상 (자동차)

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(0f, 5f, -10f); // 카메라 위치 오프셋
    public float followSpeed = 5f; // 따라가는 속도
    public float rotateSpeed = 5f; // 회전 부드럽게 조정

    void LateUpdate()
    {
        if (target == null) return;

        // 목표 위치 계산
        Vector3 targetPosition = target.position + target.TransformDirection(offset);

        // 부드럽게 이동
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // 카메라가 대상 바라보도록 회전
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }
}
