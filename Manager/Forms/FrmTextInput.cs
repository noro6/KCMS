using Manager.Util;
using System;
using System.Windows.Forms;

namespace Manager.Forms
{
	public partial class FrmTextInput : Form
	{
		/// <summary>
		/// 入力されている値
		/// </summary>
		public string InputText { private set; get; }

		/// <summary>
		/// 初期入力値
		/// </summary>
		public object InitializeText { set; get; }

		/// <summary>
		/// 情報テキスト
		/// </summary>
		public string InfomationText { set; private get; }

		/// <summary>
		/// キャンセルされたかどうか
		/// </summary>
		public bool IsCanceled { private set; get; }

		/// <summary>
		/// 空文字を許容するかどうか
		/// </summary>
		public bool IsEmptyOK { set; get; } = false;

		/// <summary>
		/// 数値のみを許容するか
		/// </summary>
		public bool IsNumberOnly { set; get; } = false;

		public FrmTextInput()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 初期化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmTextInput_Load(object sender, EventArgs e)
		{
			lblInfomation.Text = InfomationText;
			txtInput.Text = ConvertUtil.ToString(InitializeText);

			IsCanceled = true;
			InitializeText = "";
		}

		/// <summary>
		/// OKクリック時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOK_Click(object sender, EventArgs e)
		{
			InputText = ConvertUtil.ToString(txtInput.Text).Trim();

			// エラーチェック
			if (!IsEmptyOK && InputText == "")
			{
				MessageBox.Show("未入力エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (IsNumberOnly && InputText != "0" && ConvertUtil.ToInt(InputText) == 0)
			{
				// 未入力が許容されてるなら空文字の場合のみセーフ
				if(IsEmptyOK && InputText == "")
				{
					InputText = "0";
				}
				else
				{
					MessageBox.Show("数値入力エラー", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}

			IsCanceled = false;
			IsNumberOnly = false;
			Close();
		}

		/// <summary>
		/// キャンセルクリック時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnCancel_Click(object sender, EventArgs e)
		{
			IsNumberOnly = false;
			Close();
		}
	}
}
