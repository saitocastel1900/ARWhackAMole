using UnityEngine;

namespace ARSystemManager
{
    public class ARSystemManager : MonoBehaviour
    {
        [SerializeField] private PlaneDetectionSystemManager _planeDetectionSystemManager;
        [SerializeField] private LightEstimationSystemManager _lightEstimationSystemManager;

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            _planeDetectionSystemManager.PlaneDetectionSetObject();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialize()
        {
            _planeDetectionSystemManager.Initialize();
            _lightEstimationSystemManager.Initialize();
        }
    }
}