namespace dblogin
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.btndonor = new System.Windows.Forms.Button();
            this.btnreceiver = new System.Windows.Forms.Button();
            this.btnblood = new System.Windows.Forms.Button();
            this.btnscreening = new System.Windows.Forms.Button();
            this.btndrive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btndonor
            // 
            this.btndonor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btndonor.BackgroundImage")));
            this.btndonor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btndonor.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndonor.Location = new System.Drawing.Point(343, 47);
            this.btndonor.Name = "btndonor";
            this.btndonor.Size = new System.Drawing.Size(216, 172);
            this.btndonor.TabIndex = 0;
            this.btndonor.Text = "DONOR";
            this.btndonor.UseVisualStyleBackColor = true;
            this.btndonor.Click += new System.EventHandler(this.btndonor_Click);
            // 
            // btnreceiver
            // 
            this.btnreceiver.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnreceiver.BackgroundImage")));
            this.btnreceiver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnreceiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreceiver.Location = new System.Drawing.Point(568, 230);
            this.btnreceiver.Name = "btnreceiver";
            this.btnreceiver.Size = new System.Drawing.Size(225, 197);
            this.btnreceiver.TabIndex = 1;
            this.btnreceiver.Text = "RECEIVER";
            this.btnreceiver.UseVisualStyleBackColor = true;
            this.btnreceiver.Click += new System.EventHandler(this.btnreceiver_Click);
            // 
            // btnblood
            // 
            this.btnblood.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnblood.BackgroundImage")));
            this.btnblood.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnblood.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnblood.Location = new System.Drawing.Point(804, 41);
            this.btnblood.Name = "btnblood";
            this.btnblood.Size = new System.Drawing.Size(204, 178);
            this.btnblood.TabIndex = 2;
            this.btnblood.Text = "BLOOD";
            this.btnblood.UseVisualStyleBackColor = true;
            this.btnblood.Click += new System.EventHandler(this.btnblood_Click);
            // 
            // btnscreening
            // 
            this.btnscreening.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnscreening.BackgroundImage")));
            this.btnscreening.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnscreening.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnscreening.Location = new System.Drawing.Point(804, 434);
            this.btnscreening.Name = "btnscreening";
            this.btnscreening.Size = new System.Drawing.Size(215, 190);
            this.btnscreening.TabIndex = 3;
            this.btnscreening.Text = "SCREENING";
            this.btnscreening.UseVisualStyleBackColor = true;
            this.btnscreening.Click += new System.EventHandler(this.btnscreening_Click);
            // 
            // btndrive
            // 
            this.btndrive.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btndrive.BackgroundImage")));
            this.btndrive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btndrive.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndrive.Location = new System.Drawing.Point(337, 434);
            this.btndrive.Name = "btndrive";
            this.btndrive.Size = new System.Drawing.Size(222, 190);
            this.btndrive.TabIndex = 4;
            this.btndrive.Text = "DRIVE";
            this.btndrive.UseVisualStyleBackColor = true;
            this.btndrive.Click += new System.EventHandler(this.btndrive_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1304, 674);
            this.Controls.Add(this.btndrive);
            this.Controls.Add(this.btnscreening);
            this.Controls.Add(this.btnblood);
            this.Controls.Add(this.btnreceiver);
            this.Controls.Add(this.btndonor);
            this.Name = "Home";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btndonor;
        private System.Windows.Forms.Button btnreceiver;
        private System.Windows.Forms.Button btnblood;
        private System.Windows.Forms.Button btnscreening;
        private System.Windows.Forms.Button btndrive;
    }
}