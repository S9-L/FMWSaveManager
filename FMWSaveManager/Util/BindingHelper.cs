using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace FMWSaveManager.Util
{
    public static class BindingHelper
    {
        // Source - https://stackoverflow.com/a/44188565
        // Posted by TaW, modified by community. See post 'Timeline' for change history
        // Retrieved 2026-06-16, License - CC BY-SA 3.0
        public static void SetDoubleBuffer(Control ctl, bool DoubleBuffered)
        {
            typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, ctl, new object[] { DoubleBuffered });
        }

        public static void BindListValues<T>(Control[] ctlArray, string propertyName, List<T> gridList)
        {
            for (int i = 0; i < ctlArray.Length; i++)
            {
                ctlArray[i].DataBindings.Clear();
                BindingSource sourceBinding = new BindingSource();
                sourceBinding.DataSource = gridList;
                sourceBinding.Position = i;

                ctlArray[i].DataBindings.Add(propertyName, sourceBinding, "", false, DataSourceUpdateMode.OnPropertyChanged);
            }
        }

        public static void BindListValues<T>(Control ctl, string propertyName, List<T> listInst, int index)
        {
            ctl.DataBindings.Clear();
            BindingSource sourceBinding = new BindingSource();
            sourceBinding.DataSource = listInst;
            sourceBinding.Position = index;

            ctl.DataBindings.Add(propertyName, sourceBinding, "", false, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
