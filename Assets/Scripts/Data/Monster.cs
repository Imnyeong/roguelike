using UnityEngine;

public class Monster : MonoBehaviour
{
    private float speed;
    private float hp;
    private float maxHp;

    private bool isLive = false;

    [SerializeField] private RuntimeAnimatorController[] animators;
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;

    private Animator animator;
    private Rigidbody2D target;

    #region Unity Life Cycle
    private void Awake()
    {
        Init();
    }
    private void OnEnable()
    {
        SetStatus();
    }
    private void FixedUpdate()
    {
        if (!isLive)
            return;

        Move();
    }
    private void LateUpdate()
    {
        if (!isLive)
            return;

        CheckFlip();
    }
    #endregion
    private void Init()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void SetStatus()
    {
        target = GameManager.instance.character.rigid;
        isLive = true;
        hp = maxHp;
    }
    public void SetData(MonsterData _data)
    {
        animator.runtimeAnimatorController = animators[_data.spriteType];
        speed = _data.speed;
        maxHp = _data.hp;
        hp = _data.hp;
    }
    private void Move()
    {
        Vector2 direction = target.position - rigid.position;
        Vector2 moveVector = direction.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + moveVector);
        rigid.velocity = Vector2.zero;
    }

    private void CheckFlip()
    {
        spriteRenderer.flipX = target.position.x < rigid.position.x;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Weapon"))
            return;

        hp -= collision.GetComponent<Weapon>().damage;

        if(hp > 0)
        {
            
        }
        else
        {
            Dead();
        }
    }
    private void Dead()
    {
        this.gameObject.SetActive(false);
    }
}
