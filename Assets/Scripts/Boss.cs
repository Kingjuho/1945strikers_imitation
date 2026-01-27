using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    int flag = 1;
    int speed = 2;

    public GameObject mb;
    public GameObject mb2;
    public Transform pos1;
    public Transform pos2;

    private void Awake()
    {
        
    }

    private void Start()
    {
        Invoke("Hide", 2);
        StartCoroutine("BossMissile");
    }

    void Hide() { GameObject.Find("Text_BossWarning").SetActive(false); }

    IEnumerator BossMissile()
    {
        while(true)
        {
            Instantiate(mb, pos1.position, Quaternion.identity);
            Instantiate(mb, pos2.position, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }
    }
}
