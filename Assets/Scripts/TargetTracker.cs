using UnityEngine;

public class TargetTracker : MonoBehaviour
{
    [SerializeField] private float trackRange;

    [SerializeField] private LayerMask targetLayer;
    private RaycastHit2D[] targets;
    public Transform currentTarget { get; private set; }

    #region Unity Life Cycle
    private void FixedUpdate()
    {
        FindTarget();
    }
    #endregion
    private void FindTarget()
    {
        FindAllTargets();
        currentTarget = GetTarget();
    }
    private void FindAllTargets()
    {
        targets = Physics2D.CircleCastAll(transform.position, trackRange, Vector2.zero, 0, targetLayer);
    }
    private Transform GetTarget()
    {
        Transform target = null;
        float minDistance = float.MaxValue;

        foreach(RaycastHit2D curRay in targets)
        {
            Vector2 charPos = transform.position;
            Vector2 targetPos = curRay.transform.position;

            float curDistance = Vector2.Distance(charPos, targetPos);
            
            if (minDistance > curDistance)
            {
                minDistance = curDistance;
                target = curRay.transform;
            }
        }
        return target;
    }
}
