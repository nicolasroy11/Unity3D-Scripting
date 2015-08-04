using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPath : MonoBehaviour 
{
    // We now need to support moves towards and lerp (linear interpolate). 
    // an enum is good to codify this as it is a finite choice.
    public enum FollowType
    {
        MoveTowards,
        Lerp
    }

    // Instantiating the FollowType so that the user can set it in the Inspector
    // Defaulted to MoveTowards.
        public FollowType Type = FollowType.MoveTowards;

    // Referencing our PathDefinition script
        public PathDefinition Path;

    // Other user GUI-controllable params
        public float Speed = 1;
        public float MaxDistanceToGoal = .1f;

    // Calling our PathDefinition IEnumerator
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

    }

}
