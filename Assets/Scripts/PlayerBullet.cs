using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float speed = 4.0f;
    [SerializeField] int attack = 10;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().TakeDamage(attack);
            Destroy(gameObject);
        }
    }
}
