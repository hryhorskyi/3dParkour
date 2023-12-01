using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _speed = 6.0f;
    [SerializeField]
    private float _jumpSpeed = 8.0f;
    [SerializeField]
    private float _gravity = 20.0f;
    [SerializeField]
    private float _airControl = 0.5f;
    [SerializeField]
    private Camera _camera;

    private Vector3 _moveDirection = Vector3.zero;
    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 horizontalMovement;
        
        if (_characterController.isGrounded)
        {
            horizontalMovement = new Vector3(-Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal")) * _speed;
            
            if (Input.GetButton("Jump"))
            {
                _moveDirection.y = _jumpSpeed;
            }
        }
        else
        {
            horizontalMovement = new Vector3(-Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal")) * (_speed * _airControl);
        }

        _moveDirection.x = horizontalMovement.x;
        _moveDirection.z = horizontalMovement.z;

        if (horizontalMovement != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(horizontalMovement, Vector3.up);
        }

        _moveDirection.y -= _gravity * Time.deltaTime;
        _characterController.Move(_moveDirection * Time.deltaTime);
    }
}