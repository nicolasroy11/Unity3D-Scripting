using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private bool _isFacingRight;

    // Will keep track of our CharacterController2D as this player
    // instance moves through the world.
    private CharacterController2D _controller;

    // Will either be 1 or -1 (hence normalized)
    // depending on whether the player is moving right or left.
    private float _normalizedHorizontalSpeed;

    // The following 3 values 
    public float MaxSpeed = 8;  //maximum units per second that the player can move

    // These two determine how quickly a player can go from 
    // not moving at all to moving (or from moving left to moving right)
    // in other words, how much inertia the player experiences 
    // depending on the medium it finds itself in.
    public float SpeedAccelerationOnGround = 10f;
    public float SpeedAccelerationInAir = 5f;

    public void Start()
    {
        // instantiate our CharacterCOntroller2D components
        _controller = GetComponent<CharacterController2D>();

        // We are facing right if our character is flipped
        // So this initializes our _isFacingRight var.
        _isFacingRight = transform.localScale.x > 0;
    }

    public void Update()
    {
        // This will change our normalized Horizontal Speed
        // to 1, -1 or 0 depending on whether the player is holding down
        // A or D.
        HandleInput();

        // Will return the correct acceleration factor depending on whether th eplayer is on the ground or in the air.
        // State is instanciated in the CharacterCOntroller2D.
        var movementFactor = _controller.State.IsGrounded ? SpeedAccelerationOnGround : SpeedAccelerationInAir;

        // Again, the arguments for Mathf.lerp are current-velocity, maximal possible speed * instantaneous direction of movememnt, and time
        _controller.SetHorizontalForce(Mathf.Lerp(_controller.Velocity.x, _normalizedHorizontalSpeed * MaxSpeed, Time.deltaTime*movementFactor));
    }

    private void HandleInput()
    {
        //User is pressing D - which is the 'go right' command
        if (Input.GetKey(KeyCode.D))
        {
            // We go right
            _normalizedHorizontalSpeed = 1;

            // If the player is not facing right, do a flip
            if(!_isFacingRight)
            {
                Flip();
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _normalizedHorizontalSpeed = -1;
            if(_isFacingRight)
            {
                Flip();
            }
        }
        else
        {
            _normalizedHorizontalSpeed = 0;
        }

        // If the player can jump, then the space bar will make it happen.
        if (_controller.CanJump && Input.GetKeyDown(KeyCode.Space))
        {
            _controller.Jump();
        }
    }

    private void Flip()
    {
        // Negate the x-component of the player's localscale, flipping the character around.
        // Remember that the localScale is the 3rd parameter down in the transform pane
        // in the Inspector. Flipping the PLayer backwards makes the x-coordinate go
        // negative in live mode.
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

        // Will set or reset _isFacingRight by testing localscale.x against 0 as a boolean.
        _isFacingRight = transform.localScale.x > 0;
    }
}
