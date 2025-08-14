using UnityEngine;

[RequireComponent(typeof(EnemyShooter), typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private readonly int ShootParamHash = Animator.StringToHash("Shoot");

    private EnemyShooter _shooter;
    private Animator _animator;

    private void Awake()
    {
        _shooter = GetComponent<EnemyShooter>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _shooter.Shooted += OnShooted;
    }

    private void OnDisable()
    {
        _shooter.Shooted -= OnShooted;
    }

    private void OnShooted()
    {
        _animator.SetTrigger(ShootParamHash);
    }
}