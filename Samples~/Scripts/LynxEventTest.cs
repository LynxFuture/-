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
        //ע���¼�
        LynxEvents.Add<TestEventData>(ReceiveEvent);
    }

    /// <summary>
    /// �յ��¼���ִ�еķ���
    /// </summary>
    /// <param name="e">�յ����¼�����</param>
    void ReceiveEvent(TestEventData e) 
    {
        Text.text = e.data;
    }
}
/// <summary>
/// ���Ե��¼�����
/// </summary>
public class TestEventData : EventArgs 
{
    public string data;
}
