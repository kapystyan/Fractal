namespace Mandelbrot
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			Viewport_PictureBox = new PictureBox();
			Terminal_TextBox = new TextBox();
			Settings_Panel = new Panel();
			Scale_Panel = new Panel();
			BaseScale_Label = new Label();
			BaseScaleName_L = new Label();
			Scale_TrackBar = new TrackBar();
			Control_Panel = new Panel();
			ChooseColor_BT = new Button();
			Generate_BT = new Button();
			Quality_Panel = new Panel();
			QualityValue_Label = new Label();
			Quality_TrackBar = new TrackBar();
			QualityName_Label = new Label();
			MousePosition_L = new Label();
			FractalZoneColor = new ColorDialog();
			CloseForm_BT = new Button();
			MinimiseForm_BT = new Button();
			((System.ComponentModel.ISupportInitialize)Viewport_PictureBox).BeginInit();
			Settings_Panel.SuspendLayout();
			Scale_Panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)Scale_TrackBar).BeginInit();
			Control_Panel.SuspendLayout();
			Quality_Panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)Quality_TrackBar).BeginInit();
			SuspendLayout();
			// 
			// Viewport_PictureBox
			// 
			Viewport_PictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			Viewport_PictureBox.BackColor = Color.Transparent;
			Viewport_PictureBox.Location = new Point(0, 33);
			Viewport_PictureBox.Name = "Viewport_PictureBox";
			Viewport_PictureBox.Size = new Size(1474, 800);
			Viewport_PictureBox.TabIndex = 0;
			Viewport_PictureBox.TabStop = false;
			// 
			// Terminal_TextBox
			// 
			Terminal_TextBox.BackColor = SystemColors.InfoText;
			Terminal_TextBox.Dock = DockStyle.Bottom;
			Terminal_TextBox.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			Terminal_TextBox.ForeColor = SystemColors.Info;
			Terminal_TextBox.ImeMode = ImeMode.Disable;
			Terminal_TextBox.Location = new Point(0, 839);
			Terminal_TextBox.Multiline = true;
			Terminal_TextBox.Name = "Terminal_TextBox";
			Terminal_TextBox.ReadOnly = true;
			Terminal_TextBox.ScrollBars = ScrollBars.Vertical;
			Terminal_TextBox.ShortcutsEnabled = false;
			Terminal_TextBox.Size = new Size(1824, 161);
			Terminal_TextBox.TabIndex = 3;
			// 
			// Settings_Panel
			// 
			Settings_Panel.BackColor = Color.FromArgb(20, 20, 20);
			Settings_Panel.Controls.Add(Scale_Panel);
			Settings_Panel.Controls.Add(Control_Panel);
			Settings_Panel.Controls.Add(Quality_Panel);
			Settings_Panel.Location = new Point(1481, 33);
			Settings_Panel.Name = "Settings_Panel";
			Settings_Panel.Size = new Size(343, 800);
			Settings_Panel.TabIndex = 4;
			// 
			// Scale_Panel
			// 
			Scale_Panel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			Scale_Panel.BackColor = Color.Transparent;
			Scale_Panel.Controls.Add(BaseScale_Label);
			Scale_Panel.Controls.Add(BaseScaleName_L);
			Scale_Panel.Controls.Add(Scale_TrackBar);
			Scale_Panel.Location = new Point(3, 77);
			Scale_Panel.Name = "Scale_Panel";
			Scale_Panel.Size = new Size(337, 64);
			Scale_Panel.TabIndex = 5;
			// 
			// BaseScale_Label
			// 
			BaseScale_Label.AutoSize = true;
			BaseScale_Label.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			BaseScale_Label.ForeColor = SystemColors.Control;
			BaseScale_Label.Location = new Point(125, 2);
			BaseScale_Label.Name = "BaseScale_Label";
			BaseScale_Label.Size = new Size(25, 15);
			BaseScale_Label.TabIndex = 4;
			BaseScale_Label.Text = "200";
			BaseScale_Label.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// BaseScaleName_L
			// 
			BaseScaleName_L.AutoSize = true;
			BaseScaleName_L.ForeColor = SystemColors.Control;
			BaseScaleName_L.Location = new Point(0, 2);
			BaseScaleName_L.Name = "BaseScaleName_L";
			BaseScaleName_L.Size = new Size(119, 15);
			BaseScaleName_L.TabIndex = 1;
			BaseScaleName_L.Text = "Базовое увеличение";
			// 
			// Scale_TrackBar
			// 
			Scale_TrackBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			Scale_TrackBar.BackColor = Color.FromArgb(20, 20, 20);
			Scale_TrackBar.Location = new Point(0, 20);
			Scale_TrackBar.Maximum = 5;
			Scale_TrackBar.Minimum = 2;
			Scale_TrackBar.Name = "Scale_TrackBar";
			Scale_TrackBar.Size = new Size(338, 45);
			Scale_TrackBar.TabIndex = 0;
			Scale_TrackBar.TickStyle = TickStyle.None;
			Scale_TrackBar.Value = 2;
			// 
			// Control_Panel
			// 
			Control_Panel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			Control_Panel.BackColor = Color.FromArgb(20, 20, 20);
			Control_Panel.Controls.Add(ChooseColor_BT);
			Control_Panel.Controls.Add(Generate_BT);
			Control_Panel.Location = new Point(0, 727);
			Control_Panel.Name = "Control_Panel";
			Control_Panel.Size = new Size(343, 67);
			Control_Panel.TabIndex = 1;
			// 
			// ChooseColor_BT
			// 
			ChooseColor_BT.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ChooseColor_BT.BackColor = Color.FromArgb(20, 20, 20);
			ChooseColor_BT.FlatAppearance.BorderColor = Color.Gray;
			ChooseColor_BT.FlatStyle = FlatStyle.Flat;
			ChooseColor_BT.ForeColor = SystemColors.ButtonFace;
			ChooseColor_BT.Location = new Point(3, 3);
			ChooseColor_BT.Name = "ChooseColor_BT";
			ChooseColor_BT.Size = new Size(337, 23);
			ChooseColor_BT.TabIndex = 0;
			ChooseColor_BT.Text = "Изменить цвет";
			ChooseColor_BT.UseVisualStyleBackColor = false;
			// 
			// Generate_BT
			// 
			Generate_BT.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			Generate_BT.BackColor = Color.FromArgb(20, 20, 20);
			Generate_BT.FlatAppearance.BorderColor = Color.Gray;
			Generate_BT.FlatStyle = FlatStyle.Flat;
			Generate_BT.ForeColor = SystemColors.ButtonFace;
			Generate_BT.Location = new Point(3, 41);
			Generate_BT.Name = "Generate_BT";
			Generate_BT.Size = new Size(337, 23);
			Generate_BT.TabIndex = 0;
			Generate_BT.Text = "Сгенерировать";
			Generate_BT.UseVisualStyleBackColor = false;
			// 
			// Quality_Panel
			// 
			Quality_Panel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			Quality_Panel.BackColor = Color.Transparent;
			Quality_Panel.Controls.Add(QualityValue_Label);
			Quality_Panel.Controls.Add(Quality_TrackBar);
			Quality_Panel.Controls.Add(QualityName_Label);
			Quality_Panel.Location = new Point(3, 3);
			Quality_Panel.Name = "Quality_Panel";
			Quality_Panel.Size = new Size(337, 68);
			Quality_Panel.TabIndex = 3;
			// 
			// QualityValue_Label
			// 
			QualityValue_Label.AutoSize = true;
			QualityValue_Label.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			QualityValue_Label.ForeColor = SystemColors.Control;
			QualityValue_Label.Location = new Point(63, 3);
			QualityValue_Label.Name = "QualityValue_Label";
			QualityValue_Label.Size = new Size(19, 15);
			QualityValue_Label.TabIndex = 3;
			QualityValue_Label.Text = "50";
			QualityValue_Label.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// Quality_TrackBar
			// 
			Quality_TrackBar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			Quality_TrackBar.BackColor = Color.FromArgb(20, 20, 20);
			Quality_TrackBar.LargeChange = 1;
			Quality_TrackBar.Location = new Point(0, 21);
			Quality_TrackBar.Maximum = 150;
			Quality_TrackBar.Minimum = 30;
			Quality_TrackBar.Name = "Quality_TrackBar";
			Quality_TrackBar.Size = new Size(337, 45);
			Quality_TrackBar.TabIndex = 1;
			Quality_TrackBar.TickStyle = TickStyle.None;
			Quality_TrackBar.Value = 50;
			// 
			// QualityName_Label
			// 
			QualityName_Label.AutoSize = true;
			QualityName_Label.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			QualityName_Label.ForeColor = SystemColors.Control;
			QualityName_Label.Location = new Point(0, 3);
			QualityName_Label.Name = "QualityName_Label";
			QualityName_Label.Size = new Size(57, 15);
			QualityName_Label.TabIndex = 2;
			QualityName_Label.Text = "Качество";
			// 
			// MousePosition_L
			// 
			MousePosition_L.AutoSize = true;
			MousePosition_L.BackColor = Color.Black;
			MousePosition_L.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
			MousePosition_L.ForeColor = SystemColors.ButtonFace;
			MousePosition_L.Location = new Point(0, 811);
			MousePosition_L.Name = "MousePosition_L";
			MousePosition_L.Size = new Size(51, 22);
			MousePosition_L.TabIndex = 5;
			MousePosition_L.Text = "X: 0; Y:0";
			MousePosition_L.TextAlign = ContentAlignment.MiddleLeft;
			MousePosition_L.UseCompatibleTextRendering = true;
			// 
			// FractalZoneColor
			// 
			FractalZoneColor.Color = Color.Blue;
			// 
			// CloseForm_BT
			// 
			CloseForm_BT.BackColor = Color.Red;
			CloseForm_BT.FlatAppearance.BorderSize = 0;
			CloseForm_BT.FlatStyle = FlatStyle.Flat;
			CloseForm_BT.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			CloseForm_BT.ForeColor = SystemColors.ButtonFace;
			CloseForm_BT.Location = new Point(1794, 0);
			CloseForm_BT.Name = "CloseForm_BT";
			CloseForm_BT.Size = new Size(30, 30);
			CloseForm_BT.TabIndex = 6;
			CloseForm_BT.Text = "X";
			CloseForm_BT.UseVisualStyleBackColor = false;
			// 
			// MinimiseForm_BT
			// 
			MinimiseForm_BT.BackColor = Color.LightGray;
			MinimiseForm_BT.FlatAppearance.BorderSize = 0;
			MinimiseForm_BT.FlatStyle = FlatStyle.Flat;
			MinimiseForm_BT.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			MinimiseForm_BT.ForeColor = SystemColors.ActiveCaptionText;
			MinimiseForm_BT.Location = new Point(1758, 0);
			MinimiseForm_BT.Name = "MinimiseForm_BT";
			MinimiseForm_BT.Size = new Size(30, 30);
			MinimiseForm_BT.TabIndex = 7;
			MinimiseForm_BT.Text = "__";
			MinimiseForm_BT.UseVisualStyleBackColor = false;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
			BackColor = Color.FromArgb(64, 64, 64);
			ClientSize = new Size(1824, 1000);
			Controls.Add(MinimiseForm_BT);
			Controls.Add(CloseForm_BT);
			Controls.Add(MousePosition_L);
			Controls.Add(Settings_Panel);
			Controls.Add(Terminal_TextBox);
			Controls.Add(Viewport_PictureBox);
			ForeColor = SystemColors.ControlText;
			FormBorderStyle = FormBorderStyle.None;
			MaximizeBox = false;
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Mandelbrot";
			((System.ComponentModel.ISupportInitialize)Viewport_PictureBox).EndInit();
			Settings_Panel.ResumeLayout(false);
			Scale_Panel.ResumeLayout(false);
			Scale_Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)Scale_TrackBar).EndInit();
			Control_Panel.ResumeLayout(false);
			Quality_Panel.ResumeLayout(false);
			Quality_Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)Quality_TrackBar).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox Viewport_PictureBox;
		private TextBox Terminal_TextBox;
		private Panel Settings_Panel;
		private Button Generate_BT;
		private TrackBar Quality_TrackBar;
		private Label QualityName_Label;
		private Panel Quality_Panel;
		private Label MousePosition_L;
		private Label QualityValue_Label;
		private Panel Scale_Panel;
		private Label BaseScaleName_L;
		private TrackBar Scale_TrackBar;
		private Label BaseScale_Label;
		private Button ChooseColor_BT;
		private ColorDialog FractalZoneColor;
		private Panel Control_Panel;
		private Button CloseForm_BT;
		private Button MinimiseForm_BT;
	}
}
