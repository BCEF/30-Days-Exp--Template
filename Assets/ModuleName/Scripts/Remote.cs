using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ModuleRemote
{
    

    /// <summary>
    /// 错误代码
    /// </summary>
    public enum ERROR
    {
        //错误们，自行定义
        NOHARDWARE,
        NETWORKFAIL,
        EXCEPTION,
        OK
    }
    /// <summary>
    /// 自定义的硬件设备输入
    /// </summary>
    public enum DeviceInput
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        NEXT,
        PREVIOUS
    }

    /// <summary>
    /// 遥控器类
    /// </summary>
    public class Remote
    {
        public bool isTest = true;

        //打印信息事件
        public delegate void LogHandler(string msg);
        public static event LogHandler OnLogMsg;
        
        //硬件输入事件
        public delegate void RemoteInputHandle(DeviceInput deviceInput);
        public static event RemoteInputHandle OnRemotePressed;
        
        //构造函数
        private Remote()
        {
        
        }
        private static Remote inst;
        public static Remote Instance()
        {
            if (inst == null)
            {
                inst = new Remote();
            }
            return inst;   
        }

        public ERROR Init()
        {
            //初始化
            Remote.Instance().Log("初始化成功！");
            //初始化成功，返回OK
            return ERROR.OK;
        }

        public ERROR Close()
        {
            //结束运行
            Remote.Instance().Log("结束运行");
            //成功结束，返回OK
            return ERROR.OK;
        }

        public void Input(DeviceInput input)
        {
            OnRemotePressed(input);
        }
        

        public void Log(string str)
        {
            OnLogMsg(str);
        }

        public ERROR PlayNextMoive()
        {
            DataSet.Instance().CurrentMoiveIndex++;
            return DataSet.Instance().moiveList[(DataSet.Instance().CurrentMoiveIndex) % DataSet.Instance().moiveList.Count].Play();
        }
        public ERROR PlayPreviousMoive()
        {
            DataSet.Instance().CurrentMoiveIndex--;
            return DataSet.Instance().moiveList[(DataSet.Instance().CurrentMoiveIndex + DataSet.Instance().moiveList.Count) % DataSet.Instance().moiveList.Count].Play();
        }


    }
}

