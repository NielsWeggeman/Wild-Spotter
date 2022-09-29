// *---- Purpose of this file: ----*
// Determine how the bird should move along the path drawn using
// Sebastian's tool.

// Based on the tutorial "Path Creator (free unity tool)"
// by 'Sebastian Lague' on youtube:
// https://www.youtube.com/watch?v=saAQNRSYU9k

using UnityEngine;
using PathCreation;


// Moves along a path at constant speed.
// Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
public class Follower : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 5;
    public float distanceTravelled = 0;

    void Start()
    {
        if (pathCreator != null)
        {
            // Sets location of bird along its path at a random value, so that
            // it is not too predictable when the bird will fly by.
            pathCreator.pathUpdated += OnPathChanged;
            distanceTravelled = Random.Range(0, 700);
        }
    }

    void Update()
    {
        if (pathCreator != null)
        {
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);
        }
    }

    // If the path changes during the game, update the distance travelled so that the follower's position on the new path
    // is as close as possible to its position on the old path
    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
}
