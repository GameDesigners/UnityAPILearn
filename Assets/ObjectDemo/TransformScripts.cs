using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformScripts : MonoBehaviour
{
    ///////////PARAMS///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Transform的属性集合

    /// <summary>
    /// 返回或设置一个游戏对象的欧拉角 
    /// 注意：
    ///     1.只能对其整体赋值，不能对单独的.x;.y;.z赋值
    ///     2.eulerAngles.x∈[0,90]∪[270,360]  ;  eulerAngles.y∈[0,360]  ;  eulerAngles.z∈[0,360]
    ///     3.此属性是相对坐标系的，相对父物体的则用localEulerAngle
    ///     4.根据欧拉角旋转，Unity会先沿z轴旋转，然后是x轴，最后是y轴
    /// </summary>
    /// <returns></returns>
    public Vector3 EulerAngles_Params()
    {
        return gameObject.transform.eulerAngles;
    }

    /// <summary>
    /// transform自身坐标轴方向向量对应世界坐标系的单位向量
    /// </summary>
    public void Direction_Params()
    {
        Vector3 forward= gameObject.transform.forward;    //Z轴,此语句是transform.TransformDirection(new Vector3(0f,0f,1f))的简写
        Vector3 up = gameObject.transform.up;             //Y轴
        Vector3 right = gameObject.transform.right;       //X轴
    }

    /// <summary>
    /// 此属性用于判断GameObject对象从上次将此属性设为false以来，其transform组件的属性是否被修改过。
    /// 注意：修改后与原来的值相同，hasChanged值仍然为true
    /// </summary>
    /// <returns></returns>
    public bool HasChanged_Params()
    {
        return transform.hasChanged;
    }

    /// <summary>
    /// 此属性用于设置或返回GameObject对象在局部坐标系的位置，若无父物体则与transform.position返回的值相同
    /// </summary>
    /// <returns></returns>
    public Vector3 LocalPosition_Params()
    {
        return transform.localPosition;
    }

    /// <summary>
    /// 坐标转换矩阵
    /// </summary>
    public void Matrix_Params()
    {
        Matrix4x4 local_to_world_matrix = transform.localToWorldMatrix;   //局部坐标系转向世界坐标系转换的矩阵
        Matrix4x4 world_to_local_matrix = transform.worldToLocalMatrix;   //世界坐标系转向局部坐标系转换的矩阵
    }

    /// <summary>
    /// 返回transform的父物体
    /// </summary>
    /// <returns></returns>
    public Transform Parent_Params()
    {
        return transform.parent;
    }
    #endregion
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    ///////////类实例方法////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    /// <summary>
    /// 分离物体层级(只分离上层，会保留本层级以及子层级的信息)
    /// </summary>
    public void DetachChildren_API()
    {
        transform.DetachChildren();
    }

    /// <summary>
    /// 根据索引获取子对象
    /// </summary>
    /// <param name="_index">物体的索引（从0开始）</param>
    /// <returns></returns>
    public Transform GetChild_API(int _index)
    {
        return transform.GetChild(_index);
    }

    /// <summary>
    /// 将参数_direction从世界坐标系转化为GameObject对象的局部坐标系
    /// </summary>
    /// <param name="_direction"></param>
    /// <returns></returns>
    public Vector3 InverseTransformDirection_API(Vector3 _direction)
    {
        float x = _direction.x;
        float y = _direction.y;
        float z = _direction.z;

        Vector3 result;

        //@override
        result = transform.InverseTransformDirection(_direction);
        result = transform.InverseTransformDirection(x, y, z);

        return result;
    }

    /// <summary>
    /// 将参数_direction与transform.position的差值（差向量）
    /// </summary>
    /// <param name="_direction"></param>
    /// <returns></returns>
    public Vector3 InverseTransformPoint_API(Vector3 _direction)
    {
        float x = _direction.x;
        float y = _direction.y;
        float z = _direction.z;

        Vector3 result;

        //@override
        result = transform.InverseTransformPoint(_direction);
        result = transform.InverseTransformPoint(x, y, z);

        return result;
    }

    /// <summary>
    /// 判断transform是否为_parent的子物体
    /// </summary>
    /// <param name="_parent"></param>
    /// <returns></returns>
    public bool IsChildOf_API(Transform _parent)
    {
        return transform.IsChildOf(_parent);
    }

    /// <summary>
    /// 使GameObject对象自身坐标系中的Z轴指向target,y轴最大限度的指向worldUp方向
    /// </summary>
    /// <param name="_target">transform自身坐标系中Z指向的目标</param>
    /// <param name="_worldUp">transform自身坐标系中y轴最大限度指向的方向，默认为vector.Up</param>
    /// <param name="_worldPosition"></param>
    public void LookAt_API(Transform _target,Vector3 _worldUp,Vector3 _worldPosition)
    {
        transform.LookAt(_target);
        transform.LookAt(_worldPosition);
        transform.LookAt(_target, _worldUp);
        transform.LookAt(_worldPosition, _worldUp);
    }

    /// <summary>
    /// 绕坐标轴旋转
    /// </summary>
    /// <param name="_eulerAngles">旋转的欧拉角</param>
    /// <param name="_relativeTo">参考的坐标系，Space的枚举值</param>
    public void Rotate_API(Vector3 _eulerAngles,Space _relativeTo=Space.Self)
    {
        float xAngle = _eulerAngles.x;
        float yAngle = _eulerAngles.y;
        float zAngle = _eulerAngles.z;

        transform.Rotate(_eulerAngles);
        transform.Rotate(_eulerAngles, _relativeTo);
        transform.Rotate(xAngle, yAngle, zAngle, _relativeTo);
    }

    /// <summary>
    /// 绕某个向量旋转
    /// </summary>
    /// <param name="_axis">参照向量</param>
    /// <param name="_angle">旋转角度</param>
    /// <param name="_space">参考的坐标系，Space的枚举值</param>
    public void Rotate_API(Vector3 _axis,float _angle,Space _space)
    {
        transform.Rotate(_axis, _angle);
        transform.Rotate(_axis, _angle, _space);
    }

    /// <summary>
    /// 绕轴_point的_axis旋转旋转
    /// </summary>
    /// <param name="_point">参考点坐标</param>
    /// <param name="_axis">旋转轴方向</param>
    /// <param name="_angle">旋转角度</param>
    public void RotateAround_API(Vector3 _point, Vector3 _axis, float _angle)
    {
        transform.RotateAround(_point,_axis, _angle);
    }

    /// <summary>
    /// 坐标系的转化和点的位置转换
    /// </summary>
    /// <param name="_direction"></param>
    /// <param name="_position"></param>
    /// <returns></returns>
    public Vector3 Tranform_API(Vector3 _direction,Vector3 _position)
    {
        Vector3 result;
        float x = _direction.x;
        float y = _direction.y;
        float z = _direction.z;

        //@override : 将局部坐标_direction转化为世界坐标
        result = transform.TransformDirection(_direction);
        result = transform.TransformDirection(x, y, z);

        //@override : 返回GameObject对象局部坐标系中点_position在世界坐标系中的位置
        result = transform.TransformPoint(_position);
        result = transform.TransformPoint(x, y, z);
        return result;
    }

    /// <summary>
    /// 相对坐标系移动
    /// </summary>
    /// <param name="_translation">移动向量，包括方向和大小</param>
    /// <param name="_relativeTo"></param>
    public void Translate_API(Vector3 _translation,Space _relativeTo=Space.Self)
    {
        transform.Translate(_translation);
        transform.Translate(_translation, _relativeTo);

        float x = _translation.x;
        float y = _translation.y;
        float z = _translation.z;

        transform.Translate(x, y, z);
        transform.Translate(x, y, z, _relativeTo);
    }

    /// <summary>
    /// 相对其他物体移动。默认为Space.World
    /// </summary>
    /// <param name="_translation">移动向量，包括方向和大小</param>
    /// <param name="_relativeTo">移动参考物体</param>
    public void Translate_API(Vector3 _translation,Transform _relativeTo)
    {
        transform.Translate(_translation, _relativeTo);

        float x = _translation.x;
        float y = _translation.y;
        float z = _translation.z;

        transform.Translate(x, y, z);
        transform.Translate(x, y, z, _relativeTo);
    }
}
