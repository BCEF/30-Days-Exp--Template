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
    public enum CinemaParam
    {
        VOLUP,
        VOLDOWN,
        LIGHTUP,
        LIGHTDOWN
    }

    /// <summary>
    /// 遥控器类
    /// 逻辑相关控制器
    /// </summary>
    public class Remote
    {
        public bool isTest = true;

        //打印信息事件
        public delegate void LogHandler(string msg);
        public event LogHandler OnLogMsg;

        //硬件输入事件
        public delegate void RemoteInputHandle(DeviceInput deviceInput);
        public event RemoteInputHandle OnRemotePressed;

        //电影播放
        public delegate void moviePlayHandler(Movie movie);
        public event moviePlayHandler Playmovie;

        //调节音量
        public delegate void CinemaParaHandler(CinemaParam param);
        public event CinemaParaHandler ChangeCinema;
        
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
            if(OnRemotePressed!=null)
                OnRemotePressed(input);
        }

        public void Log(string str)
        {
            if(OnLogMsg!=null)
                OnLogMsg(str);
        }

        public void PlayNextmovie()
        {
            DataSet.Instance().CurrentmovieIndex++;
            if(Playmovie!=null)
                Playmovie(DataSet.Instance().movieList[(DataSet.Instance().CurrentmovieIndex) % DataSet.Instance().movieList.Count]);
        }
        public void PlayPreviousmovie()
        {
            DataSet.Instance().CurrentmovieIndex--;
            if (Playmovie != null)
                Playmovie(DataSet.Instance().movieList[(DataSet.Instance().CurrentmovieIndex + DataSet.Instance().movieList.Count) % DataSet.Instance().movieList.Count]);
        }
        public void VolUp()
        {
            if(ChangeCinema!=null)
                ChangeCinema(CinemaParam.VOLUP);
        }
        public void VolDown()
        {
            if(ChangeCinema != null)
                ChangeCinema(CinemaParam.VOLDOWN);
        }


    }
}

