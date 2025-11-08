using UnityEngine;
using UnityEngine.AI;

public class AICarMove : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // NavMeshAgent가 활성화되어 있고 NavMesh 위에 있을 때만 접근
        if (agent != null && agent.enabled && agent.isOnNavMesh)
        {
            float remainingDistance = agent.remainingDistance;

            // 목적지 도착 확인 (예시)
            if (!agent.pathPending && remainingDistance <= agent.stoppingDistance)
            {
                Debug.Log($"{name}: 목적지 도착!");
                // 도착 시 실행할 코드 (예: 다음 목표 설정)
            }
        }
        else
        {
            Debug.LogWarning($"{name}: NavMeshAgent is not on a NavMesh or not ready!");
        }
    }

    // 🟩 외부에서 호출할 초기화 함수
    public void InitAICar()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError($"{name}: NavMeshAgent 컴포넌트를 찾을 수 없습니다!");
            return;
        }

        // NavMesh 위에 제대로 올라가 있는지 확인
        if (agent.enabled && agent.isOnNavMesh)
        {
            agent.isStopped = false;      // 멈춤 해제
            agent.ResetPath();            // 기존 경로 초기화
            Debug.Log($"{name}: AI Car Initialized successfully!");
        }
        else
        {
            Debug.LogWarning($"{name}: InitAICar() 실패 — NavMesh 위에 있지 않음.");
        }
    }
}
