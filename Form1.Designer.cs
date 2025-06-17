namespace WhoTmIsConflict
{
    partial class WhoTmConflict
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WhoTmConflict));
            this.importVanillaTextButton = new System.Windows.Forms.Button();
            this.importModTextButton = new System.Windows.Forms.Button();
            this.compareTextButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // importVanillaTextButton
            // 
            this.importVanillaTextButton.Font = new System.Drawing.Font("宋体", 9F);
            this.importVanillaTextButton.Location = new System.Drawing.Point(155, 229);
            this.importVanillaTextButton.Name = "importVanillaTextButton";
            this.importVanillaTextButton.Size = new System.Drawing.Size(212, 100);
            this.importVanillaTextButton.TabIndex = 0;
            this.importVanillaTextButton.Text = "导入原版文本";
            this.importVanillaTextButton.UseVisualStyleBackColor = true;
            this.importVanillaTextButton.Click += new System.EventHandler(this.importVanillaTextButton_Click);
            // 
            // importModTextButton
            // 
            this.importModTextButton.Font = new System.Drawing.Font("宋体", 9F);
            this.importModTextButton.Location = new System.Drawing.Point(434, 229);
            this.importModTextButton.Name = "importModTextButton";
            this.importModTextButton.Size = new System.Drawing.Size(212, 100);
            this.importModTextButton.TabIndex = 1;
            this.importModTextButton.Text = "导入Mod文本";
            this.importModTextButton.UseVisualStyleBackColor = true;
            this.importModTextButton.Click += new System.EventHandler(this.importModTextButton_Click);
            // 
            // compareTextButton
            // 
            this.compareTextButton.Font = new System.Drawing.Font("宋体", 9F);
            this.compareTextButton.Location = new System.Drawing.Point(703, 229);
            this.compareTextButton.Name = "compareTextButton";
            this.compareTextButton.Size = new System.Drawing.Size(212, 100);
            this.compareTextButton.TabIndex = 2;
            this.compareTextButton.Text = "比对";
            this.compareTextButton.UseVisualStyleBackColor = true;
            this.compareTextButton.Click += new System.EventHandler(this.compareTextButton_Click);
            // 
            // WhoTmConflict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 577);
            this.Controls.Add(this.compareTextButton);
            this.Controls.Add(this.importModTextButton);
            this.Controls.Add(this.importVanillaTextButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WhoTmConflict";
            this.Text = "让我看看谁冲突了";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button importVanillaTextButton;
        private System.Windows.Forms.Button importModTextButton;
        private System.Windows.Forms.Button compareTextButton;
    }
}

