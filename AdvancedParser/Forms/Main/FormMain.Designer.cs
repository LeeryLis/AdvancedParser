namespace AdvancedParser.Forms.Main
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.ListParsers = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// ListParsers
			// 
			this.ListParsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.ListParsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.ListParsers.FormattingEnabled = true;
			this.ListParsers.ItemHeight = 25;
			this.ListParsers.Location = new System.Drawing.Point(24, 23);
			this.ListParsers.Margin = new System.Windows.Forms.Padding(7);
			this.ListParsers.Name = "ListParsers";
			this.ListParsers.Size = new System.Drawing.Size(397, 554);
			this.ListParsers.TabIndex = 0;
			this.ListParsers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListParsers_MouseDoubleClick);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(450, 619);
			this.Controls.Add(this.ListParsers);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.Margin = new System.Windows.Forms.Padding(7);
			this.Name = "FormMain";
			this.Text = "Main";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox ListParsers;
	}
}