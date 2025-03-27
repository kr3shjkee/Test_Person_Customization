using System.IO;
using UnityEditor;
using UnityEngine;

namespace CodeBase.Editor
{
    public class DeleteSaveFile
    {
        [MenuItem("Edit/Delete Save File")]
        public static void Build()
        {
            string filePath = Application.persistentDataPath + "/" + "Save.json";
            
            if(File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}