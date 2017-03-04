using MahApps.Metro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
namespace ModernUIApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            GetProcess();
        }

        public void GetProcess()
        {
            Process[] process = Process.GetProcesses();
            for (int i = 0; i < process.Length; i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.MouseDoubleClick += lvi_MouseDoubleClick;
                ContextMenu menu = new System.Windows.Controls.ContextMenu();
                MenuItem stop = new MenuItem();
                stop.Click += stop_Click;
                stop.Header = "停止该进程";
                menu.Items.Add(stop);
                lvi.ContextMenu = menu;
                lvi.Content = process[i].ProcessName;
                List.Items.Add(lvi);
            }
        }

        void stop_Click(object sender, RoutedEventArgs e)
        {
             Object obj =  ContextMenuService.GetPlacementTarget(
                LogicalTreeHelper.GetParent(sender as MenuItem));
            ListViewItem list = obj as ListViewItem;
            MessageBox.Show(list.Content.ToString());
        }

        void lvi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListViewItem btn = sender as ListViewItem;
            String content = btn.Content.ToString();
            MessageBox.Show(content);
            
            ;
        }
    }
}
