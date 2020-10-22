using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyScript : MonoBehaviour
{
    #region 刚体属性 | Rigidbody 刚体
    ///////////PARAMS///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// 碰撞模式的设置
    /// </summary>
    /// <returns></returns>
    public CollisionDetectionMode CollisionDetectionMode_Params()
    {
        CollisionDetectionMode CollisionDetectionMode_Params;
        CollisionDetectionMode_Params = CollisionDetectionMode.Discrete;            //静态离散检测模式，为系统的默认设置。在此模式下，只有某一帧中两个物体的碰撞器发生重叠时才能被检测，而下一帧移动到另一个刚体的下方，会发生穿越现象
        CollisionDetectionMode_Params = CollisionDetectionMode.Continuous;          //静态连续检测模式，一般用在高速运动刚体防止穿越碰撞体
        CollisionDetectionMode_Params = CollisionDetectionMode.ContinuousDynamic;   //最强的连续动态检测模式，计算量最大

        return CollisionDetectionMode_Params;
    }
    
    /// <summary>
    /// 给刚体添加一个阻力
    /// </summary>
    /// <param name="_drag"></param>
    /// <returns></returns>
    public float Drag_Params(float _drag)
    {
        GetComponent<Rigidbody>().drag = _drag;
        return GetComponent<Rigidbody>().drag;
    }

    /// <summary>
    /// 惯性张量，在距离重心同等的条件下，刚体会向张量值大的一边倾斜
    /// </summary>
    /// <param name="_inertiaTensor"></param>
    /// <returns></returns>
    public Vector3 InertialTensor_Params(Vector3 _inertiaTensor)
    {
        GetComponent<Rigidbody>().inertiaTensor = _inertiaTensor;
        return _inertiaTensor;
    }

    /// <summary>
    /// 刚体质量
    /// </summary>
    /// <param name="_mass"></param>
    /// <returns></returns>
    public float Mass_Params(float _mass)
    {
        GetComponent<Rigidbody>().mass = _mass;
        return GetComponent<Rigidbody>().mass;
    }

    /// <summary>
    /// 刚体速度，坐标系为世界坐标系，单位为米
    /// </summary>
    /// <param name="_velocity"></param>
    /// <returns></returns>
    public Vector3 Velocity_Params(Vector3 _velocity)
    {
        return GetComponent<Rigidbody>().velocity = _velocity;
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #endregion

    ///////////实例方法///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// 对刚体添加一个模拟爆炸效果的作用力
    /// </summary>
    /// <param name="_explosionForce">爆炸点施加的力的大小</param>
    /// <param name="_explosionPosition">爆炸点的坐标</param>
    /// <param name="explosionRadius">爆炸作用力有效半径</param>
    /// <param name="_upwardsModifiter">爆炸力作用点在y轴方向的偏移</param>
    /// <param name="_forceMode">爆炸作用力的作用模式,默认为ForceMode.Force</param>
    public void AddExplosionForce_API(float _explosionForce,Vector3 _explosionPosition,float explosionRadius,float _upwardsModifiter,ForceMode _forceMode=ForceMode.Force)
    {
        GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, _explosionPosition, explosionRadius);
        GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, _explosionPosition, explosionRadius,_upwardsModifiter);
        GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, _explosionPosition, explosionRadius, _upwardsModifiter,_forceMode);
    }

    /// <summary>
    /// 增加刚体点作用力
    ///     当力的作用点在刚体重心时，刚体不发生旋转
    ///     当力的作用点不在重心上，由于作用点的扭矩会使刚体发生旋转，但是，当作用力的方向经过刚体的重心时不发生旋转
    /// </summary>
    /// <param name="_forece">扭矩向量</param>
    /// <param name="_position">作用点坐标</param>
    /// <param name="_forceMode">力的作用方式，默认为ForceMode.Force</param>
    public void AddForceAtPosition_API(Vector3 _forece,Vector3 _position,ForceMode _forceMode)
    {
        GetComponent<Rigidbody>().AddForceAtPosition(_forece, _position);
        GetComponent<Rigidbody>().AddForceAtPosition(_forece, _position, _forceMode);
    }

    /// <summary>
    /// 刚体添加扭矩
    /// </summary>
    /// <param name="_torque">扭矩向量</param>
    /// <param name="_forceMode">力的作用方式</param>
    public void AddTorque_API(Vector3 _torque,ForceMode _forceMode)
    {
        GetComponent<Rigidbody>().AddTorque(_torque);
        GetComponent<Rigidbody>().AddTorque(_torque, _forceMode);

        float x = _torque.x;
        float y = _torque.y;
        float z = _torque.z;

        GetComponent<Rigidbody>().AddTorque(x, y, z);
        GetComponent<Rigidbody>().AddTorque(x, y, z, _forceMode);
    }

    /// <summary>
    /// 爆炸点到刚体最短距离
    /// </summary>
    /// <param name="_position">爆炸点坐标</param>
    public void ClosestPointOnBounds_API(Vector3 _position)
    {
        GetComponent<Rigidbody>().ClosestPointOnBounds(_position);
    }

    /// <summary>
    /// 获取世界坐标系中_worldPosition点在刚体局部坐标中的速度。
    /// </summary>
    /// <param name="_worldPosition">世界坐标系中的点坐标</param>
    public void GetPointVelocity_API(Vector3 _worldPosition)
    {
        GetComponent<Rigidbody>().GetPointVelocity(_worldPosition);
    }

    /// <summary>
    /// 获取刚体自身坐标系中_relativePoint点的速度，速度的计算会受刚体角速度的影响
    /// </summary>
    /// <param name="_relativePoint"></param>
    public void GetRelativePointVelocity_API(Vector3 _relativePoint)
    {
        GetComponent<Rigidbody>().GetRelativePointVelocity(_relativePoint);
    }

    /// <summary>
    /// 此方法用于对刚体的位置进行移动，通常用在刚体失去动力学模拟的情况，即isKinematic为true时
    /// </summary>
    /// <param name="_position"></param>
    public void MovePosition_API(Vector3 _position)
    {
        GetComponent<Rigidbody>().MovePosition(_position);
    }

    /// <summary>
    /// 可以使刚体进入休眠状态，且至少休眠一帧
    /// </summary>
    public void Sleep_API()
    {
        GetComponent<Rigidbody>().Sleep();
    }

    /// <summary>
    /// 检测在刚体的direction方向是否有碰撞器对象，且对象的有效探测距离不大于distance
    /// </summary>
    /// <param name="_direction">探测方向</param>
    /// <param name="_hitInfo"></param>
    /// <param name="_distance">有效探测距离</param>
    public void API(Vector3 _direction,out RaycastHit _hitInfo,float _distance)
    {
        GetComponent<Rigidbody>().SweepTest(_direction,out _hitInfo);
        GetComponent<Rigidbody>().SweepTest(_direction, out _hitInfo,_distance);
    }    

    /// <summary>
    /// 探测碰撞器
    /// </summary>
    /// <param name="_direction">探测方向</param>
    /// <param name="_distance">有效探测距离</param>
    public void SweepTestAll_API(Vector3 _direction,float _distance)
    {
        GetComponent<Rigidbody>().SweepTestAll(_direction);
        GetComponent<Rigidbody>().SweepTestAll(_direction,_distance);
    }

    /// <summary>
    /// 唤醒刚体
    /// </summary>
    public void WakeUp_API()
    {
        GetComponent<Rigidbody>().WakeUp();
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
