/*
 *  项目名称：30天沉浸生存实验
 *  作者：苏妺
 *  创建时间：2017-9-29 9:17:44
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//修改成你自己的命名空间
namespace ModuleRemote
{
    public class GenerateXML: MonoBehaviour
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
                List<Movie> list = new List<Movie>();
                list.Add(new Movie
                {
                    Name = "m1",
                    Path = Application.dataPath + @"/ModuleRemote/Resources/captain.jpg"
                });
                list.Add(new Movie
                {
                    Name = "m2",
                    Path = Application.dataPath + @"/ModuleRemote/Resources/ironman.jpg"
                });
                list.Add(new Movie
                {
                    Name = "m3",
                    Path = Application.dataPath + @"/ModuleRemote/Resources/spider.jpg"
                });
                CFHelper.SaveData(Application.dataPath + @"/movieConfig.xml", list);
                Debug.Log("done");
            }
        }
    }
}

