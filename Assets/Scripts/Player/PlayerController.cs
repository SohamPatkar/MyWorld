using UnityEngine;

public enum PlayerState
{
    IDLE,
    MOVING,
    ATTACK
}

public class PlayerController
{
    private Camera playerCamera;
    private float cameraYOffset;

    private PlayerView playerView;
    private CharacterController player;
    private Transform playerTransform;
    private Vector3 playerPos;
    private Animator playerAnimator;
    private AnimatorStateInfo stateInfo;
    private PlayerState playerState;
    private PlayerScriptableObject playerSO;

    private float speed = 3.0f;
    private float rotationSpeed = 90.0f;

    public PlayerController(PlayerView playerView, PlayerScriptableObject playerSO)
    {
        this.playerView = playerView;
        this.playerSO = playerSO;

        Initialize();
    }

    private void Initialize()
    {
        player = playerView.GetPlayerCharacterController();
        playerCamera = playerView.GetPlayerCamera();
        playerAnimator = playerView.GetPlayerAnimator();

        playerSO.WoodAmount = 0;
        playerSO.StoneAmount = 0;

        EventService.Instance.WoodAmountChanged.InvokeEvent(playerSO.WoodAmount);
        EventService.Instance.StoneAmountChanged.InvokeEvent(playerSO.StoneAmount);

        SetPlayerState(PlayerState.IDLE);

        playerTransform = playerView.transform;
        cameraYOffset = 30f;
    }

    public void PlayerMovement()
    {
        Debug.Log(playerState.ToString());

        if (playerState == PlayerState.ATTACK)
        {
            return;
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        playerTransform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        Vector3 moveDirection = playerTransform.forward * verticalInput * speed;

        playerAnimator.SetFloat("Run", verticalInput);

        if (verticalInput > 0)
        {
            SetPlayerState(PlayerState.MOVING);
        }

        player.SimpleMove(moveDirection * Time.deltaTime * playerSO.MovementSpeed);
    }

    public void PlayerAttack()
    {
        if (playerState == PlayerState.ATTACK)
        {
            return;
        }

        playerAnimator.SetTrigger("Attack");
    }

    public void SetPlayerState(PlayerState playerState)
    {
        this.playerState = playerState;
    }

    public void AddWood(int amount)
    {
        playerSO.WoodAmount += amount;
        EventService.Instance.WoodAmountChanged.InvokeEvent(playerSO.WoodAmount);
    }

    public void AddStone(int amount)
    {
        playerSO.StoneAmount += amount;
        EventService.Instance.StoneAmountChanged.InvokeEvent(playerSO.StoneAmount);
    }

    public void PlayerCameraFollow()
    {
        playerPos = playerTransform.position;
        playerPos.z += -30f;
        playerPos.y = cameraYOffset;

        playerCamera.transform.position = playerPos;
    }
}
