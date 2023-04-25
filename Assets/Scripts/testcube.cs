using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class testcube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var luaenv = new LuaEnv();
        luaenv.DoString("print('hello world')");
        luaenv.Dispose();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
