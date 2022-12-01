using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LynxGlobalEventTool;
public class LynxEventTestSender : MonoBehaviour
{
    /// <summary>
    /// 自定义的发送事件的类已供Button的点击事件调用
    /// </summary>
    /// <param name="a"></param>
    public void Send(string a) 
    {
        //创建一个事件数据并赋值
        TestEventData testData = new TestEventData { data = a };
        //发送事件
        LynxEvents.Send(testData);
    }
}
