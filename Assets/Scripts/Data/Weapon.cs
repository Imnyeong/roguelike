using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage { get; private set; }
    public int penetrate { get; private set; }
    private Rigidbody2D rigid;
    [SerializeField] private float speed = 5.0f;

    #region Unity Life Cycle
    private void Awake()
    {
        Init();
    }
    #endregion
    private void Init()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void Init(float _damage, int _penetrate, Vector2 _direction)
    {
        this.damage = _damage;
        this.penetrate = _penetrate;

        if (_penetrate > -1)
        {
            rigid.velocity = _direction * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Monster") || penetrate == -1)
            return;

        penetrate--;

        if (penetrate == -1)
        {
            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }
    }
}
