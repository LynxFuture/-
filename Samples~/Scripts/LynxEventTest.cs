using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LynxGlobalEventTool;
using System;

public class LynxEventTest : MonoBehaviour
{
    [SerializeField]
    Text Text;
    // Start is called before the first frame update
    void Start()
    {
        //注册事件
        LynxEvents.Add<TestEventData>(ReceiveEvent);
    }

    /// <summary>
    /// 收到事件后执行的方法
    /// </summary>
    /// <param name="e">收到的事件数据</param>
    void ReceiveEvent(TestEventData e) 
    {
        Text.text = e.data;
    }
}
/// <summary>
/// 测试的事件数据
/// </summary>
public class TestEventData : EventArgs 
{
    public string data;
}
