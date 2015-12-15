namespace CraigslistTools
{
    partial class Test
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
            this.geckoWebBrowser1 = new Gecko.GeckoWebBrowser();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnclearcookie = new System.Windows.Forms.Button();
            this.tbURL = new System.Windows.Forms.TextBox();
            this.btnuseragent = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSpam = new System.Windows.Forms.Button();
            this.btnChangeProxy = new System.Windows.Forms.Button();
            this.btnproxy2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // geckoWebBrowser1
            // 
            this.geckoWebBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.geckoWebBrowser1.Location = new System.Drawing.Point(0, 42);
            this.geckoWebBrowser1.Name = "geckoWebBrowser1";
            this.geckoWebBrowser1.Size = new System.Drawing.Size(754, 375);
            this.geckoWebBrowser1.TabIndex = 0;
            this.geckoWebBrowser1.UseHttpActivityObserver = false;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(667, 12);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnclearcookie
            // 
            this.btnclearcookie.Location = new System.Drawing.Point(12, 12);
            this.btnclearcookie.Name = "btnclearcookie";
            this.btnclearcookie.Size = new System.Drawing.Size(75, 23);
            this.btnclearcookie.TabIndex = 2;
            this.btnclearcookie.Text = "clear cookie";
            this.btnclearcookie.UseVisualStyleBackColor = true;
            this.btnclearcookie.Click += new System.EventHandler(this.btnclearcookie_Click);
            // 
            // tbURL
            // 
            this.tbURL.Location = new System.Drawing.Point(469, 12);
            this.tbURL.Name = "tbURL";
            this.tbURL.Size = new System.Drawing.Size(192, 20);
            this.tbURL.TabIndex = 3;
            this.tbURL.Text = "http://whatismyipaddress.com/";
            // 
            // btnuseragent
            // 
            this.btnuseragent.Location = new System.Drawing.Point(93, 13);
            this.btnuseragent.Name = "btnuseragent";
            this.btnuseragent.Size = new System.Drawing.Size(75, 23);
            this.btnuseragent.TabIndex = 2;
            this.btnuseragent.Text = "User agent";
            this.btnuseragent.UseVisualStyleBackColor = true;
            this.btnuseragent.Click += new System.EventHandler(this.btnuseragent_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(174, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnSpam
            // 
            this.btnSpam.Location = new System.Drawing.Point(255, 12);
            this.btnSpam.Name = "btnSpam";
            this.btnSpam.Size = new System.Drawing.Size(75, 23);
            this.btnSpam.TabIndex = 5;
            this.btnSpam.Text = "Click Spam";
            this.btnSpam.UseVisualStyleBackColor = true;
            this.btnSpam.Click += new System.EventHandler(this.btnSpam_Click);
            // 
            // btnChangeProxy
            // 
            this.btnChangeProxy.Location = new System.Drawing.Point(336, 13);
            this.btnChangeProxy.Name = "btnChangeProxy";
            this.btnChangeProxy.Size = new System.Drawing.Size(57, 23);
            this.btnChangeProxy.TabIndex = 5;
            this.btnChangeProxy.Text = "proxy1";
            this.btnChangeProxy.UseVisualStyleBackColor = true;
            this.btnChangeProxy.Click += new System.EventHandler(this.btnChangeProxy_Click);
            // 
            // btnproxy2
            // 
            this.btnproxy2.Location = new System.Drawing.Point(399, 13);
            this.btnproxy2.Name = "btnproxy2";
            this.btnproxy2.Size = new System.Drawing.Size(57, 23);
            this.btnproxy2.TabIndex = 5;
            this.btnproxy2.Text = "proxy";
            this.btnproxy2.UseVisualStyleBackColor = true;
            this.btnproxy2.Click += new System.EventHandler(this.btnproxy2_Click);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 417);
            this.Controls.Add(this.btnproxy2);
            this.Controls.Add(this.btnChangeProxy);
            this.Controls.Add(this.btnSpam);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbURL);
            this.Controls.Add(this.btnuseragent);
            this.Controls.Add(this.btnclearcookie);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.geckoWebBrowser1);
            this.Name = "Test";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Gecko.GeckoWebBrowser geckoWebBrowser1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnclearcookie;
        private System.Windows.Forms.TextBox tbURL;
        private System.Windows.Forms.Button btnuseragent;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSpam;
        private System.Windows.Forms.Button btnChangeProxy;
        private System.Windows.Forms.Button btnproxy2;
    }
}