using Unity.Cinemachine;
using UnityEngine;

public class CameraImpulse : MonoBehaviour
{
    public static CameraImpulse Instance;

    [SerializeField] CinemachineImpulseSource impulseSource;

    private void Awake()
    {
        // 유일성 보장
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void CameraShakeShow(float force = 1.0f)
    {
        impulseSource.GenerateImpulse(force);
    }
}
