using UnityEngine;

namespace Garage.Cameras
{
    public class CameraScaler : MonoBehaviour
    {
        public Vector2 TargetResolution
        {
            get => _targetResolution;
            set => _targetResolution = value;
        }

        [SerializeField]
        private Vector2 _targetResolution = new Vector2(1920.0f, 1080f);

        private float pixelsPerUnit = 100f;
        private Camera _camera;
        private int _currentScreenWidth = 0;
        private int _currentScreenHeight = 0;
        private Vector2 _winSize;

        private void Start()
        {
            _camera = GetComponent<Camera>();
            if (!_camera)
            {
                Debug.LogWarning("No camera for pixel perfect cam to use");
            }
            else
            {
                _camera.orthographic = true;
                ResizeCamToTargetSize();
            }
        }

        private void Update()
        {
            if (Mathf.Abs(_winSize.x - Screen.width) > 0.00001f ||
                Mathf.Abs(_winSize.y - Screen.height) > 0.00001f)
            {
                ResizeCamToTargetSize();
            }
        }

        private void ResizeCamToTargetSize()
        {
            if (_currentScreenWidth != Screen.width || _currentScreenHeight != Screen.height)
            {
                float percentageX = Screen.width / _targetResolution.x;
                float percentageY = Screen.height / _targetResolution.y;
                float targetSize = percentageX > percentageY ? percentageY : percentageX;
                _camera.orthographicSize = ((Screen.height / 2f) / targetSize) / pixelsPerUnit;
            }
            _winSize = new Vector2(Screen.width, Screen.height);
        }
    }
}