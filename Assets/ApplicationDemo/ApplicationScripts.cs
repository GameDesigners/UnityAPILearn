using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    编写时间：2020.10.14
    编写人员：ZhuSenlin
    内容：Unity关于Application一些常用的类
 */
public class ApplicationScripts : MonoBehaviour
{
    //属性
    #region _PATH_
    private string dataPath;
    private string persistentDataPath;
    private string streamingAssetPath;
    private string temporaryCachePath;
    #endregion

    #region _LEVEL_
    /*
     *    private int loadedLevel = Application.loadedLevel;
     *    已过时
     */
    private int loadedLevel;
    #endregion



    /// <summary>
    /// 截图方法，此方法用于截取当前游戏画面，并将截取的画面保存为png格式。截图会
    /// Application.CaptureScreenshot(_filename);已过时
    /// </summary>
    /// <param name="_filename">文件名称</param>
    /// <param name="_superSize">放大系数，默认为0.例如：1920*1080的屏幕分辨率，放大两倍即为3840*2160</param>
    public void CaptureScreenShot(string _filename,int _superSize=0)
    {
        if (_superSize == 0)
            ScreenCapture.CaptureScreenshot(_filename);
        ScreenCapture.CaptureScreenshot(_filename, _superSize);
    }
    void Start()
    {
        dataPath = Application.dataPath;
        persistentDataPath = Application.persistentDataPath;
        streamingAssetPath = Application.streamingAssetsPath;
        temporaryCachePath = Application.temporaryCachePath;

        loadedLevel = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;

        Debug.Log("dataPath:" + dataPath);
        Debug.Log("persistentDataPath:" + persistentDataPath);
        Debug.Log("streamingAssetPath:" + streamingAssetPath);
        Debug.Log("temporaryCachePath:" + temporaryCachePath);

        Debug.Log("CurrentSceneIndex:" + loadedLevel);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            CaptureScreenShot("01.png", 2);
    }
}
