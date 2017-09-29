/*
 *  项目名称：30天沉浸生存实验
 *  作者：苏妺
 *  创建时间：2017-9-28 15:31:17
 *  
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

//修改成你自己的命名空间
namespace ModuleRemote
{
    /// <summary>
    /// 场景相关控制器
    /// </summary>
    public class RemoteUnityScene: MonoBehaviour
    {

        VarManager pool;
        void Start()
        {
            //播放电影事件
            Remote.Instance().Playmovie += Controller_Playmovie; ;
            Remote.Instance().ChangeCinema += Controller_ChangeCinemaPara;
            pool = GetComponent<VarManager>();

        }

        private void Controller_ChangeCinemaPara(CinemaParam param)
        {
            switch (param)
            {
                case CinemaParam.VOLUP: pool.Plane.GetComponent<AudioSource>().volume += 0.05f; break;
                case CinemaParam.VOLDOWN: pool.Plane.GetComponent<AudioSource>().volume -= 0.05f;break;
                case CinemaParam.LIGHTUP:break;
                case CinemaParam.LIGHTDOWN:break;
            }
        }

        //在场景中控制电影播放
        private void Controller_Playmovie(Movie movie)
        {
            var queryMovie = from item in DataSet.Instance().movieList
                                 where item.Name == movie.Name
                                 select item;
            pool.Plane.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", (Texture)Resources.Load(Path.GetFileNameWithoutExtension(queryMovie.ElementAt(0).Path)));
        }

        void Update()
        {

        }
    }
}

