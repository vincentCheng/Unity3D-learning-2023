using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

// 加载器
public class Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // var env = new LuaEnv();
        // lua调用C#代码(CS.命名空间.类名.方法名（参数）)
        // 在 StreamingAssets目录下能够自动加载lua文件。
        // env.DoString("require('test')");
        // env.Dispose();
        MyLoader();
    }

    // 自定义loader
    public void MyLoader()
    {
        var env = new LuaEnv();
        env.AddLoader(ProjectLoader);
        env.Dispose();
    }

    // 自定义加载器
    // 参数： 被加载的lua文件的路径
    public byte[] ProjectLoader(ref string filepath)
    {
        var path = Application.dataPath;
        path = path.Substring(0, path.Length - "Assets".Length - 1) + "/DataPath/Lua" + filepath + ".lua";

        // Debug.Log(path);
        // 将lua文件读取为字节数组
        return File.Exists(path) ? File.ReadAllBytes(path) : null;
    }
}
