using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float rowStart = -2f;
    [SerializeField] float rowEnd = 2f;
    [SerializeField] float startTime = 1;
    [SerializeField] float stopSpawn = 10;

    [SerializeField] GameObject monster1;
    [SerializeField] GameObject monster2;

    [SerializeField] GameObject text_BossWarning;

    bool _swi = true;

    void Start()
    {
        StartCoroutine("SpawnRandom");
        Invoke("SpawnStop", stopSpawn);
    }

    void Update()
    {
        
    }

    // 랜덤 스폰 코루틴
    IEnumerator SpawnRandom()
    {
        while(_swi)
        {
            // 1초 마다
            yield return new WaitForSeconds(startTime);
            
            // x, y 위치 선정
            float x = Random.Range(rowStart, rowEnd);
            float y = transform.position.y;
            Vector2 xy = new Vector2(x, y);

            // 생성
            Instantiate(monster1, xy, Quaternion.identity);
        }
    }

    // 스폰 중지
    void SpawnStop()
    {
        _swi = false;
        StopCoroutine("SpawnRandom");

        SpawnBoss();
    }

    // 보스
    void SpawnBoss()
    {
        text_BossWarning.SetActive(true);
        StartCoroutine("Shake");

        Vector3 pos = new Vector3(0, 3f, 0);
        Instantiate(monster2, pos, Quaternion.identity);
    }

    IEnumerator Shake()
    {
        int shakeCnt = 30;
        while (shakeCnt > 0)
        {
            CameraImpulse.Instance.CameraShakeShow();
            yield return new WaitForSeconds(0.1f);
            shakeCnt--;
        }
    }
}
