using UnityEngine;

public class MonsterBullet2 : MonoBehaviour
{
    //총알 속도
    public float Speed = 3f;
    //이동방향
    Vector2 vec2 = Vector2.down;


    void Update()
    {
        //총알 이동
        transform.Translate(vec2 * Speed * Time.deltaTime);
    }


    public void Move(Vector2 vec)
    {
        //이동방향 설정
        vec2 = vec;
    }


    private void OnBecameInvisible()
    {
        //화면밖으로 나가면 오브젝트 제거
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //플레이어 맞으면 오브젝트 제거
            Destroy(gameObject);
        }
    }
}
