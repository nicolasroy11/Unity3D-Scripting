using UnityEngine;
using System.Collections;


// As of this document date, Unity does not have a
// 2D factory character controller, so we create one
// from scratch. The RigidBody2D characteristic
// is set to Is Kinematic, so we have a rigid body
// and Unity will handle collision detection, but
// we will handle the movement of the object. We
// are effectively disallowing Unity to add gravity
// or use physics material, or handle bounce 
// characteristics. Unity's physics engine is
// rendered inactive. The Collider2D is how we tell
// Unity what geometry to follow when the RigidBody 
// comes in collision with something. Note that RigidBody
// are only added to elements that are expected to move.
public class CharacterController2D : MonoBehaviour
{
    // the skin of the character is linked to the idea that we will be casting rays
    // from inside the character so that when we hit a corner perfectly, we will still
    // hit one of the edges, and our character will not fall through the corner of an object
    // it should normally have collided with instead of going through. .02f is the amount
    // of inner offset the rays will originate from.
    private const float SkinWidth = .02f;

    // The number of rays shooting from the character horizontally and vertically, being that
    // our character is modeled as a box.
    private const int TotalHorizontalRays = 8;
    private const int TotalVerticalRays = 4;

    // This property will be used when we implement our moving up/down slopes
    // all the properties are in radians as that is what Unity expects.
    private static readonly float SlopeLimitTangent = Mathf.Tan(75f * Mathf.Deg2Rad);

    // PlatfromMask will be a layer mask used for collsion detection.
    // The only things we will collide with are things that match this
    // platform mask - unlike healthpacks or stars which we just walk right through.
    // Unity's LayerMask allow you to display the LayerMask popup menu in the inspector.
    public LayerMask PlatformMask;

    // will allow us to edit the default parameters within the Inspector - remember,
    // the ControllerParameters2D class is serializable.
    public ControllerParameters2D DefaultParameters;

    public ControllerState2D State { get; private set; }

    public bool CanJump { get { return false; } }

    // Velocity is a normal property that only has a getter
    // as opposed to an automatic property which has both a setter and a getter.
    // Velocity is a property that is publically accessible
    // but we want to lock down access to _velocity to
    // only methods that will use it which are all in this class.
    // So logically, we will make _velocity aprivate method.
    // Velocity's getter gets us a COPY of Velocity,
    // but _velocity is the field to use for actual setting
    // of Player velocity. Velocity does not have
    // a setter, so it cannot be used to set anything.
    public Vector2 Velocity { get { return _velocity; } }
    private Vector2 _velocity;

    // We alias out some of our commonly used components into private fields.
    // Makes things marginally faster for situations where things will be
    // transform heavy instead of calling the Transform or Localscale
    // everytime it is needed, we keep a reference on hand.
    private Transform _transform;
    private Vector3 _localScale;
    private BoxCollider2D _boxCollider;

    private float 
        _verticalDistanceBetweenRays,
        _horizontalDistanceBetweenRays;

    

    // Now our public methods - public APIs for manipulating how we want our player to move

    // The difference between Awake and Start is that Start is only called if the script instance is enabled. 
    // This allows you to delay any initialization code, until it is really needed. 
    // Awake is always called before any Start functions. This allows you to order initialization of scripts.
    // Think of Awake() as the script that does the heavy lifting so that Start() can hit the ground running.
    public void Awake()
    {
        State = new ControllerState2D();
        _transform = transform;
        _localScale = _transform.localScale;
        _boxCollider = GetComponent<BoxCollider2D>();   //GetComponent allows us to use a type as a variable.

        // The width of the collider is the actual size of the box collider * the scaling of the 
        // player which we may change minus (the skinwidth offset from the left side + the skinwidth offset from the right side)
        // We need to take the absolute value of the scale since flipping the player negates it.
        var colliderWidth = _boxCollider.size.x * Mathf.Abs(_transform.localScale.x) - (2 * SkinWidth);
        _horizontalDistanceBetweenRays = colliderWidth / (TotalVerticalRays - 1);

        var colliderHeight = _boxCollider.size.y * Mathf.Abs(_transform.localScale.y) - (2 * SkinWidth);
        _verticalDistanceBetweenRays = colliderHeight/ (TotalHorizontalRays - 1);
    }

    public void AddForce(Vector2 force)
    {
        _velocity = force;
    }

    public void SetForce(Vector2 force)
    {
        _velocity += force;
    }

    public void SetHorizontalForce(float x)
    {
        _velocity.x = x;
    }

    public void SetVerticalForce(float y)
    {
        _velocity.y = y;
    }

    public void Jump()
    {

    }

    public void LateUpdate()
    {
        Move(Velocity * Time.deltaTime);
    }

    private void Move(Vector2 deltaMovement)
    {
        // First, we check whether we were grounded
        // then we reset the state, which simply 
        // resets all the collidingLeft, right, above etc to 0.
        // It also resets our slope to 0.
        var wasgrounded = State.IsCollidingBelow;
        State.Reset();

    }

    private void HandlePlatforms()
    {

    }

    private void CalculateRayOrigins()
    {

    }

    // Takes in the parameter by reference, so any change to the parameter in the called
    // method is reflected in the calling method
    private void MoveHorizontally(ref Vector2 deltaMovement)
    {

    }

    private void MoveVertically(ref Vector2 deltaMovement)
    {

    }

    private void HandleVerticalSlope(Vector2 deltaMovement)
    {

    }

    private void HandleHorizontalSlope(Vector2 deltaMovement, float angle, bool isGoingRight)
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {

    }

    public void OnTriggerExit2D(Collider2D other)
    {

    }

}