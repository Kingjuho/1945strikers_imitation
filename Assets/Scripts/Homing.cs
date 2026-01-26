using UnityEngine;

public class Homing : MonoBehaviour
{
    GameObject target;
    float speed = 3f;

    // 벡터의 뺄셈 = (종점 x - 시점 x, 종점 y - 시점 y)
    Vector2 dir;
    Vector2 dirNo;

    void Start()
    {
        
    }

    void Update()
    {
        // 플레이어 탐색
        target = GameObject.FindGameObjectWithTag("Player");

        // 벡터의 뺄셈(연산자 오버로딩으로 친절히 구현되어 있음)
        dir = target.transform.position - transform.position;
        // 단위벡터 정규화(방향 벡터만 구하는 것)
        dirNo = dir.normalized;
        transform.Translate(dirNo * speed * Time.deltaTime);
    }
}
