using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraScript : MonoBehaviour
{
    ///////////PARAMS///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    /// <summary>
    ///  设置相机视口的宽高比
    /// </summary>
    /// <returns></returns>
    public float Aspect_Params()
    {
        return GetComponent<Camera>().aspect;
    }

    /// <summary>
    /// 返回从摄像机的局部坐标系到世界坐标系的变换矩阵（只读）
    /// </summary>
    /// <returns></returns>
    public Matrix4x4 CameraToWorldMatrix_Params()
    {
        return GetComponent<Camera>().cameraToWorldMatrix;
    }

    /// <summary>
    /// 摄像机按层渲染
    /// 显示第二、三层可以用 （1<<2）+(1<<3)  来表示
    /// </summary>
    /// <param name="_cullingMasks">显示的层级索引数组</param>
    public void CullingMask_Params(List<int> _cullingMasks)
    {
        GetComponent<Camera>().cullingMask = -1;    //渲染场景中的任何层物体
        GetComponent<Camera>().cullingMask = 0;     //不渲染场景中任何层物体

        int cullingMask=0;
        if (_cullingMasks.Count>0)
        {
            cullingMask = 1<<_cullingMasks[0];
            for (int index = 0; index < _cullingMasks.Count; index++)
                cullingMask += 1 << _cullingMasks[index];
        }

        GetComponent<Camera>().cullingMask = cullingMask;
    }

    /// <summary>
    /// 选择哪一层（layer）的物体可以响应鼠标事件，说明如下：
    ///     1.物体在摄像机的视野范围内
    ///     2.在2的layer次方的值与eventMask进行与运算（&）后结果为认为2的layer次方的值。例如，当前物体的层为default，即layer=0时，则2的0次方为1.如果1与eventMask进行与运算仍为1，则此物体便会响应事件
    /// </summary>
    public int EventMask_Params()
    {
        return GetComponent<Camera>().eventMask;
    }

    /// <summary>
    /// 设置摄像机基于层的消隐距离
    /// </summary>
    /// <returns></returns>
    public float[] LayerCullDistances_Params()
    {
        return GetComponent<Camera>().layerCullDistances;
    }

    /// <summary>
    /// 是否采用基于球面距离的剔除方式
    /// </summary>
    /// <returns></returns>
    public bool LayerCullSpherical_Params(bool _on)
    {
        GetComponent<Camera>().layerCullSpherical = _on;
        return GetComponent<Camera>().layerCullSpherical;
    }

    /// <summary>
    /// 用于获取和设置当前摄像机的投影模式，投影模式包括正交投影模式和透视投影模式。若值为true则为正交投影，否则为透视模式
    /// </summary>
    /// <param name="_isOrthographic"></param>
    /// <returns></returns>
    public bool Orthographic_Params(bool _isOrthographic)
    {
        GetComponent<Camera>().orthographic = _isOrthographic;
        return GetComponent<Camera>().orthographic;
    }

    /// <summary>
    /// 摄像机渲染区间(区别于rect属性，rect是单位化的比例，pixelRect是像素的比例)
    /// </summary>
    /// <param name="_rect"></param>
    /// <returns></returns>
    public Rect PixelRect_Params(Rect _rect)
    {
        GetComponent<Camera>().pixelRect = _rect;
        return GetComponent<Camera>().pixelRect;
    }

    /// <summary>
    /// 设置摄像机的自定义投影矩阵
    /// </summary>
    /// <param name="_projectionMatrix"></param>
    /// <returns></returns>
    public Matrix4x4 ProjectionMatrix(Matrix4x4 _projectionMatrix)
    {
        GetComponent<Camera>().projectionMatrix = _projectionMatrix;
        return GetComponent<Camera>().projectionMatrix;
    }

    /// <summary>
    /// 使用单位化的坐标系的方式来设置当前摄像机的视图位置和大小                                                                                                                                                                                                                                                     
    /// </summary>
    /// <param name="_rect"></param>
    /// <returns></returns>
    public Rect Rect_Params(Rect _rect)
    {
        GetComponent<Camera>().rect = _rect;
        return GetComponent<Camera>().rect;
    }

    /// <summary>
    /// 设置相机的渲染路径
    /// </summary>
    /// <param name="_renderingPath"></param>
    /// <returns></returns>
    public RenderingPath RenderingPath_Params(RenderingPath _renderingPath)
    {
        GetComponent<Camera>().renderingPath = _renderingPath;
        return GetComponent<Camera>().renderingPath;
    }

    /// <summary>
    /// 获取或设置目标渲染纹理
    /// </summary>
    /// <returns></returns>
    public RenderTexture TargetTexture_Params()
    {
        return GetComponent<Camera>().targetTexture;
    }

    public Matrix4x4 WorldToCameraMatrix()
    {
        return GetComponent<Camera>().worldToCameraMatrix;
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
