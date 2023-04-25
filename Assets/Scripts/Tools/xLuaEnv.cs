using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class XLuaEnv
{
    #region singleton

    private static XLuaEnv _Instance = null;

    public static XLuaEnv Instance
    {
        get
        {
            if (!_Instance)
            {
                _Instance = new XLuaEnv();
            }

            return _Instance;
        }

        set
        {
            _Instance = value;
        }
    }

    #endregion

    #region lua environment
    private LuaEnv _Env;
    private XLuaEnv()
    {
        _Env = new LuaEnv();
    }

    // 自定义加载器
    // 参数： 被加载的lua文件的路径
    private byte[] ProjectLoader(ref string filepath)
    {
        var path = Application.dataPath;
        path = path.Substring(0, path.Length - "Assets".Length - 1) + "/DataPath/Lua" + filepath + ".lua";

        // Debug.Log(path);
        // 将lua文件读取为字节数组
        return File.Exists(path) ? File.ReadAllBytes(path) : null;
    }

    // 释放lua环境
    public void Free()
    {
        if (_Env)
        {
            _Env.Dispose();
        }

        _Instance = null;
    }

    #endregion
}