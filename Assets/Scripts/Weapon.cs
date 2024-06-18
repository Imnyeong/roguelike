using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float damage { get; private set; }
    public int penetrate { get; private set; }

    public void Init(float _damage, int _penetrate)
    {
        this.damage = _damage;
        this.penetrate = _penetrate;
    }
}
