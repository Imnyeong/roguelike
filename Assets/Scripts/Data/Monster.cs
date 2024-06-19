using System.Collections;
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
    private Collider2D collider;

    private WaitForFixedUpdate waitTime;
    private const float knockbackPower = 0.5f;
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
        if (!isLive || animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
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
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        waitTime = new WaitForFixedUpdate();
    }
    private void SetStatus()
    {
        isLive = true;
        target = GameManager.instance.character.rigid;
        hp = maxHp;
        collider.enabled = isLive;
        rigid.simulated = isLive;
        animator.SetBool("Dead", !isLive);
        spriteRenderer.sortingOrder = 2;
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

        StartCoroutine(KnockBack());

        if (hp > 0)
        {
            animator.SetTrigger("Hit");
        }
        else
        {
            Dead();
        }
    }

    private IEnumerator KnockBack()
    {
        yield return waitTime;
        Vector3 charPos = GameManager.instance.character.transform.position;
        Vector3 direction = transform.position - charPos;
        rigid.AddForce(direction.normalized * knockbackPower, ForceMode2D.Impulse);
    }
    private void Dead()
    {
        isLive = false;
        collider.enabled = isLive;
        rigid.simulated = isLive;
        spriteRenderer.sortingOrder = 1;
        animator.SetBool("Dead", !isLive);
    }

    private void ActiveFalse()
    {
        this.gameObject.SetActive(false);
    }
}
