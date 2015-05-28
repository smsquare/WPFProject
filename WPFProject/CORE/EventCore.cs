using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFProject.CORE
{
    class EventCore
    {
        public delegate void EventDelegate(string parameter);

        public static event EventDelegate _OnSelectedGameObjectChanged = null;
        public static void TriggerSelectedGameObjectChanged()
        {
            if (_OnSelectedGameObjectChanged != null) 
            {
                _OnSelectedGameObjectChanged(null);
            }
        }

        public static event EventDelegate _OnProjectSubDirectoryChanged = null;
        public static void TriggerProjectSubDirectoryChanged()
        {
            if (_OnProjectSubDirectoryChanged != null)
            {
                _OnProjectSubDirectoryChanged(null);
            }
        }

        public static event EventDelegate _OnSelectedProjectBrowserTabChanged = null;
        public static void TriggerSelectedProjectBrowserTabChanged()
        {
            if (_OnSelectedProjectBrowserTabChanged != null)
            {
                _OnSelectedProjectBrowserTabChanged(null);
            }
        }

        public static event EventDelegate _OnSelectedProjectBrowserItemChanged = null;
        public static void TriggerSelectedProjectBrowserItemChanged()
        {
            if (_OnSelectedProjectBrowserItemChanged != null)
            {
                _OnSelectedProjectBrowserItemChanged(null);
            }
        }
    }
}
