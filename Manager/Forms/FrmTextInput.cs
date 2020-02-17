using System;
using System.Windows.Forms;

namespace Manager.Forms
{
	public partial class FrmTextInput : Form
	{
		public string InputText { set; get; }

		public string InfomationText { set; private get; }

		public bool IsCanceled { private set; get; }

		public bool IsEmptyOK { set; get; } = false;

		public FrmTextInput()
		{
			InitializeComponent();
		}

		private void BtnOK_Click(object sender, EventArgs e)
		{
			InputText = Util.ConvertUtil.ToString(txtInput.Text).Trim();
			if (!IsEmptyOK && InputText == "") return;
			IsCanceled = false;
			Close();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void FrmTextInput_Load(object sender, EventArgs e)
		{
			lblInfomation.Text = InfomationText;
			txtInput.Text = "";
			IsCanceled = true;
		}
	}
}
