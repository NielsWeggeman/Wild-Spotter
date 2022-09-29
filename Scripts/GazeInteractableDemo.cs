// *---- Purpose of this file: ----*
// Trigger a random movement in the 'Gaze Interactable' object, once it is
// activated by the 'Gaze Interactor'.

// Based on a combination of the tutorial "VR Gaze Interaction in Unity"
// by Tomaz Saraiva on youtube:
// https://www.youtube.com/watch?v=8p4erfeWatA

#region Includes
using UnityEngine;
#endregion


public class GazeInteractableDemo : MonoBehaviour
{
    #region Variables

    [Header("Configuration")]
    [SerializeField] private float _speed;
    [SerializeField] private float _radius;

    private Vector3 _initialPosition;
    private Vector3 _targetPosition;

    #endregion

    private void Start()
    {
        _initialPosition = transform.position;

        Reset();
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Time.deltaTime * _speed);
        if (transform.position == _targetPosition)
        {
            _targetPosition = _initialPosition + Random.insideUnitSphere * _radius;
        }
    }

    public void Enable()
    {
        enabled = true;
    }
    public void Reset()
    {
        transform.position = _initialPosition;
        _targetPosition = _initialPosition;

        enabled = false;
    }
}
