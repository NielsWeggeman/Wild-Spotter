// *---- Purpose of this file: ----*
// Determine how the fish should move along the path drawn using
// Sebastian's tool.

// Based on the tutorial "Path Creator (free unity tool)"
// by 'Sebastian Lague' on youtube:
// https://www.youtube.com/watch?v=saAQNRSYU9k

using UnityEngine;
using PathCreation;
using Unity.VisualScripting;


// Moves along a path at constant speed.
// Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
public class FishFollower : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float speed = 5;
    public float distanceTravelled = 0;
    public float darting = 1f;
    public float dartingSpeed = .3f;
    public float jumpingBias = 3f;
    public float dartingFreq = 5f;

    void Start()
    {
        if (pathCreator != null)
        {
            // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
            pathCreator.pathUpdated += OnPathChanged;
        }
    }

    void Update()
    {
        // This block of code creates a step function with an integrated sinus,
        // so that the fish jump out of the water at a predefined interval.
        if (pathCreator != null)
        {
            distanceTravelled += speed * Time.deltaTime;
            float upMovement = Mathf.Sin(Mathf.Clamp((Mathf.Sin(dartingSpeed * distanceTravelled / Mathf.PI) * dartingFreq) - jumpingBias, 0, 1))*darting;
            distanceTravelled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction) + new Vector3(0, upMovement, 0);
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
