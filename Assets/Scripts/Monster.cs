using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] int hp = 100;
    [SerializeField] float speed = 2f;
    [SerializeField] float delay = 1f;
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject item;
    [SerializeField] GameObject deadEffect;


    void Start()
    {
        InvokeRepeating("Shoot", delay, delay);
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    // 카메라 밖으로 나갈 경우 삭제
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // 총알 발사 함수
    void Shoot()
    {
        Instantiate(bullet, pos1.position, Quaternion.identity);
        Instantiate(bullet, pos2.position, Quaternion.identity);
    }    

    // 데미지를 받는 함수
    public void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            // 아이템 드롭
            Instantiate(item, transform.position, Quaternion.identity);
            Dead();
        }
    }

    // 사망 처리 함수
    void Dead()
    {
        DeadEffect();
        Destroy(gameObject);
    }

    // 사망 이펙트
    void DeadEffect()
    {
        GameObject go = Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(go, 1);
    }
}
