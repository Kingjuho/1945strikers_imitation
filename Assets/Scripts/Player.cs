using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    Animator animator;

    // SetBool("isLeft") 방식은 해시 변환 작업이 숨어있기 때문에 미리 변환시켜서 최적화
    static readonly int LeftHash = Animator.StringToHash("isLeft");
    static readonly int RightHash = Animator.StringToHash("isRight");
    static readonly int UpHash = Animator.StringToHash("isUp");

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Move(input);
        UpdateAnimator(input);
    }

    // 이동 함수
    private void Move(Vector2 input)
    {
        Vector3 delta = new Vector3(input.x, input.y, 0f) * (moveSpeed * Time.deltaTime);
        transform.Translate(delta);
        MoveInCamera();
    }

    // 애니메이션 변경 함수
    private void UpdateAnimator(Vector2 input)
    {
        bool left = input.x <= -0.5f;
        bool right = input.x >= 0.5f;
        bool up = input.y >= 0.5f;

        SetBoolIfChanged(LeftHash, left);
        SetBoolIfChanged(RightHash, right);
        SetBoolIfChanged(UpHash, up);
    }

    // 조건이 거짓(상태 변경)이면 SetBool
    private void SetBoolIfChanged(int hash, bool value)
    {
        if (animator.GetBool(hash) != value)
            animator.SetBool(hash, value);
    }

    // 카메라 밖으로 이동 못하게 만드는 함수
    private void MoveInCamera()
    {
        // 월드 좌표 Viewport 좌표로 변환
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);

        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewPos);
        transform.position = worldPos;
    }
}
