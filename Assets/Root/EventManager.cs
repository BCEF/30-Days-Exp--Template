/*
 *  项目名称：30天沉浸生存实验
 *  作者：苏妺
 *  创建时间：2017-9-29 15:58:7
 *  
 */
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//修改成你自己的命名空间
namespace Root
{
    /// <summary>
    /// 事件相关错误代码
    /// </summary>
    public enum EventError
    {
        NOEVENT,
        ERRORPARAM,
        OK
        
    }

    /// <summary>
    /// 事件管理类
    /// </summary>
    public class  EventManager
    {
        /// <summary>
        /// EventManager的单例
        /// </summary>
        private EventManager() { }
        private static EventManager instance;
        public static EventManager Instance()
        {
            if (instance == null)
            {
                instance = new EventManager();
            }
            return instance;
        }

        /// <summary>
        /// 事件访问器形式
        /// </summary>
        /// <param name="arrayList"></param>
        public delegate void Response(ArrayList arrayList);
        
        /// <summary>
        /// 注册一个事件访问器
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="responseFunc"></param>
        public EventError RegisterEvent(string eventName, Response responseFunc)
        {
            var query = from item in DataSetRoot.Instance().eventList
                        where item.Name == eventName
                        select item;
            if (query.Count<MMEvent>() == 0)
                return EventError.NOEVENT;
            foreach (MMEvent mevent in query)
            {
                mevent.OnMMEvent += new MMEvent.MMEventHandler(responseFunc);
            }
            return EventError.OK;
        }
        /// <summary>
        /// 解除注册
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="responseFunc"></param>
        public EventError Unregister(string eventName,Response responseFunc)
        {
            var query = from item in DataSetRoot.Instance().eventList
                        where item.Name == eventName
                        select item;
            if (query.Count<MMEvent>() == 0)
                return EventError.NOEVENT;
            foreach (MMEvent mevent in query)
            {
                mevent.OnMMEvent -= new MMEvent.MMEventHandler(responseFunc);
            }
            return EventError.OK;
        }
        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public EventError Trigger(string eventName,ArrayList param)
        {
            var query = from item in DataSetRoot.Instance().eventList
                        where item.Name == eventName
                        select item;
            if (query.Count<MMEvent>() == 0)
                return EventError.NOEVENT;
            foreach (MMEvent mevent in query)
            {
                mevent.OnTrigger(param);
            }

            return EventError.OK;
        }
    }
}

