/*
 *  项目名称：30天沉浸生存实验
 *  作者：苏妺
 *  创建时间：2017-9-28 15:31:17
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//修改成你自己的命名空间
namespace ModuleRemote
{
    public class Controller: MonoBehaviour
    {

        VarManager pool;
        void Start()
        {
            //播放电影事件
            Remote.Instance().PlayMoive += Controller_PlayMoive; ;
            pool = GetComponent<VarManager>();
        }

        private void Controller_PlayMoive(Moive moive)
        {
            switch (moive.Name)
            {
                case "m1":pool.Plane.GetComponent<MeshRenderer>().material = pool.matList[0];break;
                case "m2": pool.Plane.GetComponent<MeshRenderer>().material = pool.matList[1]; break;
            }
        }

        void Update()
        {

        }
    }
}

