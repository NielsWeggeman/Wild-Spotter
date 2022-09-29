// *---- Purpose of this file: ----*
// Allow objects to be triggered by the gaze interactor ray coming from the
// camera. This file has a built in event manager to trigger specific
// actions when the user's pointer either enters the collider of the object,
// leaves it, or activates the object by looking at it for a long enough time.

// Based on the tutorial "VR Gaze Interaction in Unity" by Tomaz Saraiva
// on youtube: https://www.youtube.com/watch?v=8p4erfeWatA

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GazeInteractable : MonoBehaviour
{
    #region Variables

    private const string WAIT_TO_EXIT_COROUTINE = "WaitToExit_Coroutine";

    // Set up the event system.
    public delegate void OnEnter(GazeInteractable interactable, GazeInteractor interactor, Vector3 point);
    public event OnEnter Enter;

    public delegate void OnStay(GazeInteractable interactable, GazeInteractor interactor, Vector3 point);
    public event OnStay Stay;

    public delegate void OnExit(GazeInteractable interactable, GazeInteractor interactor);
    public event OnExit Exit;

    public delegate void OnActivated(GazeInteractable interactable);
    public event OnActivated Activated;

    // In the case of an animal, detect whether or not it was already spotted
    // by the user. This will help avoid multiple points to be given for one
    // animal.
    [Header("Configuration")]
    [SerializeField] private bool _isActivable;
    [SerializeField] private bool _wasSeen;
    [SerializeField] private float _exitDelay;

    [Header("Events")]
    public UnityEvent OnGazeEnter;
    public UnityEvent OnGazeStay;
    public UnityEvent OnGazeExit;
    public UnityEvent OnGazeActivated;
    public UnityEvent<bool> OnGazeToggle;

    public bool IsEnabled
    {
        get { return _collider.enabled; }
        set { _collider.enabled = value; }
    }
    public bool IsActivable
    {
        get { return _isActivable; }
    }
    public bool IsActivated { get; private set; }

    public bool WasSeen { get; private set; }

    private Collider _collider;

    #endregion

    private void Awake()
    {
        _collider = GetComponent<Collider>();

#if UNITY_EDITOR || DEVELOPMENT_BUILD
        if (_collider == null) { throw new System.Exception("Missing Collider"); }
#endif
    }
    private void Start()
    {
        enabled = false;
    }

    public void Enable(bool enable)
    {
        gameObject.SetActive(enable);
    }

    // If the animal is activated, WasSeen is set to true, so that in the
    // interactor file no more points can be added to the ScoreUI.
    // The animal can however still be engaged with, again.
    public void Activate()
    {
        IsActivated = true;
        WasSeen = true;

        Activated?.Invoke(this);
        OnGazeActivated?.Invoke();
    }

    public void GazeEnter(GazeInteractor interactor, Vector3 point)
    {
        StopCoroutine(WAIT_TO_EXIT_COROUTINE);

        Enter?.Invoke(this, interactor, point);

        OnGazeEnter?.Invoke();
        OnGazeToggle?.Invoke(true);
    }
    public void GazeStay(GazeInteractor interactor, Vector3 point)
    {
        Stay?.Invoke(this, interactor, point);

        OnGazeStay?.Invoke();
    }
    public void GazeExit(GazeInteractor interactor)
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WAIT_TO_EXIT_COROUTINE, interactor);
        }
        else
        {
            InvokeExit(interactor);
        }
    }

    private IEnumerator WaitToExit_Coroutine(GazeInteractor interactor)
    {
        yield return new WaitForSeconds(_exitDelay);

        InvokeExit(interactor);
    }

    private void InvokeExit(GazeInteractor interactor)
    {
        Exit?.Invoke(this, interactor);

        OnGazeExit?.Invoke();
        OnGazeToggle?.Invoke(false);

        IsActivated = false;
    }
}
