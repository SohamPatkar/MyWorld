using UnityEngine;

public class Resources : MonoBehaviour
{
    public string NameOfResource;
    public int ResourceToAdd;
    public int Health = 100;

    public virtual void Die() { }
    public virtual void GiveResources() { }
}


