using System;
using UniRx;
using UnityEngine;

public interface IPlacedObjectManager
{
    /// <summary>
    /// 設置するオブジェクトが設置されたときに呼ばれる
    /// </summary>
    public IObservable<Unit> OnCreatedObjectCallBack { get; }
    
    /// <summary>
    /// オブジェクトを生成する
    /// </summary>
    /// <param name="position">オブジェクトの設置場所</param>
    /// <param name="rotation">オブジェクトの角度</param>
    public void PlacedObjectCreate(Vector3 position, Quaternion rotation);
    
    /// <summary>
    /// 設置したオブジェクトを破壊
    /// </summary>
    public void PlacedObjectDestroy();
    
    /// <summary>
    /// 設置したオブジェクトを破壊する
    /// </summary>
    /// <returns></returns>
    public GameObject GetPlacedObject();
}
