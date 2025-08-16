using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerView playerView;
    private static GameManager instance;

    public static GameManager Instance { get { return instance; } }
    public PlayerView PlayerView { get { return playerView; } }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }




}
