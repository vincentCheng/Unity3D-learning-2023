using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class DoString : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaCallCSharpCode();
        LuaReturnData();
    }

    public void LuaCallCSharpCode()
    {
        var env = new LuaEnv();
        // lua调用C#代码(CS.命名空间.类名.方法名（参数）)
        env.DoString("CS.UnityEngine.Debug.Log('from lua')");
        env.Dispose();
    }

    // lua的值返回给c#
    public void LuaReturnData()
    {
        var env = new LuaEnv();
        var data = env.DoString("return 100, true");
        Debug.Log("lua的第一个返回值：" + data[0].ToString());
        Debug.Log("lua的第2个返回值：" + data[1].ToString());
        env.Dispose();
    }
}
