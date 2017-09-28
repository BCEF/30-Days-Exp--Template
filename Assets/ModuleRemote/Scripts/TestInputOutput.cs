/*
 *  项目名称：30天沉浸生存实验
 *  作者：苏妺
 *  创建时间：2017-9-28 9:56:49
 *  
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//修改成你自己的命名空间
namespace ModuleRemote
{
    public class TestInputOutput: MonoBehaviour
    {
        
        void Start()
        {
            Remote.Instance().Init();
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Remote.Instance().Input(DeviceInput.UP);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Remote.Instance().Input(DeviceInput.DOWN);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Remote.Instance().Input(DeviceInput.PREVIOUS);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Remote.Instance().Input(DeviceInput.NEXT);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Remote.Instance().Log("asdf");
            }

        }
        
       

        
    }
}

