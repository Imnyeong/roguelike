using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private float speed;
    private float hp;
    private float maxHp;
    private int rewardExp;
    private int rewardCoin;

    private bool isLive = false;
    [SerializeField] private RuntimeAnimatorController[] animators;
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;

    private Animator animator;
    private Rigidbody2D target;
    private Collider2D collision;

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
        if (!isLive || animator.GetCurrentAnimatorStateInfo(0).IsName(StringData.AnimationHit))
            return;

        Move();
    }
    private void LateUpdate()
    {
        RemoveVelocity();

        if (!isLive)
            return;

        CheckFlip();
    }
    #endregion
    private void Init()
    {
        rigid = GetComponent<Rigidbody2D>();
        collision = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        waitTime = new WaitForFixedUpdate();
    }
    private void SetStatus()
    {
        isLive = true;
        target = GameManager.instance.character.rigid;
        hp = maxHp;
        collision.enabled = isLive;
        rigid.simulated = isLive;
        animator.SetBool(StringData.AnimationDead, !isLive);
        ChangeSortingOrder();
    }
    public void SetData(MonsterData _data)
    {
        spriteRenderer.sprite = _data.sprite;
        animator.runtimeAnimatorController = _data.animator;
        speed = _data.speed;
        maxHp = _data.maxHp;
        rewardExp = _data.rewardExp;
        rewardCoin = _data.rewardCoin;

        hp = maxHp;
    }
    private void Move()
    {
        Vector2 direction = target.position - rigid.position;
        Vector2 moveVector = direction.normalized * speed * Time.fixedDeltaTime;

        rigid.MovePosition(rigid.position + moveVector);
    }
    private void RemoveVelocity()
    {
        rigid.velocity = Vector2.zero;
    }
    private void CheckFlip()
    {
        spriteRenderer.flipX = target.position.x < rigid.position.x;
    }
    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (!_collision.CompareTag(StringData.TagWeapon))
            return;

        Hit(_collision);
    }

    private void Hit(Collider2D _collision)
    {
        hp -= _collision.GetComponent<Weapon>().damage;

        StartCoroutine(KnockBack());

        if (hp > 0)
        {
            animator.SetTrigger(StringData.AnimationHit);
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
        Vector3 direction = (transform.position - charPos).normalized;
        rigid.AddForce(direction * knockbackPower, ForceMode2D.Impulse);
    }
    private void Dead()
    {
        isLive = false;
        collision.enabled = isLive;
        rigid.simulated = isLive;
        ChangeSortingOrder();
        animator.SetBool(StringData.AnimationDead, !isLive);
        GameManager.instance.GetCoin(rewardCoin);
        GameManager.instance.character.GetExp(rewardExp);
    }
    private void ChangeSortingOrder()
    {
        spriteRenderer.sortingOrder = isLive ? 2 : 1;
    }
    private void ActiveFalse()
    {
        this.gameObject.SetActive(false);

    }
}
