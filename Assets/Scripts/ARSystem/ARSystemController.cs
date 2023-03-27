using UnityEngine;
using UnityEngine.Serialization;

namespace ARSystem
{
    public class ARSystemController : MonoBehaviour
    {
        /// <summary>
        /// PlaneDetection
        /// </summary>
        [SerializeField] private PlaneDetection _planeDetection;
        
        /// <summary>
        /// LightEstimation
        /// </summary>
        [SerializeField] private LightEstimation _lightEstimation;

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            _planeDetection.PlaneDetectionSetObject();
        }

        /// <summary>
        /// 初期化
        /// </summary>
        private void Initialize()
        {
            _planeDetection.Initialize();
            _lightEstimation.Initialize();
        }
    }
}