/*
 *  项目名称：30天沉浸生存实验
 *  作者：苏妺
 *  创建时间：2017-9-28 10:3:14
 *  
 */
#define TEST
#define NOTTEST
#undef NOTTEST

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//修改成你自己的命名空间
namespace ModuleRemote
{
    /// <summary>
    /// UI和按键的事件响应
    /// </summary>
    public class EventManager: MonoBehaviour
    {
        private string guiDisplayText = "";
        
        void Start()
        {
            //订阅外部设备输入
            Remote.Instance().OnRemotePressed += Remote_OnRemotePressed;
            //订阅log信息
            Remote.Instance().OnLogMsg += Remote_log;
            
        }

        private void EventManager_PlayMoive(Moive moive)
        {
            
        }

        private void Remote_OnRemotePressed(DeviceInput deviceInput)
        {
            switch (deviceInput)
            {
                case DeviceInput.UP:Remote.Instance().Log("上一个");Remote.Instance().PlayPreviousMoive(); break;
                case DeviceInput.DOWN:Remote.Instance().Log("下一个");Remote.Instance().PlayNextMoive(); break;
                case DeviceInput.LEFT:break;
                case DeviceInput.RIGHT:break;
                case DeviceInput.PREVIOUS: Remote.Instance().Log("上一个"); Remote.Instance().PlayPreviousMoive(); break;
                case DeviceInput.NEXT: Remote.Instance().Log("下一个"); Remote.Instance().PlayNextMoive(); break;
            }
        }
        private void Remote_log(string msg)
        {
            guiDisplayText += "\n"+msg;
        }
        void Update()
        {
            
        }

#if TEST
        Vector2 pos = new Vector2(0, 0);
        void OnGUI()
        {

            pos = GUILayout.BeginScrollView(pos, GUILayout.Width(Screen.width / 2), GUILayout.Height(Screen.height / 2));
            GUILayout.TextArea(guiDisplayText,GUIStyle.none);
            GUILayout.EndScrollView();

        }
#endif

    }
}

