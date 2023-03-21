using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.ARFoundation;

public class LightEstimationController : MonoBehaviour
{
   [SerializeField] private ARCameraManager _cameraManager;
   [SerializeField] private Light _directionLight;

   private Vector3? _mainLightDirection;
   private Color? _mainLightColor;
   private float? _averageMainLightBrightness;
   private SphericalHarmonicsL2? _sphericalHarmonics;

   /// <summary>
   /// 
   /// </summary>
   public void Initialize()
   {
      SetEventHandler();
   }
   
   /// <summary>
   /// 
   /// </summary>
   private void SetEventHandler()
   {
      _cameraManager.frameReceived += SetVirtualLight;
   }

   /// <summary>
   /// 
   /// </summary>
   /// <param name="eventArgs"></param>
   private void SetVirtualLight(ARCameraFrameEventArgs eventArgs)
   {
      //光源推定の情報
      var lightEst = eventArgs.lightEstimation;

      _mainLightDirection = lightEst.mainLightDirection;
      if (_mainLightDirection.HasValue)
      {
         _directionLight.transform.rotation = Quaternion.LookRotation(_mainLightDirection.Value);
      }

      _mainLightColor = lightEst.mainLightColor;
      if (_mainLightColor.HasValue)
      {
         _directionLight.color = _mainLightColor.Value;
      }

      _averageMainLightBrightness = lightEst.averageMainLightBrightness;
      if (_averageMainLightBrightness.HasValue)
      {
         _directionLight.intensity = _averageMainLightBrightness.Value;
      }

      _sphericalHarmonics = lightEst.ambientSphericalHarmonics;
      if (_sphericalHarmonics.HasValue)
      {
         RenderSettings.ambientMode = AmbientMode.Skybox;
         RenderSettings.ambientProbe = _sphericalHarmonics.Value;
      }
   }
}
