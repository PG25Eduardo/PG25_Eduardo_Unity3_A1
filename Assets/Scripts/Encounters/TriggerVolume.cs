using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerVolume : MonoBehaviour
{
    [SerializeField] private string _tagFilter = "Player";
    [SerializeField] private bool _doOnce = true;
    [SerializeField] private bool _isDone = false;

    public UnityEvent<GameObject> OnEnter;
    public UnityEvent<GameObject> OnExit;

    private void OnTriggerEnter(Collider other)
    {
        // stop if already activated
        if (_doOnce && _isDone) return;
        // stop if tag match fail
        if (!CheckForTagMatch(other.gameObject)) return;

        _isDone = true;
        OnEnter.Invoke(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        // stop if already activated
        if (_doOnce && _isDone) return;
        // stop if tag match fail
        if (!CheckForTagMatch(other.gameObject)) return;

        _isDone = true;
        OnExit.Invoke(other.gameObject);
    }

    private bool CheckForTagMatch(GameObject other)
    {
        // ignore match if tag filter is empty
        if (string.IsNullOrEmpty(_tagFilter)) return true;
        // otherwise compare tags
        return other.CompareTag(_tagFilter);
    }
}