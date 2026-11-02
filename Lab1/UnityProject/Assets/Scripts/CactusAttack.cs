
using UnityEngine;

public class CactusAttack : MonoBehaviour
{
    public Transform otherCactus;
    public float attackDistance = 0.25f;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (otherCactus == null || animator == null)
            return;

        float distance = Vector3.Distance(
            transform.position,
            otherCactus.position
        );

        bool attacking = distance < attackDistance;

        animator.SetBool("isAttacking", attacking);
    }
}
