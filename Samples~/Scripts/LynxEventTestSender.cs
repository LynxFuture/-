using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LynxGlobalEventTool;
public class LynxEventTestSender : MonoBehaviour
{
    /// <summary>
    /// �Զ���ķ����¼������ѹ�Button�ĵ���¼�����
    /// </summary>
    /// <param name="a"></param>
    public void Send(string a) 
    {
        //����һ���¼����ݲ���ֵ
        TestEventData testData = new TestEventData { data = a };
        //�����¼�
        LynxEvents.Send(testData);
    }
}
