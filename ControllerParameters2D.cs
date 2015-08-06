using System;
using UnityEngine;
using System.Collections;

// Note that this class does not inherit from MonoBehavior.
// It is also Serializable, which it gets from the System namespace
// This makes it so that we can modify it inside of our inspector
// if it is used by a MonoBehavior script somewhere (this one will
// be used by our CharacterController2D script. Serializable makes it so
// even though it does not inherit from MonoBehavior, we can still edit
// its public members in the GUI Inspector.
// Unlike ControllerState2D, we are using regular fields as opposed to properties
// because we intend to manipulate in the Unity inspector window, which has a 
// constraint that it can only manipulate fields. Not so with ControllerState2D
// because none of its fields are expected to be manipulated within the Inspector.
[Serializable]
public class ControllerParameters2D
{
    public enum JumpBehavior
    {
        CanJumpOnGround,
        CanJumpAnywhere,
        CantJump
    }

    // float.MaxValue represents the maximal value of System.single
    public Vector2 MaxVelocity = new Vector2(float.MaxValue, float.MaxValue);

    // the slope limit is the angles we can climb. the limit is set at 30 degrees
    // even if the range stretches from 0 to 90 degrees.
    // The range attribute translates in the Inspector as a slider.
    [Range(0,90)]
    public float SlopeLimit = 30;
    public float Gravity = -25f;    //every second, an additional -25 units will be added to our downward velocity
    // instanciating our JumpBehavior - can't name the instance the same name as its parent class.
    public JumpBehavior JumpRestrictions;
    public float JumpFrequency = 0.25f; //Gotta limit the number of jumps in a time frame - what if they hold the space bar indefifnitely?

}
