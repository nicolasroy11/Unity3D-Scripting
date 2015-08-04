using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

//Path definition will show us the path of the floating platforms in the form of visual lines on the screen

public class PathDefinition : MonoBehaviour 
{
    // Defining an array for the points joining the path lines we want to draw
    // an array of Transforms (every scene object has a transform that includes xyz-pos, rot, etc)
    // In our case, an individual xyz point would be the Start, Mid or End point.
    public Transform[] Points;

    // This getPathEnumerator() method returns an IEnumerator, which is an Object that allows you 
    // to examine and index an object and move on to the next. It is invoked by a foreach loop.
    // The reason we don't simply loop through an array to get this done is that the platform will
    // not simply float from the Start point to the End point and stop. It must loop back through the
    // Mid point and loop forever along the path. The following function will return a custom enumerator
    // that will give us exactly that infinite sequence behavior. We are returning an enumerator as opposed 
    // to a collection because a collection has a finite amount of objects in it.
    public IEnumerator<Transform> getPathsEnumerator()
    {
        // The exception that is thrown when a requested method or operation is not implemented
        // throw new NotImplementedException();

        // Iterator block to give us the behavior we want
            if (Points == null || Points.Length < 1)
                {
                    // Terminate the sequence immediately
                    yield break;
                }
            var direction = 1;  // forward by default
            var index = 0;      // we start at node 0 - Start
            while(true)
                {
                    // yield execution back to whoever is invoking this enumerator to avoid locking up 
                    // the process with this infinite loop. The invoker then gets to decide if it 
                    // wants to loop again, or exit the loop, quitting the sequence.
                    // This is the same as a return statement, which means that this is the Transform object
                    // this whole function is here to return. The only difference is that it also prompts
                    // its callee for an order to press forward with this loop or to quit.
                    // For this game, it is the FollowPath.cs that calls this script, thus this method and loop
                    // Points[0] = Start; Points[1] = Mid; Points[2] = End as per the Inspector
                    yield return Points[index];
                    
                    // If your Points array only has a single point, this loop will throw an invalid reference
                    // when it hits the above command with an index = 1
                    if (Points.Length == 1)
                    {
                        continue;   // The continue statement passes control to the next iteration of the enclosing loop statement in which it appears.
                    }

                    // When the caller has control yielded back to it, it opts to 'move next'
                    // which brings it down to this next command
                    if(index <= 0)  // If we are at Start (or back to it from the previous iteration)
                    {
                        direction = 1;  // Go forward
                    }
                    else if (index >= Points.Length - 1)    // If we are at the end of the loop
                    {
                        direction = -1; // Go backwards
                    }
                    index = index + direction;
                }
            

    }

    // hooking into the Unity API that allows us to draw on the scene - a nice GUI extension of the editor
    // OnDrawGizmos is a Unity Command that draws all the visual debugging aids like box colliders, grids, etc
    // This method is polled while you edit, so you should see its effects as soon as it is saved
    public void OnDrawGizmos()
    {
        // If Points was defined but not instantiated
        // or if there aren't the requisite minimum of 2 points to make the path line, then exit
        if (Points == null || Points.Length < 2)
        {
            return;
        }

        // Cycle through the points and draw a line joining each pair
        for (var i = 1; i < Points.Length; i++)
        {
            Gizmos.DrawLine(Points[i - 1].position, Points[i].position);

        }
    }
}
