/*
 *  项目名称：30天沉浸生存实验
 *  作者：苏妺
 *  创建时间：2017-9-29 17:4:42
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Root;
//修改成你自己的命名空间
namespace Handler
{
    /// <summary>
    /// 手柄类
    /// </summary>
    public class VirtualHandler
    {
        enum Button
        {
            LEFT,
            RIGHT,
            UP,
            DOWN
        }
        /// <summary>
        /// 手柄单例
        /// </summary>
        private VirtualHandler() { }
        private static VirtualHandler virtualHandler;
        public static VirtualHandler Instance()
        {
            if (virtualHandler == null)
            {
                virtualHandler = new VirtualHandler();
            }
            return virtualHandler;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            EventManager.Instance().CreateEvent("HandleInput");
            EventManager.Instance().CreateEvent("Trigger");
        }
        /// <summary>
        /// 手柄输入
        /// 当手柄有按键输入时，调用此函数
        /// </summary>
        public void Input(string s)
        {
            //s是手柄的输入
            switch (s)
            {
                case "up":EventManager.Instance().Trigger("HandleInput", new ArrayList { Button.UP });break;
                case "down":EventManager.Instance().Trigger("HandleInput", new ArrayList { Button.DOWN });break;
            }
        }
    }
}

