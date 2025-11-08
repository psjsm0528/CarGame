using UnityEngine;

public class DriftEffect : MonoBehaviour
{
    public AudioSource driftSound;        // 드리프트 소리
    public GameObject tireMarkPrefab;     // 타이어 자국 프리팹
    public float markLifeTime = 3f;       // 자국이 사라지는 시간

    public Transform leftWheelPos;        // 왼쪽 뒷바퀴 위치
    public Transform rightWheelPos;       // 오른쪽 뒷바퀴 위치

    private GameObject leftMark;
    private GameObject rightMark;

    void Update()
    {
        bool drifting = Input.GetKey(KeyCode.LeftShift);

        // === 드리프트 소리 ===
        if (drifting)
        {
            if (!driftSound.isPlaying)
                driftSound.Play();
        }
        else
        {
            if (driftSound.isPlaying)
                driftSound.Stop();
        }

        // === 드리프트 자국 ===
        if (drifting)
        {
            CreateOrUpdateMark(ref leftMark, leftWheelPos);
            CreateOrUpdateMark(ref rightMark, rightWheelPos);
        }
        else
        {
            StopMark(leftMark);
            StopMark(rightMark);
            leftMark = null;
            rightMark = null;
        }
    }

    void CreateOrUpdateMark(ref GameObject markObj, Transform wheelPos)
    {
        if (markObj == null)
        {
            markObj = Instantiate(tireMarkPrefab, wheelPos.position, Quaternion.identity);
            Destroy(markObj, markLifeTime);
        }

        LineRenderer lr = markObj.GetComponent<LineRenderer>();
        lr.positionCount++;
        lr.SetPosition(lr.positionCount - 1, wheelPos.position);
    }

    void StopMark(GameObject markObj)
    {
        if (markObj != null)
        {
            // 더 이상 포지션 추가 안함 → 자연스럽게 남음
        }
    }
}
