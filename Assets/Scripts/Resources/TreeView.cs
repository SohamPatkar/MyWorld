using UnityEngine;

public class TreeView : Resources, IDamageable
{
    private Animator treeAnimator;

    void Start()
    {
        treeAnimator = GetComponent<Animator>();
    }

    public void TakeDamage()
    {
        Health -= 25;

        treeAnimator.Play("Shake");

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
        GameManager.Instance.PlayerView.GetPlayerController().AddWood(ResourceToAdd);
    }
}
