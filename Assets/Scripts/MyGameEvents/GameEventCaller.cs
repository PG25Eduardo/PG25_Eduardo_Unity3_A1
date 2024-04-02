using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MyGameEvents
{
    public abstract class GameEventCaller<T> : MonoBehaviour
    {
        private enum GameEventCallerTiming
        {
            Awake,
            Start,
            Update,
            FixedUpdate
        }

        [SerializeField] private GameEventAsset<T> _gameEventAsset;
        [SerializeField] private T _value;
        [SerializeField] private GameEventCallerTiming _timing = GameEventCallerTiming.Start;

        private void Awake()
        {
            if (_timing == GameEventCallerTiming.Awake) _gameEventAsset.Invoke(_value);
        }

        private void Start()
        {
            if (_timing == GameEventCallerTiming.Start) _gameEventAsset.Invoke(_value);
        }

        private void Update()
        {
            if (_timing == GameEventCallerTiming.Update) _gameEventAsset.Invoke(_value);
        }

        private void FixedUpdate()
        {
            if (_timing == GameEventCallerTiming.FixedUpdate) _gameEventAsset.Invoke(_value);
        }
    }
}