using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Start()
    {
        
    }

    void Update()
    {
        // 방향 * 시간 * 스피드
        float distanceX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * moveSpeed;
        float distanceY = Input.GetAxisRaw("Vertical") * Time.deltaTime * moveSpeed;
        transform.Translate(distanceX, distanceY, 0);
    }
}
