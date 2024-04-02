using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MyGameEvents
{
    public abstract class GameEventListener<T> : MonoBehaviour
    {
        [SerializeField] private GameEventAsset<T> _gameEventAsset;

        public UnityEvent<T> OnGameEventInvoked;

        // subscribe to and unsubscribe from GameEvent when this component is enabled and disabled
        private void OnEnable()
        {
            _gameEventAsset.OnInvoked.AddListener(GameEventInvoked);
        }

        private void OnDisable()
        {
            _gameEventAsset.OnInvoked.RemoveListener(GameEventInvoked);
        }

        private void GameEventInvoked(T param)
        {
            OnGameEventInvoked.Invoke(param);
        }
    }
}