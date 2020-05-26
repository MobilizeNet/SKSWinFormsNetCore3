//using Microsoft.VisualBasic.Compatibility.VB6;
using System;
using System.Windows.Forms;

namespace SKS
{
	internal partial class frmMain
		: System.Windows.Forms.Form
	{


		public frmMain()
			: base()
		{
			if (m_vb6FormDefInstance == null)
			{
				m_vb6FormDefInstance = this;
			}
			//This call is required by the Windows Form Designer.
			InitializeComponent();
		}


		//UPGRADE_WARNING: (2080) Form_Load event was upgraded to Form_Load method and has a new behavior. More Information: https://www.mobilize.net/vbtonet/ewis/ewi2080
		private void MDIForm_Load()
		{
			frmSplash.DefInstance.ShowDialog();
			frmOrderRequest.DefInstance.Show();


		}

		public void mnuAbout_Click(Object eventSender, EventArgs eventArgs)
		{
			frmAbout.DefInstance.ShowDialog(this);
		}

		public void mnuAddStockManually_Click(Object eventSender, EventArgs eventArgs)
		{
			frmAddStockManual.DefInstance.Show();
		}

		public void mnuAdjustStockManually_Click(Object eventSender, EventArgs eventArgs)
		{
			frmAdjustStockManual.DefInstance.Show();
		}

		public void mnuCreateOrderReception_Click(Object eventSender, EventArgs eventArgs)
		{
			frmOrderReception.DefInstance.Show();
		}

		public void mnuCreateOrderRequest_Click(Object eventSender, EventArgs eventArgs)
		{
			frmOrderRequest.DefInstance.Show();
		}

		public void mnuCustomer_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				frmCustomers.DefInstance.ShowDialog();
				frmCustomers.DefInstance.InitForm();
			}
			catch
			{ }
		}

		public void mnuExit_Click(Object eventSender, EventArgs eventArgs)
		{
			this.Close();
		}

		public void mnuOrderReceptionsApproval_Click(Object eventSender, EventArgs eventArgs)
		{
			frmReceptionApproval.DefInstance.Show();
		}

		public void mnuOrderRequestsApproval_Click(Object eventSender, EventArgs eventArgs)
		{
			frmRequestApproval.DefInstance.Show();
		}

		public void mnuProducts_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				frmProducts.DefInstance.ShowDialog();
			}
			catch { }
		}

		public void mnuProviders_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				frmProviders.DefInstance.ShowDialog();
			}
			catch { }
		}

		public void mnuSecurity_Click(Object eventSender, EventArgs eventArgs)
		{
			try
			{
				frmUsersManage.DefInstance.Show();
			}
			catch { }
		}
		//UPGRADE_NOTE: (7001) The following declaration (Form_Unload) seems to be dead code More Information: https://www.mobilize.net/vbtonet/ewis/ewi7001
		//private void Form_Unload(int Cancel)
		//{
		//}
	}
}