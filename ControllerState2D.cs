using UnityEngine;
using System.Collections;


// This class keeps track of the state of the player controller, hence its name
// it will have auto-implemeted properties ({set; get:}) and state parameters
// Note that this class is also not a monoBehavior
public class ControllerState2D
{
    // The reason we are using properties for all its data members is that
    // by default, you should always use properties to expose data. Even if 
    // it is using automatic properties with a getter ans setter - good form.
    public bool IsCollidingRight { set; get; }
    public bool IsCollidingLeft { set; get; }
    public bool IsCollidingAbove { set; get; }
    public bool IsCollidingBelow { set; get; }  //Are we on the ground?
    public bool IsMovingDownSlope { set; get; }
    public bool IsMovingUpSlope { set; get; }
    public bool IsGrounded { get {return IsCollidingBelow;} }   //better terminology for being grounded
    public float SlopeAngle;

    // Are we colliding with anything
    public bool HasCollisions { get { return IsCollidingAbove || IsCollidingBelow || IsCollidingLeft || IsCollidingRight; } }

    // Total state reset
    public void reset()
    {
        IsMovingDownSlope =
        IsCollidingRight =
        IsCollidingLeft =
        IsCollidingAbove =
        IsCollidingBelow = false;
        SlopeAngle = 0;
    }

    // The override modifier is required to extend or modify the abstract or virtual implementation of an inherited method, property, indexer, or event.
    public override string ToString()
    {
        // Will return the formatted string with all the parameters plugged into the indexed fields.
        // Used for debugging - gives a readout of the current state of the player
        return string.Format("(Controller: r:{0} l:{1} a:{2} b:{3} down-slope:{4} up-slope:{5} angle:{6})",
                                IsCollidingRight,
                                IsCollidingLeft,
                                IsCollidingAbove,
                                IsCollidingBelow,
                                IsMovingDownSlope,
                                IsMovingUpSlope,
                                SlopeAngle);
    }
}
