using UnityEngine;

public class ItemPower : MonoBehaviour
{
    public float itemVelocity = 100f;

    Rigidbody2D rb = null;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.AddForce(new Vector3(itemVelocity, itemVelocity, 0f));
    }

    void Update()
    {
        
    }
}