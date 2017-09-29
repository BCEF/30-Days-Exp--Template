/*
 *  项目名称：30天沉浸生存实验
 *  作者：苏妺
 *  创建时间：2017-9-29 14:0:1
 *  
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//修改成你自己的命名空间
namespace Root
{
    /// <summary>
    /// 事件类
    /// </summary>
    public class  MMEvent
    {
        private static int N = 0;
        private int ID;
        /// <summary>
        /// 事件名称
        /// </summary>
        public string Name
        {
            get;set;
        }

        /// <summary>
        /// 事件描述
        /// </summary>
        public string Description
        {
            get;set;
        }
       

        /// <summary>
        /// 事件
        /// </summary>
        /// <param name="param"></param>
        public delegate void MMEventHandler(ArrayList param);
        public event MMEventHandler OnMMEvent;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name"></param>
        /// <param name="desc"></param>
        public MMEvent(string name="event",string desc="no description")
        {
            ID = N++;
            this.Name = name;
            if (name.Equals("event"))
            {
                Name += ID;
            }
            Description = desc;
        }
        /// <summary>
        /// 触发事件
        /// </summary>
        /// <param name="param"></param>
        public void OnTrigger(ArrayList param)
        {
            if(OnMMEvent!=null)
                OnMMEvent(param);
        }
    }
}

