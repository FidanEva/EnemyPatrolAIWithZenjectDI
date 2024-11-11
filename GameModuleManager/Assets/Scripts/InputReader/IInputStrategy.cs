using EventModule;
using UnityEngine;

namespace InputReader
{
    public interface IInputStrategy
    {
        InputModule InputModule { get; set; }

        public void OnMouseDown();
        public void OnMouseUp();
        public void OnMouseMove(Vector3 argDelta);
        public void ProcessEvents();
    }
    
    public class GamePlayInputStrategy : IInputStrategy
    {
        public InputModule InputModule { get; set; }
        public void OnMouseDown()
        {
        }

        public void OnMouseUp()
        {
        }

        public void OnMouseMove(Vector3 argDelta)
        {
        }

        public void ProcessEvents()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");

            var direction = new Vector3(horizontalInput, 0, verticalInput);
            EventBus.InvokeDirectionAxisUpdated(direction);
        }
    }
    
    public class MenuInputStrategy : IInputStrategy
    {
        public InputModule InputModule { get; set; }
        public void OnMouseDown()
        {
        }

        public void OnMouseUp()
        {
        }

        public void OnMouseMove(Vector3 argDelta)
        {
        }

        public void ProcessEvents()
        {
        }
    }
}