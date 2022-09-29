// *---- Purpose of this file: ----*
// Set up the ray-detection in the camera object, so that we can distill in
// what direction the user is looking and whether they are looking at a
// collidable object. In this case, these collidable objects are either
// animals or UI menus.

// Based on a combination of the tutorial "VR Gaze Interaction in Unity"
// by Tomaz Saraiva on youtube:
// https://www.youtube.com/watch?v=8p4erfeWatA

// and the "Simple Gaze Cursor in Unity" tutorial by Adam Kelly
// on his website 'Immersive Limit':
// https://www.immersivelimit.com/tutorials/simple-gaze-cursor-in-unity

#region Includes
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UIElements;
#endregion

public class GazeInteractor : MonoBehaviour
{
    #region Variables

    [Header("Configuration")]
    [SerializeField] private float _maxDetectionDistance;
    [SerializeField] private float _minDetectionDistance;
    [SerializeField] private float _timeToActivate = 1.0f;
    [SerializeField] private LayerMask _layerMask;

    private Ray _ray;
    private RaycastHit _hit;

    // Link to the interactable object that is established once a collision
    // gets detected.
    private GazeInteractable _interactable;

    public Camera viewCamera;

    // Cursor object to place at the point where the ray collides
    // with the interactable object.
    public GameObject cursorInstance;
    [SerializeField] private float _scale = 0.02f;
    public Color inactive = new Color(5f, 5f, 5f, 5f);
    public Color active = new Color(5f, 3f, 0f, 5f);

    private Material emittor;

    // Link to the canvas text that updates once an animal has been spotted.
    public UpdateScoreUI ScoreUI;

    // Timer for waiting before activation once an object is 'looked at'.
    private float _enterStartTime;

    #endregion

    private void Update()
    {
        cursorInstance.GetComponent<Renderer>().material.color = inactive;

        _ray = new Ray(transform.position, transform.forward);

        // Detects whether the ray hits a collider
        if (Physics.Raycast(_ray, out _hit, Mathf.Infinity, _layerMask))
        {
            var distance = Vector3.Distance(transform.position, _hit.transform.position);

            cursorInstance.transform.position = _hit.point;

            // scales pointer when it is further away, so that it always remains visible.
            var scale = distance * _scale;
            scale = Mathf.Clamp(scale, _scale, scale);
            cursorInstance.transform.localScale = Vector3.one * scale;

            // Collects information on what kind of object the ray collided with.
            var interactable = _hit.collider.transform.GetComponent<GazeInteractable>();

            if (interactable == null)
            {
                // if the object collided with is not interactable, the pointer
                // gets hauled forward so that it does not visually overlap
                // with the terrain. I tried to get the cursors' material
                // set up so that it would always render in front, but I could
                // not get that to work.
                cursorInstance.transform.position = transform.position + transform.forward * 5;
                cursorInstance.transform.localScale = Vector3.one * _scale * 5;

                // The cursor's color gets set back to the inactive cursor
                // color.
                cursorInstance.GetComponent<Renderer>().material.color = inactive;
                Reset();
                return;
            }


            // If the object collided with is not the last recorded interactable,
            // the timer gets reset and the object currently looked at is
            // stored as the current interactable.
            if (interactable != _interactable)
            {
                Reset();

                _enterStartTime = Time.time;

                _interactable = interactable;
                _interactable.GazeEnter(this, _hit.point);
            }

            _interactable.GazeStay(this, _hit.point);

            // Change the color of the cursor to active to let the user know
            // that this object can be interacted with.
            if (_interactable.IsActivable)
            {
                cursorInstance.GetComponent<Renderer>().material.color = active;

                cursorInstance.transform.position = _hit.point - transform.forward;
            }

            // If the object looked at is an animal, and it has not yet been
            // recorded as a 'seen species', this if-clausule records the
            // given animal as 'was seen', so that is not accidentally counted
            // twice. Also the ScoreUI is now updated.
            if (_interactable.IsActivable && !_interactable.IsActivated)
            {
                var timeToActivate = (_enterStartTime + _timeToActivate) - Time.time;
                var progress = 1 - (timeToActivate / _timeToActivate);
                progress = Mathf.Clamp(progress, 0, 1);

                if (progress == 1)
                {
                    if (_interactable.WasSeen == false)
                    {
                        ScoreUI.score += 1;
                    }
                    _interactable.Activate();
                }

                return;
            }

            return;
        }

        // Set cursor distance within range of view if the ray does not
        // collide with any object. E.g., when the player looks into the sky.
        cursorInstance.transform.position = transform.forward * 999; 
        cursorInstance.transform.localScale = Vector3.one * 999 * _scale;
        Reset();

    }

    private void Reset()
    {
        // Trigger 'exit' if the player does no longer look at the object.
        if (_interactable == null) { return; }
        _interactable.GazeExit(this);
        _interactable = null;
    }
}
