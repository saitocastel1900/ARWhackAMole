using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.ARFoundation;

namespace Manager.ARSystemManager
{
   public class LightEstimationSystemManager : MonoBehaviour
   {
      /// <summary>
      /// ARCameraManager
      /// </summary>
      [SerializeField] private ARCameraManager _cameraManager;

      /// <summary>
      /// DirectionLight
      /// </summary>
      [SerializeField] private Light _directionLight;

      /// <summary>
      /// 現実世界の主光源の向き
      /// </summary>
      private Vector3? _mainLightDirection;

      /// <summary>
      /// 現実世界の主光源の色
      /// </summary>
      private Color? _mainLightColor;

      /// <summary>
      /// 現実世界の主光源の平均的な明るさ
      /// </summary>
      private float? _averageMainLightBrightness;

      /// <summary>
      /// 現実世界の環境光の球面調和関数
      /// </summary>
      private SphericalHarmonicsL2? _sphericalHarmonics;

      /// <summary>
      /// 初期化
      /// </summary>
      public void Initialize()
      {
         SetEventHandler();
      }

      /// <summary>
      /// イベントハンドラを設定
      /// </summary>
      private void SetEventHandler()
      {
         _cameraManager.frameReceived += SetVirtualLight;
      }

      /// <summary>
      /// 仮想カメラに光源推定で得た値を設定
      /// </summary>
      private void SetVirtualLight(ARCameraFrameEventArgs eventArgs)
      {
         //光源推定の情報
         var lightEst = eventArgs.lightEstimation;

         //仮想空間のDirectionLightの向きを、光源推定で得た主光源の向きで設定
         _mainLightDirection = lightEst.mainLightDirection;
         if (_mainLightDirection.HasValue)
         {
            _directionLight.transform.rotation = Quaternion.LookRotation(_mainLightDirection.Value);
         }

         //仮想空間のDirectionLightの色を、光源推定で得た主光源の色を設定
         _mainLightColor = lightEst.mainLightColor;
         if (_mainLightColor.HasValue)
         {
            _directionLight.color = _mainLightColor.Value;
         }

         //仮想空間のDirectionLightの明るさを、光源推定で得た主光源の明るさで設定
         _averageMainLightBrightness = lightEst.averageMainLightBrightness;
         if (_averageMainLightBrightness.HasValue)
         {
            _directionLight.intensity = _averageMainLightBrightness.Value;
         }

         //仮想空間のSkyboxAmbientLightを、現実世界の環境光の球面調和関数で設定
         _sphericalHarmonics = lightEst.ambientSphericalHarmonics;
         if (_sphericalHarmonics.HasValue)
         {
            RenderSettings.ambientMode = AmbientMode.Skybox;
            RenderSettings.ambientProbe = _sphericalHarmonics.Value;
         }
      }
   }
}