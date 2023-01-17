using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 playerVelocity;
    public bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private float gravityMultiplier = 20f;
    private Joystick _joystick;
    private float _elapsedTime;
    public float _touchSensivity = 0.5f;
    private float moving;
    Animator _animator;
   
    
    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        _joystick = Joystick.Instance;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        moving = _joystick.Direction.magnitude;
        _animator.SetFloat("moving",moving);
        
        
        if (Input.GetMouseButton(0))
        {
            // Start chronometer for reach touch sensivity
            // Understand is player wants to move or jump
            _elapsedTime += Time.deltaTime;
        } else if (Input.GetMouseButtonUp(0))
        {
            if (_elapsedTime < _touchSensivity && groundedPlayer && Time.timeScale !=0)
            {
                //Jump
                playerVelocity.y += Mathf.Sqrt(jumpHeight  * -3 * gravityValue);
                _animator.SetTrigger("Jump");
                
            }

            _elapsedTime = 0;
        }
        if (playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        // Move
        Vector3 move = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        // Call gravity to party!
        playerVelocity.y += gravityValue *gravityMultiplier* Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
