/*
 *  项目名称：30天沉浸生存实验
 *  作者：苏妺
 *  创建时间：2017-9-29 14:18:8
 *  
 */

using System.Collections.Generic;

//修改成你自己的命名空间
namespace Root
{
    
    /// <summary>
    /// 数据类
    /// </summary>
    public class DataSetRoot
    {
        /// <summary>
        /// 数据类的单例
        /// </summary>
        private DataSetRoot(){}
        private static DataSetRoot instance;
        public static DataSetRoot Instance()
        {
            if (instance == null)
            {
                instance = new DataSetRoot();
            }
            return instance;
        }
        /// <summary>
        /// 事件列表
        /// </summary>
        public List<MMEvent> eventList = new List<MMEvent>();
        

        
    }
}

