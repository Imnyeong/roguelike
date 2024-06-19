using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector] public Vector2 inputVector;
    private float speed = 5.0f;
    
    public Rigidbody2D rigid { get; private set; }
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public TargetTracker tracker { get; private set; }

    #region Unity Life Cycle
    private void Awake()
    {
        Init();
    }
    private void Update()
    {
        CheckInput();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void LateUpdate()
    {
        CheckFlip();
        ChaeckAnimation();
    }
    #endregion

    private void Init()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        tracker = GetComponent<TargetTracker>();
    }
    private void CheckInput()
    {
        inputVector.x = Input.GetAxisRaw("Horizontal");
        inputVector.y = Input.GetAxisRaw("Vertical");
    }
    private void CheckFlip()
    {
        if (inputVector.x == 0)
            return;
        spriteRenderer.flipX = inputVector.x < 0;
    }
    private void ChaeckAnimation()
    {
        animator.SetBool(StringData.AnimationMove, inputVector.magnitude != 0);
    }
    private void Move()
    {
        Vector2 moveVector = inputVector.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVector);
    }
}
