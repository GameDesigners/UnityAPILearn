using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    #region 关于Object的API


    /// <summary>
    /// 返回Object对象的实例化ID
    /// </summary>
    /// <param name="_obj">想要查看ID的Object</param>
    /// <returns>实例化ID【int】</returns>
    public int GetObjectID_API(Object _obj)
    {
        return _obj.GetInstanceID();
    }

    /// <summary>
    /// 静态方法：Destroy
    /// 销毁的可以是GameObject、组件等
    /// </summary>
    /// <param name="_obj">游戏对象【Object】</param>
    /// <param name="_delay">延迟时间【float】</param>
    public static void Destroy_API(Object _obj,int _delay=-1)
    {
        if(_obj!=null&&_delay==-1)
            Destroy(_obj);

        if (_obj != null && _delay >= 0)
            Destroy(_obj, _delay);
    }

    /// <summary>
    /// 静态方法：DontDestroyOnLoad
    /// 新场景中保留对象
    /// 保留对象必须是根物体或根物体上的组件（效果是一样的，都是保留根物体）
    /// 想保留不是根物体的对象，可以先用Transform.DetachChildren将其从父物体上分离出来，再调用DontDestroyOnLoad
    /// </summary>
    /// <param name="_obj">保留的对象</param>
    public static void DontDestroyOnLoad_API(Object _obj)
    {
        GameObject obj = _obj as GameObject;
        if (obj.transform.parent != null)
            obj.transform.parent.transform.DetachChildren();  //父子层级分离

        DontDestroyOnLoad(obj);
    }

    /// <summary>
    /// 泛型静态方法：FindObjectOfType
    /// 返回工程中符合泛型参数的对象类型
    /// 因为需要遍历整个工程，因此不适宜在每帧调用
    /// 返回的是泛型的数组
    /// </summary>
    public static void FindObjectOfType_API()
    {
        FindObjectOfType<ObjectScript>();
    }

    /// <summary>
    /// 实例化一个对象
    /// </summary>
    /// <param name="_model">实例化对象的类型（作为模板）</param>
    /// <param name="_position">实例化物体的位置</param>
    /// <param name="_rotation">实例化物体的旋转角度</param>
    public static void Instantiate_API(Object _model,Vector3 _position,Quaternion _rotation)
    {
        GameObject newOne =Instantiate(_model) as GameObject;
        GameObject newTwo = Instantiate(_model, _position, _rotation) as GameObject;
    }

    #endregion



    #region 关于GameObject的API
///////////PARAMS///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /// <summary>
    /// 属性:GameObject对象的Active标识状态，不受父对象的影响
    /// </summary>
    /// <param name="_go">游戏对象</param>
    /// <returns>bool</returns>
    public bool activeSelf_Params(GameObject _go)
    {
        return _go.activeSelf;
    }
    /// <summary>
    /// 属性:GameObject对象在运行时的激活状态（区别于activeSelf），受父对象的影响
    /// </summary>
    /// <param name="_go"></param>
    /// <returns></returns>
    public bool Params(GameObject _go)
    {
        return _go.activeInHierarchy;
    }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    /// <summary>
    /// GameObject的构造函数
    /// </summary>
    /// <param name="_goName"></param>
    /// <param name="_transform"></param>
    public void GameObject_API(string _goName,Transform _transform)
    {
        GameObject go = new GameObject(_goName);
        //后面的不定长参数是添加组件
        GameObject go_with_component = new GameObject(_goName, typeof(Transform), typeof(ObjectScript));
    }

    /// <summary>
    /// 创建一个系统自带的GameObject对象
    /// </summary>
    /// <param name="_primitiveType"></param>
    public void CreatePrimitive_API(PrimitiveType _primitiveType)
    {
        GameObject go = GameObject.CreatePrimitive(_primitiveType);
    }




    #endregion
}
