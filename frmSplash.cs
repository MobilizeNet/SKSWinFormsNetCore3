using Microsoft.VisualBasic;
using System;
using System.Windows.Forms;

namespace SKS
{
	internal partial class frmSplash
		: System.Windows.Forms.Form
	{

		public frmSplash()
			: base()
		{
			if (m_vb6FormDefInstance == null)
			{
				if (m_InitializingDefInstance)
				{
					m_vb6FormDefInstance = this;
				}
				else
				{
					try
					{
						//For the start-up form, the first instance created is the default instance.
						if (System.Reflection.Assembly.GetExecutingAssembly().EntryPoint != null && System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType == this.GetType())
						{
							m_vb6FormDefInstance = this;
						}
					}
					catch
					{
					}
				}
			}
			//This call is required by the Windows Form Designer.
			InitializeComponent();
		}




		private void Form_KeyPress(Object eventSender, KeyPressEventArgs eventArgs)
		{
			int KeyAscii = Strings.Asc(eventArgs.KeyChar);
			try
			{
				this.Close();
			}
			finally
			{
				if (KeyAscii == 0)
				{
					eventArgs.Handled = true;
				}
				eventArgs.KeyChar = Convert.ToChar(KeyAscii);
			}
		}

		//UPGRADE_NOTE: (7001) The following declaration (Frame1_Click) seems to be dead code More Information: https://www.mobilize.net/vbtonet/ewis/ewi7001
		//private void Frame1_Click()
		//{
			//this.Close();
		//}

		private void Timer1_Tick(Object eventSender, EventArgs eventArgs)
		{
			this.Close();
		}
		private void Form_Closed(Object eventSender, EventArgs eventArgs)
		{
		}
	}
}