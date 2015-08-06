using UnityEngine;
using System.Collections;


// As of this document date, Unity does not have a
// 2D factory character controller, so we create one
// from scratch
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
    private const int TotalHorizontalRays = 4;

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


    // Now our public methods

    public void awake()
    {

    }

    public void AddForce(Vector2 force)
    {

    }

    public void SetForce(Vector2 force)
    {

    }

    public void SetHorizontalForce(float x)
    {

    }

    public void SetVerticalForce(float y)
    {

    }

    public void Jump()
    {

    }

    public void LateUpdate()
    {

    }

    private void Move(Vector2 deltaMovement)
    {

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
