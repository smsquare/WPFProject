using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProject.CORE
{
    public class GameObject
    {
        public GameObject() { }
        public GameObject(string name)
        {
            this.name = name;
        }
        public string name = "untitled";
        public string contents = "empty";
        public float x = 0.0f, y = 0.0f, z = 0.0f;
        public override string ToString()
        {
            return name;
        }
    };

    public class DataCore
    {
        public static void _LoadData()
        {
            _CurrentProjectRootDirectory = ".\\Assets\\DefaultProject";
            _CurrentProjectSubDirectory = "Models";
        }

        public static string _CurrentProjectRootDirectory = ".";
        public static string _CurrentProjectSubDirectory = ".";
        public static string _CurrentProjectDirectory
        {
            get { return _CurrentProjectRootDirectory + "\\" + _CurrentProjectSubDirectory; }
        }

        public static List<GameObject> _GameObjects = new List<GameObject>();
        public static GameObject _SelectedGameObject = null;
        public static string _SelectedProjectBrowserTab = "Models";
        public static string _SelectedProjectBrowserItem = null;

        public static void SetSelectedGameObject(GameObject obj)
        {
            _SelectedGameObject = obj;
            EventCore.TriggerSelectedGameObjectChanged();
        }

        public static void ClearGameObjectsList()
        {
            _GameObjects.Clear();
        }

        public static void RegisterGameObject(GameObject obj)
        {
            if (obj == null || _GameObjects == null) return;
            if (_GameObjects.Contains(obj)) return;
            _GameObjects.Add(obj);
        }
    }
}

namespace WPFProject.CORE
{
    public class DATA
    {
        static public float GetSafeFloat(string str)
        {
            float result = 0.0f;
            float.TryParse(str, out result);
            return result;
        }

        static public string GetSafeString(float val)
        {
            return val.ToString();
        }

        static public string GetSafeFileName(string str)
        {
            try
            {
                if (str.LastIndexOf('\\') >= 0)
                {
                    str = str.Substring(str.LastIndexOf('\\') + 1);
                }
                if (str.LastIndexOf('.') >= 0)
                {
                    str = str.Substring(0, str.LastIndexOf('.'));
                }
            }
            catch (System.Exception) { }
            return str;
        }

        static public string GetSafeFileExtension(string str)
        {
            try
            {
                if (str.LastIndexOf('.') >= 0)
                {
                    str = str.Substring(str.LastIndexOf('.') + 1);
                }
            }
            catch (System.Exception) { }
            return str;
        }

        static public string GetSafeFileContents(string str)
        {
            return System.IO.File.ReadAllText(str);
        }
    }
}