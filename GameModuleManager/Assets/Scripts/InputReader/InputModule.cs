using System;
using UnityEngine;
using Zenject;

namespace InputReader
{
    public class InputModule : IInitializable, ITickable, IDisposable
    {
        private Vector3 _lastMousePosition;
        public IInputStrategy InputStrategy;

        public void Initialize()
        {
            Debug.Log("input module initalized");
            _lastMousePosition = Input.mousePosition;
        }

        public void Tick()
        {
            ProcessEvents();
            InputStrategy.ProcessEvents();
        }

        public void Dispose()
        {
            // TODO release managed resources here
        }

        private void ProcessEvents()
        {
            if (Input.GetMouseButtonDown(0))
                OnMouseDown();
            if (Input.GetMouseButtonUp(0))
                OnMouseUp();

            var currentMousePosition = Input.mousePosition;
            var delta = currentMousePosition - _lastMousePosition;
            _lastMousePosition = currentMousePosition;
            if (delta.magnitude > 0)
                OnMouseMove(delta);

            var wheelScrollDelta = Input.GetAxis("Mouse ScrollWheel");
            if (Mathf.Abs(wheelScrollDelta) > 0)
                OnMouseWheelScroll(wheelScrollDelta);
        }

        private void OnMouseDown()
        {
            InputStrategy.OnMouseDown();
            Debug.Log(InputStrategy.GetType());
        }

        private void OnMouseUp()
        {
            InputStrategy.OnMouseUp();
        }

        private void OnMouseMove(Vector3 argDelta)
        {
            InputStrategy.OnMouseMove(argDelta);
        }

        private void OnMouseWheelScroll(float argValue)
        {
        }
    }
}