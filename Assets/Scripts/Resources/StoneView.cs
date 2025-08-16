using UnityEngine;

public class StoneView : Resources, IDamageable
{
    private Animator stoneAnimator;

    void Start()
    {
        stoneAnimator = GetComponent<Animator>();
    }

    public void TakeDamage()
    {
        Health -= 5;

        stoneAnimator.Play("Shake");

        if (Health < 0)
        {
            Health = 0;
            Die();
        }
    }

    public override void Die()
    {
        GiveResources();
        Destroy(gameObject);
    }

    public override void GiveResources()
    {
        GameManager.Instance.PlayerView.GetPlayerController().AddStone(ResourceToAdd);
    }
}
