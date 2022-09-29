// *---- Purpose of this file: ----*
// Determine how hopping animals should move along the path drawn using
// Sebastian's tool.

// Based on the tutorial "Path Creator (free unity tool)"
// by 'Sebastian Lague' on youtube:
// https://www.youtube.com/watch?v=saAQNRSYU9k

using UnityEngine;
using PathCreation;


// Moves along a path at constant speed.
// Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
public class ButterflyFollower : MonoBehaviour
{
    public PathCreator pathCreator;
    public EndOfPathInstruction endOfPathInstruction;
    public float initialSpeed = 5;
    public float distanceTravelled = 60;
    public float sittingTime = 10;
    public float restingPosition = 0;
    public float timeBeforeStart = 20;
    public bool resting = false;
    public float darting = 0.1f;
    public float dartingSpeed = 1f;

    public bool animatorFlip = false;

    public Animator animator;

    public float endLocation = 80;
    private float speed;
    private float flip = 0;

    private float enterStartTime;

    private bool start = false;

    void Start()
    {
        if (pathCreator != null)
        {
            pathCreator.pathUpdated += OnPathChanged;
            speed = 0;

            timeBeforeStart = Random.Range(0, timeBeforeStart);
}
    }

    void Update()
    {
        // A timer that randomly determinates when the hopping animal starts moving.
        if (!start)
        {
            var timeToActivate = (enterStartTime + timeBeforeStart) - Time.time;
            var progress = 1 - (timeToActivate / timeBeforeStart);
            progress = Mathf.Clamp(progress, 0, 1);

            if (progress >= 1)
            {
                start = true;
                speed = initialSpeed;
            }
        }

        // 
        if (pathCreator != null && !resting)
        {
            distanceTravelled += speed * Time.deltaTime;

            // Let's the hopping animal move up and down when it is flying or walking.
            float upMovement = (1 - Mathf.Abs(Mathf.Sin(dartingSpeed*distanceTravelled / Mathf.PI))) * darting;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction) + new Vector3 (0, upMovement, 0);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);

            // Letting the animal model turn around when it's moving back
            // along the same track.
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + flip, transform.eulerAngles.z);
            float timeVar = animatorFlip ? 0 : Time.time;

            // Resets the movement of the butterfly animation when
            animator.SetFloat("Progress", timeVar);
        }

        // Lets the animal freeze for a certain amount of time at the end of
        // it's path, so that the player can see it sit before it continues back
        // along it's path.
        if (distanceTravelled > endLocation)
        {
            distanceTravelled = endLocation-1;
            enterStartTime = Time.time;
            speed = 0;
            resting = true;
            // Sets the wings of the butterfly in an upright position at the
            // start of its animation so that it looks like its wings are
            // standing upright.
            float timeVar = !animatorFlip ? 0 : Time.time;
            animator.SetFloat("Progress", timeVar);
            transform.position = pathCreator.path.GetPointAtDistance(endLocation, endOfPathInstruction) - new Vector3(0, restingPosition, 0);
        }

        // The same happens at the start of its path. The speed is frozen for
        // a few seconds, but then gets flipped so that the movement starts again.
        if (distanceTravelled < 0)
        {
            distanceTravelled = 10;
            enterStartTime = Time.time;
            speed = 0;
            resting = true;
            // Sets the wings of the butterfly in an upright position at the
            // start of its animation so that it looks like its wings are
            // standing upright.
            float timeVar = !animatorFlip ? 0 : Time.time;
            animator.SetFloat("Progress", timeVar);
            transform.position = pathCreator.path.GetPointAtDistance(0, endOfPathInstruction) - new Vector3(0, restingPosition, 0);
        }

        // Lets the animal sit still at the end of the path for a few seconds.
        if (resting)
        {
            var timeToActivate = (enterStartTime + sittingTime) - Time.time;
            var progress = 1 - (timeToActivate / sittingTime);
            progress = Mathf.Clamp(progress, 0, 1);

            if (progress >= 1)
            {
                resting = false;
                flip += 180;
                if (distanceTravelled > endLocation - 5)
                {
                    speed = -initialSpeed;
                } else
                {
                    speed = initialSpeed;
                }
            }
        }
    }

    // If the path changes during the game, update the distance travelled so that the follower's position on the new path
    // is as close as possible to its position on the old path
    void OnPathChanged()
    {
        distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
    }
}
