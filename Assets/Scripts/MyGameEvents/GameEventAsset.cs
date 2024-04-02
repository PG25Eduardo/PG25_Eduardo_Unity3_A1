using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MyGameEvents
{
    // <T> adds a 'generic' type to our class that must be defined when an instance is created
    public abstract class GameEventAsset<T> : ScriptableObject
    {
        [SerializeField] private bool _log = true;
        [SerializeField] private T _currentValue;   // T references the generic type given up above, right now we don't know what it is
        public T CurrentValue => _currentValue;

        public UnityEvent<T> OnInvoked;

        public void Invoke(T param)
        {
            // logs event name, parameter value, and pings event asset in project folder when clicked
            if (_log) Debug.Log($"{name} event invoked: {param}", this);
            _currentValue = param;
            // ?. checks if OnInvoked is null, before calling Invoke method
            // not necessary for UnityEvents, they check for null internally
            OnInvoked?.Invoke(param);
        }
    }
}