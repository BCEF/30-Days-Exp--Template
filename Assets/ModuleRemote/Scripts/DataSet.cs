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
            Loadmovies();
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

        public int CurrentmovieIndex = 0;
        public List<Movie> movieList = new List<Movie>();
        public ERROR Loadmovies()
        {
            try
            {
                movieList = (List<Movie>)CFHelper.LoadData(Application.dataPath + "/ModuleRemote/movieConfig.xml",typeof(List<Movie>));
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

