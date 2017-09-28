using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.ProjectWindowCallback;
using UnityEditor;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;
using System.Net;

public class CreateCSharpScript
{
    [MenuItem("Assets/Create/Momo CSharp Script",false,80)]
    public static void CreateNewCSharp()
    {
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
            ScriptableObject.CreateInstance<MomoCSharpScriptAsset>(),
            GetSelectedPathOrFallback() + "/NewCSharpScript.cs",
            null,
            "Assets/Editor/MomoCSharp.cs");
    }

    [MenuItem("Assets/Create/Momo Monobehavior Script", false, 80)]
    public static void CreateNewMono()
    {
        ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
            ScriptableObject.CreateInstance<MomoCSharpScriptAsset>(),
            GetSelectedPathOrFallback() + "/NewMonobehaviorScript.cs",
            null,
            "Assets/Editor/MomoMonobehavior.cs");
    }

    private static string GetSelectedPathOrFallback()
    {
        string path = "Assets";
        foreach (UnityEngine.Object obj in Selection.GetFiltered(typeof(UnityEngine.Object), SelectionMode.Assets))
        {
            path = AssetDatabase.GetAssetPath(obj);
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                path = Path.GetDirectoryName(path);
                break;
            }
        }
        return path;
    }

    class MomoCSharpScriptAsset : EndNameEditAction
    {
        public override void Action(int instanceId, string pathName, string resourceFile)
        {
            UnityEngine.Object o = CreateScriptAssetFromTemplate(pathName, resourceFile);
            ScriptTitleChange.OnWillCreateAsset(pathName);
            ProjectWindowUtil.ShowCreatedAsset(o);
        }

        internal static UnityEngine.Object CreateScriptAssetFromTemplate(string pathName, string resourceFile)
        {
            string fullPath = Path.GetFullPath(pathName);
            StreamReader streamReader = new StreamReader(resourceFile);
            string text = streamReader.ReadToEnd();
            streamReader.Close();
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pathName);
            text = Regex.Replace(text, "#NAME#", fileNameWithoutExtension);
            bool encoderShouldEmitUTF8Identifier = true;
            bool throwOnInvalidBytes = false;
            UTF8Encoding encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier, throwOnInvalidBytes);
            bool append = false;
            StreamWriter streamWriter = new StreamWriter(fullPath, append, encoding);
            streamWriter.Write(text);
            streamWriter.Close();
            AssetDatabase.ImportAsset(pathName);
            return AssetDatabase.LoadAssetAtPath(pathName, typeof(UnityEngine.Object));
        }
    }

    public class ScriptTitleChange : UnityEditor.AssetModificationProcessor
    {

        public static void OnWillCreateAsset(string path)
        {
            path = path.Replace(".meta", "");
            if (path.EndsWith(".cs"))
            {
                string allText = File.ReadAllText(path);
                allText = allText.Replace("#AuthorName#", "苏妺").Replace("#CreateTime#",
                    System.DateTime.Now.Year + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Day + " " +
                    System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second)
                    .Replace("SCRIPTNAME2",Path.GetFileNameWithoutExtension(path))
                    .Replace("SCRIPTNAME", Path.GetFileNameWithoutExtension(path));
                File.WriteAllText(path, allText);
            }

        }
    }
}

