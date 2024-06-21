using UnityEngine;

public class Character : MonoBehaviour
{
    [HideInInspector] public Vector2 inputVector;
    public int characterId { get; private set; }
    private float hp;
    private float maxHp;
    private float speed;

    private int level = 1;
    private float exp = 0.0f;
    private float maxExp;
    public Rigidbody2D rigid { get; private set; }
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public TargetTracker tracker { get; private set; }
    public WeaponSpawner weapon { get; private set; }

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
    public void SetData(int _characterId)
    {
        CharacterData _data = Resources.LoadAll<CharacterData>(StringData.pathCharacterData)[_characterId];
        characterId = _characterId;
        maxHp = _data.maxHp;
        speed = _data.speed;
        spriteRenderer.sprite = _data.sprite;
        animator.runtimeAnimatorController = _data.animator;
        AddWeapon(_data.defaultWeapon);

        hp = maxHp;
    }
    public void AddWeapon(int _weaponId)
    {
        GameObject go = Instantiate(new GameObject(), this.transform);
        weapon = go.AddComponent<WeaponSpawner>();
        weapon.SetData(Resources.LoadAll<WeaponData>(StringData.pathWeaponData)[_weaponId]);
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
    public float GetCurrentHp()
    {
        return hp / maxHp;
    }
    public void GetExp(int _value)
    {
        exp += _value;
        CheckExp();
    }
    public void CheckExp()
    {
        UIManager.instance.UpdateExp();

        if (exp >= maxExp)
        {
            LevelUp();
        }
    }
    public void LevelUp()
    {
        level++;
        exp -= maxExp;
        maxExp = level * 100.0f;

        UIManager.instance.ShowUpgrade();
    }
    public float GetCurrentExp()
    {
        return exp / maxExp;
    }
}
