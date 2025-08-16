using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [Header("PlayerSO")]
    [SerializeField] private PlayerScriptableObject playerSO;

    [Header("PlayerCamera")]
    [SerializeField] private Camera playerCamera;

    [Header("PlayerAnimator")]
    [SerializeField] private Animator playerAnimator;

    private CharacterController playerCharacterController;
    private PlayerController playerController;


    void Start()
    {
        playerCharacterController = GetComponent<CharacterController>();

        SetController();
    }

    // Update is called once per frame
    void Update()
    {
        playerController.PlayerMovement();

        if (Input.GetMouseButtonDown(0))
        {
            playerController.PlayerAttack();
        }
    }

    void LateUpdate()
    {
        playerController.PlayerCameraFollow();
    }

    public void OnAttackStart()
    {
        playerController.SetPlayerState(PlayerState.ATTACK);
    }

    public void OnAttackEnd()
    {
        playerController.SetPlayerState(PlayerState.IDLE);
    }

    public void SetController()
    {
        playerController = new PlayerController(this, playerSO);
    }

    public PlayerController GetPlayerController()
    {
        return playerController;
    }

    public Camera GetPlayerCamera()
    {
        return playerCamera;
    }

    public Animator GetPlayerAnimator()
    {
        return playerAnimator;
    }

    public CharacterController GetPlayerCharacterController()
    {
        return playerCharacterController;
    }
}
