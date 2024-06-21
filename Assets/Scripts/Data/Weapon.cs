using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage { get; private set; }
    public int penetrate { get; private set; }
    private WeaponType weaponType;
    private float speed;

    private Rigidbody2D rigid;
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
    public void SetWeapon(float _damage, WeaponType _type, Vector2 _direction, int _penetrate = 0, float _speed = 0)
    {
        this.damage = _damage;
        this.penetrate = _penetrate;
        this.weaponType = _type;

        if (_type == WeaponType.Shoot)
        {
            rigid.velocity = _direction * _speed;
        }
    }
    private void ActiveFalse()
    {
        rigid.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(StringData.TagMonster) || weaponType == WeaponType.Spin)
            return;

        Hit();
    }

    private void Hit()
    {
        penetrate--;

        if (penetrate <= 0)
        {
            ActiveFalse();
        }
    }
    private void OnTriggerExit2D(Collider2D _collision)
    {
        if (!_collision.CompareTag(StringData.TagReposRange))
            return;

        ActiveFalse();
    }
}
