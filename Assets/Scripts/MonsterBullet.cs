using UnityEngine;

public class MonsterBullet : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float attack;

    void Start()
    {
        
    }

    void Update()
    {
        // 아래쪽 방향으로 발사
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    // 카메라 밖으로 나갈 경우 삭제
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // isTrigger가 체크된 객체와 충돌 시 호출되는 함수
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

        }

        Destroy(gameObject);
    }
}
