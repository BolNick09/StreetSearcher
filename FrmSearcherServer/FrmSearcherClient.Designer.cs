namespace FrmSearcherServer
{
    partial class FrmSearcherClient
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
            label1 = new Label();
            tbIndex = new TextBox();
            label2 = new Label();
            btnSearch = new Button();
            rtbStreets = new RichTextBox();
            tbIp = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(80, 40);
            label1.TabIndex = 0;
            label1.Text = "Почтовый\r\nиндекс:\r\n";
            // 
            // tbIndex
            // 
            tbIndex.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbIndex.Location = new Point(98, 22);
            tbIndex.Name = "tbIndex";
            tbIndex.Size = new Size(125, 27);
            tbIndex.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 84);
            label2.Name = "label2";
            label2.Size = new Size(63, 40);
            label2.TabIndex = 2;
            label2.Text = "Список \r\nулиц:";
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.Location = new Point(229, 22);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(71, 27);
            btnSearch.TabIndex = 4;
            btnSearch.Text = "Найти";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // rtbStreets
            // 
            rtbStreets.Location = new Point(98, 88);
            rtbStreets.Name = "rtbStreets";
            rtbStreets.Size = new Size(202, 228);
            rtbStreets.TabIndex = 5;
            rtbStreets.Text = "";
            // 
            // tbIp
            // 
            tbIp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbIp.Location = new Point(98, 55);
            tbIp.Name = "tbIp";
            tbIp.Size = new Size(202, 27);
            tbIp.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 58);
            label3.Name = "label3";
            label3.Size = new Size(69, 20);
            label3.TabIndex = 7;
            label3.Text = "Ip адрес:\r\n";
            // 
            // FrmSearcherClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 328);
            Controls.Add(label3);
            Controls.Add(tbIp);
            Controls.Add(rtbStreets);
            Controls.Add(btnSearch);
            Controls.Add(label2);
            Controls.Add(tbIndex);
            Controls.Add(label1);
            Name = "FrmSearcherClient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Поиск улиц";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbIndex;
        private Label label2;
        private Button btnSearch;
        private RichTextBox rtbStreets;
        private TextBox tbIp;
        private Label label3;
    }
}
