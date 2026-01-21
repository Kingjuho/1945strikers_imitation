using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed = 0.01f;
    Material bgMaterial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bgMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // 오프셋 조절을 통한 배경 흐르는 효과 적용
        float newOffsetY = bgMaterial.mainTextureOffset.y + scrollSpeed * Time.deltaTime;
        bgMaterial.mainTextureOffset = new Vector2(0, newOffsetY);
    }
}
