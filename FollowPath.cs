using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour 
{
    // We now need to support moves towards and lerp (linear interpolate). 
    // an enum is good to codify this as it is a finite choice.
    // These choices will show up as dropdown menu items in the Inspector
    public enum FollowType
    {
        MoveTowards,
        Lerp
    }

    // Instantiating the FollowType so that the user can set it in the Inspector
    // Defaulted to MoveTowards.
        public FollowType Type = FollowType.MoveTowards;

    // Referencing our PathDefinition class
        public PathDefinition Path;

    // Other user GUI-controllable params
        public float Speed = 1;
        public float MaxDistanceToGoal = .1f;

        // Creating a var to instanciate getPathsEnumerator() in PathDefinition
        private IEnumerator<Transform> _currentPoint;

    public void Start()
    {
        if (Path == null)
        {
            Debug.LogError("Path cannot be null", gameObject);
            return;
        }

        // Now we call on the PathDefinition method getPathsEnumerator()
        // to tell us what the current point is according to the iterator
        // block in PathDefinitions.
        _currentPoint = Path.getPathsEnumerator();

        // _currentPoint being an IEnumerator, we can call the MoveNext()
        // method on it. This finishes up the loop and executes the
        // getPathsEnumerator() method all over.
        _currentPoint.MoveNext();

        // Invoking another property of the IEnumerator, the Current
        // which returns the object we are currently iterating through.
        // if that object returns a null object, break out of start since
        // there is nothing more to do.
        if (_currentPoint.Current == null)
        {
            return;
        }

        // This 'transform' reference refers to whichever
        // gameObject this script class will end up tied to
        transform.position = _currentPoint.Current.position;
    }

    public void Update()
    {
        // If the IEnumerator returns a null reference OR this
        // actual current point returns a null position then early exit
        if (_currentPoint == null || _currentPoint.Current == null)
        {
            return;
        }

        // If the user has set the Type to MoveTowards, then the
        // gemeObject's position will be the the MoveTowards or Lerp method
        // called on Vector with arguments current position, target position, and 
        // rate of speed to reach the target position
        if(Type == FollowType.MoveTowards)
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);
        }
        else if(Type == FollowType.Lerp)
        {
            transform.position = Vector3.Lerp(transform.position, _currentPoint.Current.position, Time.deltaTime * Speed);
        }

        // We detect how close we are to the target point. This returns x^2 + y^2 + z^2. Slightly faster since we don't have to 
        // perform the square root operation. Once we've moved close enough to the target point, we can move on.
        var distanceSquared = (transform.position - _currentPoint.Current.position).sqrMagnitude;

        // This MoveNext will invoke the iterator block until it hits a yieled return
        if (distanceSquared < (MaxDistanceToGoal * MaxDistanceToGoal))
        {
            _currentPoint.MoveNext();
        }
    }

}
