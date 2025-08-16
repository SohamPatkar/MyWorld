using UnityEngine;

public class Weapon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IDamageable>() != null)
        {
            IDamageable resource = other.gameObject.GetComponent<IDamageable>();
            resource.TakeDamage();
        }
    }
}
