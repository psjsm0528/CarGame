using UnityEngine;

public class Item : MonoBehaviour
{
    public float floatDuration = 3f; // 차량이 공중에 뜨는 시간
    public float floatForce = 10f;   // 공중으로 뜨는 힘

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 차량이 Player 태그일 때
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // 위쪽으로 순간 힘 주기
                rb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);

                // 공중 상태 관리
                VehicleFloat vehicleFloat = other.GetComponent<VehicleFloat>();
                if (vehicleFloat != null)
                {
                    vehicleFloat.StartFloating(floatDuration);
                }
            }

            // 아이템은 충돌 후 제거
            Destroy(gameObject);
        }
    }
}
