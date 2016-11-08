using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SoundManService
{
	public class Service1 : System.ServiceProcess.ServiceBase
	{
		#region Global Variables
		string _command;
        string _playing;
		RegistryKey SoundMan = Registry.CurrentUser;
		[DllImport("winmm.dll")]
		private static extern long mciSendString(string strCommand,StringBuilder strReturn,int iReturnLength, IntPtr hwndCallback);
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem menuItemPF1;
		private System.Windows.Forms.MenuItem menuItemPF2;
		private System.Windows.Forms.MenuItem menuItemPF3;
		private System.Windows.Forms.MenuItem menuItemPF4;
		private System.Windows.Forms.MenuItem menuItemPF5;
		private System.Windows.Forms.MenuItem menuItemPF6;
		private System.Windows.Forms.MenuItem menuItemPF7;
		private System.Windows.Forms.MenuItem menuItemPF8;
		private System.Windows.Forms.MenuItem menuItemPF9;
		private System.Windows.Forms.MenuItem menuItemPF10;
		private System.Windows.Forms.MenuItem menuItemPF11;
		private System.Windows.Forms.MenuItem menuItemPF12;
		private System.Windows.Forms.MenuItem menuItemNF1;
		private System.Windows.Forms.MenuItem menuItemNF2;
		private System.Windows.Forms.MenuItem menuItemNF3;
		private System.Windows.Forms.MenuItem menuItemNF4;
		private System.Windows.Forms.MenuItem menuItemNF5;
		private System.Windows.Forms.MenuItem menuItemNF6;
		private System.Windows.Forms.MenuItem menuItemNF7;
		private System.Windows.Forms.MenuItem menuItemNF8;
		private System.Windows.Forms.MenuItem menuItemNF9;
		private System.Windows.Forms.MenuItem menuItemNF10;
		private System.Windows.Forms.MenuItem menuItemNF11;
		private System.Windows.Forms.MenuItem menuItemNF12;
		private System.Windows.Forms.MenuItem menuItemSF1;
		private System.Windows.Forms.MenuItem menuItemSF2;
		private System.Windows.Forms.MenuItem menuItemSF3;
		private System.Windows.Forms.MenuItem menuItemSF4;
		private System.Windows.Forms.MenuItem menuItemSF5;
		private System.Windows.Forms.MenuItem menuItemSF6;
		private System.Windows.Forms.MenuItem menuItemSF7;
		private System.Windows.Forms.MenuItem menuItemSF8;
		private System.Windows.Forms.MenuItem menuItemSF9;
		private System.Windows.Forms.MenuItem menuItemSF10;
		private System.Windows.Forms.MenuItem menuItemSF11;
		private System.Windows.Forms.MenuItem menuItemSF12;
		private System.Windows.Forms.MenuItem menuItemStop;
		private System.Windows.Forms.MenuItem menuItemAbout;
		private System.Windows.Forms.MenuItem menuItemClear;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.IContainer components;
        #endregion
        #region Design Components
		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new Service1() };
			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Service1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItemSF1 = new System.Windows.Forms.MenuItem();
            this.menuItemNF1 = new System.Windows.Forms.MenuItem();
            this.menuItemPF1 = new System.Windows.Forms.MenuItem();
            this.menuItemSF2 = new System.Windows.Forms.MenuItem();
            this.menuItemNF2 = new System.Windows.Forms.MenuItem();
            this.menuItemPF2 = new System.Windows.Forms.MenuItem();
            this.menuItemSF3 = new System.Windows.Forms.MenuItem();
            this.menuItemNF3 = new System.Windows.Forms.MenuItem();
            this.menuItemPF3 = new System.Windows.Forms.MenuItem();
            this.menuItemSF4 = new System.Windows.Forms.MenuItem();
            this.menuItemNF4 = new System.Windows.Forms.MenuItem();
            this.menuItemPF4 = new System.Windows.Forms.MenuItem();
            this.menuItemSF5 = new System.Windows.Forms.MenuItem();
            this.menuItemNF5 = new System.Windows.Forms.MenuItem();
            this.menuItemPF5 = new System.Windows.Forms.MenuItem();
            this.menuItemSF6 = new System.Windows.Forms.MenuItem();
            this.menuItemNF6 = new System.Windows.Forms.MenuItem();
            this.menuItemPF6 = new System.Windows.Forms.MenuItem();
            this.menuItemSF7 = new System.Windows.Forms.MenuItem();
            this.menuItemNF7 = new System.Windows.Forms.MenuItem();
            this.menuItemPF7 = new System.Windows.Forms.MenuItem();
            this.menuItemSF8 = new System.Windows.Forms.MenuItem();
            this.menuItemNF8 = new System.Windows.Forms.MenuItem();
            this.menuItemPF8 = new System.Windows.Forms.MenuItem();
            this.menuItemSF9 = new System.Windows.Forms.MenuItem();
            this.menuItemNF9 = new System.Windows.Forms.MenuItem();
            this.menuItemPF9 = new System.Windows.Forms.MenuItem();
            this.menuItemSF10 = new System.Windows.Forms.MenuItem();
            this.menuItemNF10 = new System.Windows.Forms.MenuItem();
            this.menuItemPF10 = new System.Windows.Forms.MenuItem();
            this.menuItemSF11 = new System.Windows.Forms.MenuItem();
            this.menuItemNF11 = new System.Windows.Forms.MenuItem();
            this.menuItemPF11 = new System.Windows.Forms.MenuItem();
            this.menuItemSF12 = new System.Windows.Forms.MenuItem();
            this.menuItemNF12 = new System.Windows.Forms.MenuItem();
            this.menuItemPF12 = new System.Windows.Forms.MenuItem();
            this.menuItemStop = new System.Windows.Forms.MenuItem();
            this.menuItemClear = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenu = this.contextMenu1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SoundManager";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemSF1,
            this.menuItemSF2,
            this.menuItemSF3,
            this.menuItemSF4,
            this.menuItemSF5,
            this.menuItemSF6,
            this.menuItemSF7,
            this.menuItemSF8,
            this.menuItemSF9,
            this.menuItemSF10,
            this.menuItemSF11,
            this.menuItemSF12,
            this.menuItemStop,
            this.menuItemClear,
            this.menuItemAbout});
            // 
            // menuItemSF1
            // 
            this.menuItemSF1.Index = 0;
            this.menuItemSF1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNF1,
            this.menuItemPF1});
            this.menuItemSF1.Text = "SoundF&1";
            // 
            // menuItemNF1
            // 
            this.menuItemNF1.Index = 0;
            this.menuItemNF1.Shortcut = System.Windows.Forms.Shortcut.CtrlF1;
            this.menuItemNF1.Text = "&New";
            this.menuItemNF1.Click += new System.EventHandler(this.OnNewF1Click);
            // 
            // menuItemPF1
            // 
            this.menuItemPF1.Index = 1;
            this.menuItemPF1.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.menuItemPF1.Text = "&Play";
            this.menuItemPF1.Click += new System.EventHandler(this.OnPlayF1Click);
            // 
            // menuItemSF2
            // 
            this.menuItemSF2.Index = 1;
            this.menuItemSF2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNF2,
            this.menuItemPF2});
            this.menuItemSF2.Text = "SoundF&2";
            // 
            // menuItemNF2
            // 
            this.menuItemNF2.Index = 0;
            this.menuItemNF2.Shortcut = System.Windows.Forms.Shortcut.CtrlF2;
            this.menuItemNF2.Text = "&New";
            this.menuItemNF2.Click += new System.EventHandler(this.OnNewF2Click);
            // 
            // menuItemPF2
            // 
            this.menuItemPF2.Index = 1;
            this.menuItemPF2.Shortcut = System.Windows.Forms.Shortcut.F2;
            this.menuItemPF2.Text = "&Play";
            this.menuItemPF2.Click += new System.EventHandler(this.OnPlayF2Click);
            // 
            // menuItemSF3
            // 
            this.menuItemSF3.Index = 2;
            this.menuItemSF3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNF3,
            this.menuItemPF3});
            this.menuItemSF3.Text = "SoundF&3";
            // 
            // menuItemNF3
            // 
            this.menuItemNF3.Index = 0;
            this.menuItemNF3.Shortcut = System.Windows.Forms.Shortcut.CtrlF3;
            this.menuItemNF3.Text = "&New";
            this.menuItemNF3.Click += new System.EventHandler(this.OnNewF3Click);
            // 
            // menuItemPF3
            // 
            this.menuItemPF3.Index = 1;
            this.menuItemPF3.Shortcut = System.Windows.Forms.Shortcut.F3;
            this.menuItemPF3.Text = "&Play";
            this.menuItemPF3.Click += new System.EventHandler(this.OnPlayF3Click);
            // 
            // menuItemSF4
            // 
            this.menuItemSF4.Index = 3;
            this.menuItemSF4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNF4,
            this.menuItemPF4});
            this.menuItemSF4.Text = "SoundF&4";
            // 
            // menuItemNF4
            // 
            this.menuItemNF4.Index = 0;
            this.menuItemNF4.Shortcut = System.Windows.Forms.Shortcut.CtrlF4;
            this.menuItemNF4.Text = "&New";
            this.menuItemNF4.Click += new System.EventHandler(this.OnNewF4Click);
            // 
            // menuItemPF4
            // 
            this.menuItemPF4.Index = 1;
            this.menuItemPF4.Shortcut = System.Windows.Forms.Shortcut.F4;
            this.menuItemPF4.Text = "&Play";
            this.menuItemPF4.Click += new System.EventHandler(this.OnPlayF4Click);
            // 
            // menuItemSF5
            // 
            this.menuItemSF5.Index = 4;
            this.menuItemSF5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNF5,
            this.menuItemPF5});
            this.menuItemSF5.Text = "SoundF&5";
            // 
            // menuItemNF5
            // 
            this.menuItemNF5.Index = 0;
            this.menuItemNF5.Shortcut = System.Windows.Forms.Shortcut.CtrlF5;
            this.menuItemNF5.Text = "&New";
            this.menuItemNF5.Click += new System.EventHandler(this.OnNewF5Click);
            // 
            // menuItemPF5
            // 
            this.menuItemPF5.Index = 1;
            this.menuItemPF5.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.menuItemPF5.Text = "&Play";
            this.menuItemPF5.Click += new System.EventHandler(this.OnPlayF5Click);
            // 
            // menuItemSF6
            // 
            this.menuItemSF6.Index = 5;
            this.menuItemSF6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNF6,
            this.menuItemPF6});
            this.menuItemSF6.Text = "SoundF&6";
            // 
            // menuItemNF6
            // 
            this.menuItemNF6.Index = 0;
            this.menuItemNF6.Shortcut = System.Windows.Forms.Shortcut.CtrlF6;
            this.menuItemNF6.Text = "&New";
            this.menuItemNF6.Click += new System.EventHandler(this.OnNewF6Click);
            // 
            // menuItemPF6
            // 
            this.menuItemPF6.Index = 1;
            this.menuItemPF6.Shortcut = System.Windows.Forms.Shortcut.F6;
            this.menuItemPF6.Text = "&Play";
            this.menuItemPF6.Click += new System.EventHandler(this.OnPlayF6Click);
            // 
            // menuItemSF7
            // 
            this.menuItemSF7.Index = 6;
            this.menuItemSF7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNF7,
            this.menuItemPF7});
            this.menuItemSF7.Text = "SoundF&7";
            // 
            // menuItemNF7
            // 
            this.menuItemNF7.Index = 0;
            this.menuItemNF7.Shortcut = System.Windows.Forms.Shortcut.CtrlF7;
            this.menuItemNF7.Text = "&New";
            this.menuItemNF7.Click += new System.EventHandler(this.OnNewF7Click);
            // 
            // menuItemPF7
            // 
            this.menuItemPF7.Index = 1;
            this.menuItemPF7.Shortcut = System.Windows.Forms.Shortcut.F7;
            this.menuItemPF7.Text = "&Play";
            this.menuItemPF7.Click += new System.EventHandler(this.OnPlayF7Click);
            // 
            // menuItemSF8
            // 
            this.menuItemSF8.Index = 7;
            this.menuItemSF8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNF8,
            this.menuItemPF8});
            this.menuItemSF8.Text = "SoundF&8";
            // 
            // menuItemNF8
            // 
            this.menuItemNF8.Index = 0;
            this.menuItemNF8.Shortcut = System.Windows.Forms.Shortcut.CtrlF8;
            this.menuItemNF8.Text = "&New";
            this.menuItemNF8.Click += new System.EventHandler(this.OnNewF8Click);
            // 
            // menuItemPF8
            // 
            this.menuItemPF8.Index = 1;
            this.menuItemPF8.Shortcut = System.Windows.Forms.Shortcut.F8;
            this.menuItemPF8.Text = "&Play";
            this.menuItemPF8.Click += new System.EventHandler(this.OnPlayF8Click);
            // 
            // menuItemSF9
            // 
            this.menuItemSF9.Index = 8;
            this.menuItemSF9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNF9,
            this.menuItemPF9});
            this.menuItemSF9.Text = "SoundF&9";
            // 
            // menuItemNF9
            // 
            this.menuItemNF9.Index = 0;
            this.menuItemNF9.Shortcut = System.Windows.Forms.Shortcut.CtrlF9;
            this.menuItemNF9.Text = "&New";
            this.menuItemNF9.Click += new System.EventHandler(this.OnNewF9Click);
            // 
            // menuItemPF9
            // 
            this.menuItemPF9.Index = 1;
            this.menuItemPF9.Shortcut = System.Windows.Forms.Shortcut.F9;
            this.menuItemPF9.Text = "&Play";
            this.menuItemPF9.Click += new System.EventHandler(this.OnPlayF9Click);
            // 
            // menuItemSF10
            // 
            this.menuItemSF10.Index = 9;
            this.menuItemSF10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNF10,
            this.menuItemPF10});
            this.menuItemSF10.Text = "SoundF1&0";
            // 
            // menuItemNF10
            // 
            this.menuItemNF10.Index = 0;
            this.menuItemNF10.Shortcut = System.Windows.Forms.Shortcut.CtrlF10;
            this.menuItemNF10.Text = "&New";
            this.menuItemNF10.Click += new System.EventHandler(this.OnNewF10Click);
            // 
            // menuItemPF10
            // 
            this.menuItemPF10.Index = 1;
            this.menuItemPF10.Shortcut = System.Windows.Forms.Shortcut.F10;
            this.menuItemPF10.Text = "&Play";
            this.menuItemPF10.Click += new System.EventHandler(this.OnPlayF10Click);
            // 
            // menuItemSF11
            // 
            this.menuItemSF11.Index = 10;
            this.menuItemSF11.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNF11,
            this.menuItemPF11});
            this.menuItemSF11.Text = "SoundF11";
            // 
            // menuItemNF11
            // 
            this.menuItemNF11.Index = 0;
            this.menuItemNF11.Shortcut = System.Windows.Forms.Shortcut.CtrlF11;
            this.menuItemNF11.Text = "&New";
            this.menuItemNF11.Click += new System.EventHandler(this.OnNewF11Click);
            // 
            // menuItemPF11
            // 
            this.menuItemPF11.Index = 1;
            this.menuItemPF11.Shortcut = System.Windows.Forms.Shortcut.F11;
            this.menuItemPF11.Text = "&Play";
            this.menuItemPF11.Click += new System.EventHandler(this.OnPlayF11Click);
            // 
            // menuItemSF12
            // 
            this.menuItemSF12.Index = 11;
            this.menuItemSF12.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNF12,
            this.menuItemPF12});
            this.menuItemSF12.Text = "SoundF12";
            // 
            // menuItemNF12
            // 
            this.menuItemNF12.Index = 0;
            this.menuItemNF12.Shortcut = System.Windows.Forms.Shortcut.CtrlF12;
            this.menuItemNF12.Text = "&New";
            this.menuItemNF12.Click += new System.EventHandler(this.OnNewF12Click);
            // 
            // menuItemPF12
            // 
            this.menuItemPF12.Index = 1;
            this.menuItemPF12.Shortcut = System.Windows.Forms.Shortcut.F12;
            this.menuItemPF12.Text = "&Play";
            this.menuItemPF12.Click += new System.EventHandler(this.OnPlayF12Click);
            // 
            // menuItemStop
            // 
            this.menuItemStop.Index = 12;
            this.menuItemStop.Shortcut = System.Windows.Forms.Shortcut.Del;
            this.menuItemStop.Text = "S&top";
            this.menuItemStop.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // menuItemClear
            // 
            this.menuItemClear.Index = 13;
            this.menuItemClear.Text = "&Clear";
            this.menuItemClear.Click += new System.EventHandler(this.menuItemClear_Click);
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 14;
            this.menuItemAbout.Text = "&About";
            this.menuItemAbout.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Sound File|*.wav;*.mp3";
            this.openFileDialog1.Title = "Select a Wave Sound File";
            // 
            // Service1
            // 
            this.ServiceName = "Sound Manager";

		}
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion
		#region Service1 Events
		public Service1()
		{
			InitializeComponent();
			SoundMan.CreateSubKey(@"Software\SoundMan");
			SoundMan = SoundMan.OpenSubKey(@"Software\SoundMan",true);
			menuItemSF1.Text = SoundMan.GetValue("F1","SoundF&1").ToString();
			menuItemSF2.Text = SoundMan.GetValue("F2","SoundF&2").ToString();
			menuItemSF3.Text = SoundMan.GetValue("F3","SoundF&3").ToString();
			menuItemSF4.Text = SoundMan.GetValue("F4","SoundF&4").ToString();
			menuItemSF5.Text = SoundMan.GetValue("F5","SoundF&5").ToString();
			menuItemSF6.Text = SoundMan.GetValue("F6","SoundF&6").ToString();
			menuItemSF7.Text = SoundMan.GetValue("F7","SoundF&7").ToString();
			menuItemSF8.Text = SoundMan.GetValue("F8","SoundF&8").ToString();
			menuItemSF9.Text = SoundMan.GetValue("F9","SoundF&9").ToString();
			menuItemSF10.Text = SoundMan.GetValue("F10","SoundF1&0").ToString();
			menuItemSF11.Text = SoundMan.GetValue("F11","SoundF11").ToString();
			menuItemSF12.Text = SoundMan.GetValue("F12","SoundF12").ToString();
			mciSendString("open \"" + menuItemSF1.Text + "\" type mpegvideo alias F1", null, 0, IntPtr.Zero);
			mciSendString("open \"" + menuItemSF2.Text + "\" type mpegvideo alias F2", null, 0, IntPtr.Zero);
			mciSendString("open \"" + menuItemSF3.Text + "\" type mpegvideo alias F3", null, 0, IntPtr.Zero);
			mciSendString("open \"" + menuItemSF4.Text + "\" type mpegvideo alias F4", null, 0, IntPtr.Zero);
			mciSendString("open \"" + menuItemSF5.Text + "\" type mpegvideo alias F5", null, 0, IntPtr.Zero);
			mciSendString("open \"" + menuItemSF6.Text + "\" type mpegvideo alias F6", null, 0, IntPtr.Zero);
			mciSendString("open \"" + menuItemSF7.Text + "\" type mpegvideo alias F7", null, 0, IntPtr.Zero);
			mciSendString("open \"" + menuItemSF8.Text + "\" type mpegvideo alias F8", null, 0, IntPtr.Zero);
			mciSendString("open \"" + menuItemSF9.Text + "\" type mpegvideo alias F9", null, 0, IntPtr.Zero);
			mciSendString("open \"" + menuItemSF10.Text + "\" type mpegvideo alias F10", null, 0, IntPtr.Zero);
			mciSendString("open \"" + menuItemSF11.Text + "\" type mpegvideo alias F11", null, 0, IntPtr.Zero);
			mciSendString("open \"" + menuItemSF12.Text + "\" type mpegvideo alias F12", null, 0, IntPtr.Zero);
			notifyIcon1.Visible = true;
		}
		#endregion
		#region OnNew%%Click
		private void OnNewF1Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				menuItemSF1.Text = openFileDialog1.FileName;
				mciSendString("close F1", null, 0, IntPtr.Zero);
				_command = "open \"" + openFileDialog1.FileName + "\" type mpegvideo alias F1";
				mciSendString(_command, null, 0, IntPtr.Zero);
				SoundMan.SetValue("F1",openFileDialog1.FileName);
				OnPlayF1Click(sender,e);
			}
		}
		private void OnNewF2Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				menuItemSF2.Text = openFileDialog1.FileName;
				mciSendString("close F2", null, 0, IntPtr.Zero);
				_command = "open \"" + openFileDialog1.FileName + "\" type mpegvideo alias F2";
				mciSendString(_command, null, 0, IntPtr.Zero);
				SoundMan.SetValue("F2",openFileDialog1.FileName);
				OnPlayF2Click(sender,e);
			}
		}
		private void OnNewF3Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				menuItemSF3.Text = openFileDialog1.FileName;
				mciSendString("close F3", null, 0, IntPtr.Zero);
				_command = "open \"" + openFileDialog1.FileName + "\" type mpegvideo alias F3";
				mciSendString(_command, null, 0, IntPtr.Zero);
				SoundMan.SetValue("F3",openFileDialog1.FileName);
				OnPlayF3Click(sender,e);
			}
		}
		private void OnNewF4Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				menuItemSF4.Text = openFileDialog1.FileName;
				mciSendString("close F4", null, 0, IntPtr.Zero);
				_command = "open \"" + openFileDialog1.FileName + "\" type mpegvideo alias F4";
				mciSendString(_command, null, 0, IntPtr.Zero);
				SoundMan.SetValue("F4",openFileDialog1.FileName);
				OnPlayF4Click(sender,e);
			}
		}
		private void OnNewF5Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				menuItemSF5.Text = openFileDialog1.FileName;
				mciSendString("close F5", null, 0, IntPtr.Zero);
				_command = "open \"" + openFileDialog1.FileName + "\" type mpegvideo alias F5";
				mciSendString(_command, null, 0, IntPtr.Zero);
				SoundMan.SetValue("F5",openFileDialog1.FileName);
				OnPlayF5Click(sender,e);
			}
		}
		private void OnNewF6Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				menuItemSF6.Text = openFileDialog1.FileName;
				mciSendString("close F6", null, 0, IntPtr.Zero);
				_command = "open \"" + openFileDialog1.FileName + "\" type mpegvideo alias F6";
				mciSendString(_command, null, 0, IntPtr.Zero);
				SoundMan.SetValue("F6",openFileDialog1.FileName);
				OnPlayF6Click(sender,e);
			}
		}
		private void OnNewF7Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				menuItemSF7.Text = openFileDialog1.FileName;
				mciSendString("close F7", null, 0, IntPtr.Zero);
				_command = "open \"" + openFileDialog1.FileName + "\" type mpegvideo alias F7";
				mciSendString(_command, null, 0, IntPtr.Zero);
				SoundMan.SetValue("F7",openFileDialog1.FileName);
				OnPlayF7Click(sender,e);
			}
		}
		private void OnNewF8Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				menuItemSF8.Text = openFileDialog1.FileName;
				mciSendString("close F8", null, 0, IntPtr.Zero);
				_command = "open \"" + openFileDialog1.FileName + "\" type mpegvideo alias F8";
				mciSendString(_command, null, 0, IntPtr.Zero);
				SoundMan.SetValue("F8",openFileDialog1.FileName);
				OnPlayF8Click(sender,e);
			}
		}
		private void OnNewF9Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				menuItemSF9.Text = openFileDialog1.FileName;
				mciSendString("close F9", null, 0, IntPtr.Zero);
				_command = "open \"" + openFileDialog1.FileName + "\" type mpegvideo alias F9";
				mciSendString(_command, null, 0, IntPtr.Zero);
				SoundMan.SetValue("F9",openFileDialog1.FileName);
				OnPlayF9Click(sender,e);
			}
		}
		private void OnNewF10Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				menuItemSF10.Text = openFileDialog1.FileName;
				mciSendString("close F10", null, 0, IntPtr.Zero);
				_command = "open \"" + openFileDialog1.FileName + "\" type mpegvideo alias F10";
				mciSendString(_command, null, 0, IntPtr.Zero);
				SoundMan.SetValue("F10",openFileDialog1.FileName);
				OnPlayF10Click(sender,e);
			}
		}
		private void OnNewF11Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				menuItemSF11.Text = openFileDialog1.FileName;
				mciSendString("close F11", null, 0, IntPtr.Zero);
				_command = "open \"" + openFileDialog1.FileName + "\" type mpegvideo alias F11";
				mciSendString(_command, null, 0, IntPtr.Zero);
				SoundMan.SetValue("F11",openFileDialog1.FileName);
				OnPlayF11Click(sender,e);
			}
		}
		private void OnNewF12Click(object sender, System.EventArgs e)
		{
			if(openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				menuItemSF12.Text = openFileDialog1.FileName;
				mciSendString("close F12", null, 0, IntPtr.Zero);
				_command = "open \"" + openFileDialog1.FileName + "\" type mpegvideo alias F12";
				mciSendString(_command, null, 0, IntPtr.Zero);
				SoundMan.SetValue("F12",openFileDialog1.FileName);
				OnPlayF12Click(sender,e);
			}
		}
		#endregion
		#region OnPlay%%Click
		private void OnPlayF1Click(object sender, System.EventArgs e)
		{
			StopButton_Click(sender, e);
			if(menuItemSF1.Text != "SoundF&1")
			{
				_playing = "F1";
				StopButton_Click(sender, e);
				_playing = "F1";
				if(File.Exists(menuItemSF1.Text))
				{
					mciSendString("play F1", null, 0, IntPtr.Zero);
				}
				else
				{
					MessageBox.Show(menuItemSF1.Text + " does not exist.", "File does not exist");
					menuItemSF1.Text = "SoundF&1";
					SoundMan.DeleteValue("F1", false);
					OnNewF1Click(sender, e);
				}
			}
			else
			{
				OnNewF1Click(sender,e);
			}
		}
		private void OnPlayF2Click(object sender, System.EventArgs e)
		{
			StopButton_Click(sender, e);
			if(menuItemSF2.Text != "SoundF&2")
			{
				_playing = "F2";
				StopButton_Click(sender, e);
				_playing = "F2";
				if (File.Exists(menuItemSF2.Text))
				{
					mciSendString("play F2", null, 0, IntPtr.Zero);
				}
				else
				{
					MessageBox.Show(menuItemSF2.Text + " does not exist.", "File does not exist");
					menuItemSF2.Text = "SoundF&2";
					SoundMan.DeleteValue("F2", false);
					OnNewF2Click(sender, e);
				}
			}
			else
			{
				OnNewF2Click(sender,e);
			}
		}
		private void OnPlayF3Click(object sender, System.EventArgs e)
		{
			StopButton_Click(sender, e);
			if(menuItemSF3.Text != "SoundF&3")
			{
				_playing = "F3";
				StopButton_Click(sender, e);
				_playing = "F3";
				if (File.Exists(menuItemSF3.Text))
				{
					mciSendString("play F3", null, 0, IntPtr.Zero);
				}
				else
				{
					MessageBox.Show(menuItemSF3.Text + " does not exist.", "File does not exist");
					menuItemSF3.Text = "SoundF&3";
					SoundMan.DeleteValue("F3", false);
					OnNewF3Click(sender, e);
				}
			}
			else
			{
				OnNewF3Click(sender,e);
			}
		}
		private void OnPlayF4Click(object sender, System.EventArgs e)
		{
			StopButton_Click(sender, e);
			if(menuItemSF4.Text != "SoundF&4")
			{
				_playing = "F4";
				StopButton_Click(sender, e);
				_playing = "F4";
				if (File.Exists(menuItemSF4.Text))
				{
					mciSendString("play F4", null, 0, IntPtr.Zero);
				}
				else
				{
					MessageBox.Show(menuItemSF4.Text + " does not exist.", "File does not exist");
					menuItemSF4.Text = "SoundF&4";
					SoundMan.DeleteValue("F4", false);
					OnNewF4Click(sender, e);
				}
			}
			else
			{
				OnNewF4Click(sender,e);
			}
		}
		private void OnPlayF5Click(object sender, System.EventArgs e)
		{
			StopButton_Click(sender, e);
			if(menuItemSF5.Text != "SoundF&5")
			{
				_playing = "F5";
				StopButton_Click(sender, e);
				_playing = "F5";
				if (File.Exists(menuItemSF5.Text))
				{
					mciSendString("play F5", null, 0, IntPtr.Zero);
				}
				else
				{
					MessageBox.Show(menuItemSF5.Text + " does not exist.", "File does not exist");
					menuItemSF5.Text = "SoundF&5";
					SoundMan.DeleteValue("F5", false);
					OnNewF5Click(sender, e);
				}
			}
			else
			{
				OnNewF5Click(sender,e);
			}
		}
		private void OnPlayF6Click(object sender, System.EventArgs e)
		{
			StopButton_Click(sender, e);
			if(menuItemSF6.Text != "SoundF&6")
			{
				_playing = "F6";
				StopButton_Click(sender, e);
				_playing = "F6";
				if (File.Exists(menuItemSF6.Text))
				{
					mciSendString("play F6", null, 0, IntPtr.Zero);
				}
				else
				{
					MessageBox.Show(menuItemSF6.Text + " does not exist.", "File does not exist");
					menuItemSF6.Text = "SoundF&6";
					SoundMan.DeleteValue("F6", false);
					OnNewF6Click(sender, e);
				}
			}
			else
			{
				OnNewF6Click(sender,e);
			}
		}
		private void OnPlayF7Click(object sender, System.EventArgs e)
		{
			StopButton_Click(sender, e);
			if(menuItemSF7.Text != "SoundF&7")
			{
				_playing = "F7";
				StopButton_Click(sender, e);
				_playing = "F7";
				if (File.Exists(menuItemSF7.Text))
				{
					mciSendString("play F7", null, 0, IntPtr.Zero);
				}
				else
				{
					MessageBox.Show(menuItemSF7.Text + " does not exist.", "File does not exist");
					menuItemSF7.Text = "SoundF&7";
					SoundMan.DeleteValue("F7", false);
					OnNewF7Click(sender, e);
				}
			}
			else
			{
				OnNewF7Click(sender,e);
			}
		}
		private void OnPlayF8Click(object sender, System.EventArgs e)
		{
			StopButton_Click(sender, e);
			if(menuItemSF8.Text != "SoundF&8")
			{
				_playing = "F8";
				StopButton_Click(sender, e);
				_playing = "F8";
				if (File.Exists(menuItemSF8.Text))
				{
					mciSendString("play F8", null, 0, IntPtr.Zero);
				}
				else
				{
					MessageBox.Show(menuItemSF8.Text + " does not exist.", "File does not exist");
					menuItemSF8.Text = "SoundF&8";
					SoundMan.DeleteValue("F8", false);
					OnNewF8Click(sender, e);
				}
			}
			else
			{
				OnNewF8Click(sender,e);
			}
		}
		private void OnPlayF9Click(object sender, System.EventArgs e)
		{
			StopButton_Click(sender, e);
			if(menuItemSF9.Text != "SoundF&9")
			{
				_playing = "F9";
				StopButton_Click(sender, e);
				_playing = "F9";
				if (File.Exists(menuItemSF9.Text))
				{
					mciSendString("play F9", null, 0, IntPtr.Zero);
				}
				else
				{
					MessageBox.Show(menuItemSF9.Text + " does not exist.", "File does not exist");
					menuItemSF9.Text = "SoundF&9";
					SoundMan.DeleteValue("F9", false);
					OnNewF9Click(sender, e);
				}
			}
			else
			{
				OnNewF9Click(sender,e);
			}
		}
		private void OnPlayF10Click(object sender, System.EventArgs e)
		{
			StopButton_Click(sender, e);
			if(menuItemSF10.Text != "SoundF&10")
			{
				_playing = "F10";
				StopButton_Click(sender, e);
				_playing = "F10";
				if (File.Exists(menuItemSF10.Text))
				{
					mciSendString("play F10", null, 0, IntPtr.Zero);
				}
				else
				{
					MessageBox.Show(menuItemSF10.Text + " does not exist.", "File does not exist");
					menuItemSF10.Text = "SoundF&10";
					SoundMan.DeleteValue("F10", false);
					OnNewF10Click(sender, e);
				}
			}
			else
			{
				OnNewF10Click(sender,e);
			}
		}
		private void OnPlayF11Click(object sender, System.EventArgs e)
		{
			StopButton_Click(sender, e);
			if(menuItemSF11.Text != "SoundF&11")
			{
				_playing = "F11";
				StopButton_Click(sender, e);
				_playing = "F11";
				if (File.Exists(menuItemSF11.Text))
				{
					mciSendString("play F11", null, 0, IntPtr.Zero);
				}
				else
				{
					MessageBox.Show(menuItemSF11.Text + " does not exist.", "File does not exist");
					menuItemSF11.Text = "SoundF&11";
					SoundMan.DeleteValue("F11", false);
					OnNewF11Click(sender, e);
				}
			}
			else
			{
				OnNewF11Click(sender,e);
			}
		}
		private void OnPlayF12Click(object sender, System.EventArgs e)
		{
			StopButton_Click(sender, e);
			if(menuItemSF12.Text != "SoundF&12")
			{
				_playing = "F12";
				StopButton_Click(sender, e);
				_playing = "F12";
				if (File.Exists(menuItemSF12.Text))
				{
					mciSendString("play F12", null, 0, IntPtr.Zero);
				}
				else
				{
					MessageBox.Show(menuItemSF12.Text + " does not exist.", "File does not exist");
					menuItemSF12.Text = "SoundF&12";
					SoundMan.DeleteValue("F12", false);
					OnNewF12Click(sender, e);
				}
			}
			else
			{
				OnNewF12Click(sender,e);
			}
		}
		#endregion
		#region buttons
		private void StopButton_Click(object sender, System.EventArgs e)
		{
			mciSendString("close " + _playing, null, 0, IntPtr.Zero);
			if(_playing == "F1")
			{
				mciSendString("open \"" + menuItemSF1.Text + "\" type mpegvideo alias F1", null, 0, IntPtr.Zero);
			}
			else if(_playing == "F2")
			{
				mciSendString("open \"" + menuItemSF2.Text + "\" type mpegvideo alias F2", null, 0, IntPtr.Zero);
			}
			else if(_playing == "F3")
			{
				mciSendString("open \"" + menuItemSF3.Text + "\" type mpegvideo alias F3", null, 0, IntPtr.Zero);
			}
			else if(_playing == "F4")
			{
				mciSendString("open \"" + menuItemSF4.Text + "\" type mpegvideo alias F4", null, 0, IntPtr.Zero);
			}
			else if(_playing == "F5")
			{
				mciSendString("open \"" + menuItemSF5.Text + "\" type mpegvideo alias F5", null, 0, IntPtr.Zero);
			}
			else if(_playing == "F6")
			{
				mciSendString("open \"" + menuItemSF6.Text + "\" type mpegvideo alias F6", null, 0, IntPtr.Zero);
			}
			else if(_playing == "F7")
			{
				mciSendString("open \"" + menuItemSF7.Text + "\" type mpegvideo alias F7", null, 0, IntPtr.Zero);
			}
			else if(_playing == "F8")
			{
				mciSendString("open \"" + menuItemSF8.Text + "\" type mpegvideo alias F8", null, 0, IntPtr.Zero);
			}
			else if(_playing == "F9")
			{
				mciSendString("open \"" + menuItemSF9.Text + "\" type mpegvideo alias F9", null, 0, IntPtr.Zero);
			}
			else if(_playing == "F10")
			{
				mciSendString("open \"" + menuItemSF10.Text + "\" type mpegvideo alias F10", null, 0, IntPtr.Zero);
			}
			else if(_playing == "F11")
			{
				mciSendString("open \"" + menuItemSF11.Text + "\" type mpegvideo alias F11", null, 0, IntPtr.Zero);
			}
			else if(_playing == "F12")
			{
				mciSendString("open \"" + menuItemSF12.Text + "\" type mpegvideo alias F12", null, 0, IntPtr.Zero);
			}
			
			_playing = "";
		}
		private void AboutButton_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("          SoundManager" +
				"\n\n     Created By: Tony Brix" +
				"\n\n           UziTech.com", "About SoundManager", MessageBoxButtons.OK);
		}

		private void menuItemClear_Click(object sender, System.EventArgs e)
		{
			for(int i = 1; i < 13; i++)
			{
				_command = "close F" + i.ToString();
				mciSendString(_command, null, 0, IntPtr.Zero);
				SoundMan.DeleteValue("F" + i.ToString(),false);
			}
			menuItemSF1.Text = "SoundF&1";
			menuItemSF2.Text = "SoundF&2";
			menuItemSF3.Text = "SoundF&3";
			menuItemSF4.Text = "SoundF&4";
			menuItemSF5.Text = "SoundF&5";
			menuItemSF6.Text = "SoundF&6";
			menuItemSF7.Text = "SoundF&7";
			menuItemSF8.Text = "SoundF&8";
			menuItemSF9.Text = "SoundF&9";
			menuItemSF10.Text = "SoundF1&0";
			menuItemSF11.Text = "SoundF11";
			menuItemSF12.Text = "SoundF12";
		}
		#endregion
		protected override void OnStart(string[] args)
		{
			// TODO: Add code here to start your service.
			Debugger.Launch();
			Service1 t = new Service1();
		}
		protected override void OnStop()
		{
			// TODO: Add code here to perform any tear-down necessary to stop your service.
			SoundMan.Close();
			for(int i = 1; i < 13; i++)
			{
				_command = "close F" + i.ToString();
				mciSendString(_command, null, 0, IntPtr.Zero);
			}

		}
	}
}
