/*
 *  项目名称：30天沉浸生存实验
 *  作者：苏妺
 *  创建时间：2017-9-29 15:31:43
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//修改成你自己的命名空间
namespace Root
{
    /// <summary>
    /// 测试
    /// </summary>
    public class Test: MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                MMEvent m1 = new MMEvent();
                m1.Name = "test";
                DataSetRoot.Instance().eventList.Add(m1);
                EventManager.Instance().RegisterEvent("test",new EventManager.Response(fun));
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                ArrayList array = new ArrayList();
                array.Add(1);
                array.Add(2);
                EventManager.Instance().Trigger("test", array);
            }
        }
       void fun(ArrayList array) {
            Debug.Log(array[1]);
        }
    }
}

