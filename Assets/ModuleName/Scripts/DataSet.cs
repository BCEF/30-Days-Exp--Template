/*
 *  项目名称：30天沉浸生存实验
 *  作者：苏妺
 *  创建时间：2017-9-28 13:29:11
 *  
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//修改成你自己的命名空间
namespace ModuleRemote
{
    public class  DataSet
    {
        private DataSet()
        {
            LoadMoives();
        }
        private static DataSet inst;
        public static DataSet Instance()
        {
            if (inst == null)
            {
                inst = new DataSet();
            }
            return inst;
        }

        public int CurrentMoiveIndex = 0;
        public List<Moive> moiveList = new List<Moive>();
        public ERROR LoadMoives()
        {
            try
            {
                //test
                Moive m1 = new Moive();
                m1.Name = "m1";
                moiveList.Add(m1);
                Moive m2 = new Moive();
                m2.Name = "m2";
                moiveList.Add(m2);
                Moive m3 = new Moive();
                m3.Name = "m3";
                moiveList.Add(m3);
            }
            catch(System.Exception e)
            {
                Remote.Instance().Log(e.ToString());
                return ERROR.EXCEPTION;
            }

            return ERROR.OK;
        }

    }
}

