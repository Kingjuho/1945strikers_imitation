using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float speed = 4.0f;
    [SerializeField] float attack;

    void Start()
    {
        
    }

    void Update()
    {
        // 위쪽 방향으로 발사
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    // 카메라 밖으로 나갈 경우 삭제
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
