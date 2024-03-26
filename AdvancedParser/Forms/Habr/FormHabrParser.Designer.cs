namespace AdvancedParser.Forms.Habr
{
	partial class FormHabrParser
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.ListTitles = new System.Windows.Forms.ListBox();
			this.ButtonStart = new System.Windows.Forms.Button();
			this.ButtonAbort = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.NumericStart = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.NumericCount = new System.Windows.Forms.NumericUpDown();
			this.ButtonClearResult = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.NumericStart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.NumericCount)).BeginInit();
			this.SuspendLayout();
			// 
			// ListTitles
			// 
			this.ListTitles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ListTitles.FormattingEnabled = true;
			this.ListTitles.ItemHeight = 25;
			this.ListTitles.Location = new System.Drawing.Point(24, 23);
			this.ListTitles.Margin = new System.Windows.Forms.Padding(6);
			this.ListTitles.Name = "ListTitles";
			this.ListTitles.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ListTitles.Size = new System.Drawing.Size(556, 829);
			this.ListTitles.TabIndex = 0;
			this.ListTitles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListTitles_MouseDoubleClick);
			// 
			// ButtonStart
			// 
			this.ButtonStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonStart.Location = new System.Drawing.Point(626, 224);
			this.ButtonStart.Margin = new System.Windows.Forms.Padding(6);
			this.ButtonStart.Name = "ButtonStart";
			this.ButtonStart.Size = new System.Drawing.Size(240, 44);
			this.ButtonStart.TabIndex = 1;
			this.ButtonStart.Text = "Start";
			this.ButtonStart.UseVisualStyleBackColor = true;
			this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
			// 
			// ButtonAbort
			// 
			this.ButtonAbort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonAbort.Location = new System.Drawing.Point(626, 279);
			this.ButtonAbort.Margin = new System.Windows.Forms.Padding(6);
			this.ButtonAbort.Name = "ButtonAbort";
			this.ButtonAbort.Size = new System.Drawing.Size(240, 44);
			this.ButtonAbort.TabIndex = 2;
			this.ButtonAbort.Text = "Abort";
			this.ButtonAbort.UseVisualStyleBackColor = true;
			this.ButtonAbort.Click += new System.EventHandler(this.ButtonAbort_Click);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(620, 23);
			this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 25);
			this.label1.TabIndex = 3;
			this.label1.Text = "Start Point";
			// 
			// NumericStart
			// 
			this.NumericStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NumericStart.Location = new System.Drawing.Point(626, 54);
			this.NumericStart.Margin = new System.Windows.Forms.Padding(6);
			this.NumericStart.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumericStart.Name = "NumericStart";
			this.NumericStart.Size = new System.Drawing.Size(240, 31);
			this.NumericStart.TabIndex = 4;
			this.NumericStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(626, 108);
			this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(159, 25);
			this.label2.TabIndex = 5;
			this.label2.Text = "Count of Points";
			// 
			// NumericCount
			// 
			this.NumericCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.NumericCount.Location = new System.Drawing.Point(626, 140);
			this.NumericCount.Margin = new System.Windows.Forms.Padding(6);
			this.NumericCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.NumericCount.Name = "NumericCount";
			this.NumericCount.Size = new System.Drawing.Size(240, 31);
			this.NumericCount.TabIndex = 6;
			this.NumericCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// ButtonClearResult
			// 
			this.ButtonClearResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonClearResult.Location = new System.Drawing.Point(626, 376);
			this.ButtonClearResult.Margin = new System.Windows.Forms.Padding(6);
			this.ButtonClearResult.Name = "ButtonClearResult";
			this.ButtonClearResult.Size = new System.Drawing.Size(240, 44);
			this.ButtonClearResult.TabIndex = 7;
			this.ButtonClearResult.Text = "Clear Result";
			this.ButtonClearResult.UseVisualStyleBackColor = true;
			this.ButtonClearResult.Click += new System.EventHandler(this.ButtonClearResult_Click);
			// 
			// FormHabrParser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(912, 881);
			this.Controls.Add(this.ButtonClearResult);
			this.Controls.Add(this.NumericCount);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.NumericStart);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ButtonAbort);
			this.Controls.Add(this.ButtonStart);
			this.Controls.Add(this.ListTitles);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(6);
			this.Name = "FormHabrParser";
			this.Text = "HabrParser";
			((System.ComponentModel.ISupportInitialize)(this.NumericStart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.NumericCount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox ListTitles;
		private System.Windows.Forms.Button ButtonStart;
		private System.Windows.Forms.Button ButtonAbort;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown NumericStart;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown NumericCount;
		private System.Windows.Forms.Button ButtonClearResult;
	}
}

