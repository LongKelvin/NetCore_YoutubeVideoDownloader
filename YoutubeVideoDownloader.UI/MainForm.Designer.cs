namespace YoutubeVideoDownloader.UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.fLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lbAppTitle = new System.Windows.Forms.Label();
            this.btnSetDownloadLocation = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.SpinWheelProgressBar = new System.Windows.Forms.ProgressBar();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnGetVideos = new System.Windows.Forms.Button();
            this.textVideoUrl = new System.Windows.Forms.TextBox();
            this.lbUrlText = new System.Windows.Forms.Label();
            this.fLayoutPanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fLayoutPanel
            // 
            this.fLayoutPanel.BackColor = System.Drawing.Color.Silver;
            this.fLayoutPanel.Controls.Add(this.lbAppTitle);
            this.fLayoutPanel.Controls.Add(this.btnSetDownloadLocation);
            this.fLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.fLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.fLayoutPanel.Name = "fLayoutPanel";
            this.fLayoutPanel.Size = new System.Drawing.Size(1053, 27);
            this.fLayoutPanel.TabIndex = 0;
            // 
            // lbAppTitle
            // 
            this.lbAppTitle.AllowDrop = true;
            this.lbAppTitle.AutoSize = true;
            this.lbAppTitle.BackColor = System.Drawing.Color.White;
            this.lbAppTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbAppTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbAppTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbAppTitle.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            this.lbAppTitle.Location = new System.Drawing.Point(3, 0);
            this.lbAppTitle.Name = "lbAppTitle";
            this.lbAppTitle.Size = new System.Drawing.Size(323, 23);
            this.lbAppTitle.TabIndex = 0;
            this.lbAppTitle.Text = "Youtube Video Downloader Version 1.0.0";
            // 
            // btnSetDownloadLocation
            // 
            this.btnSetDownloadLocation.BackColor = System.Drawing.Color.Cornsilk;
            this.btnSetDownloadLocation.Image = ((System.Drawing.Image)(resources.GetObject("btnSetDownloadLocation.Image")));
            this.btnSetDownloadLocation.Location = new System.Drawing.Point(332, 3);
            this.btnSetDownloadLocation.Name = "btnSetDownloadLocation";
            this.btnSetDownloadLocation.Size = new System.Drawing.Size(47, 23);
            this.btnSetDownloadLocation.TabIndex = 1;
            this.btnSetDownloadLocation.UseVisualStyleBackColor = false;
            this.btnSetDownloadLocation.Click += new System.EventHandler(this.btnSetDownloadLocation_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mainPanel.Controls.Add(this.SpinWheelProgressBar);
            this.mainPanel.Controls.Add(this.btnDownload);
            this.mainPanel.Controls.Add(this.btnGetVideos);
            this.mainPanel.Controls.Add(this.textVideoUrl);
            this.mainPanel.Controls.Add(this.lbUrlText);
            this.mainPanel.Location = new System.Drawing.Point(0, 26);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1049, 116);
            this.mainPanel.TabIndex = 1;
            // 
            // SpinWheelProgressBar
            // 
            this.SpinWheelProgressBar.BackColor = System.Drawing.Color.White;
            this.SpinWheelProgressBar.ForeColor = System.Drawing.Color.GreenYellow;
            this.SpinWheelProgressBar.Location = new System.Drawing.Point(94, 80);
            this.SpinWheelProgressBar.Name = "SpinWheelProgressBar";
            this.SpinWheelProgressBar.Size = new System.Drawing.Size(648, 23);
            this.SpinWheelProgressBar.TabIndex = 5;
            this.SpinWheelProgressBar.Visible = false;
            // 
            // btnDownload
            // 
            this.btnDownload.AutoSize = true;
            this.btnDownload.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnDownload.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDownload.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDownload.Location = new System.Drawing.Point(890, 46);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(96, 30);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = false;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnGetVideos
            // 
            this.btnGetVideos.AutoSize = true;
            this.btnGetVideos.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGetVideos.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGetVideos.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGetVideos.Location = new System.Drawing.Point(748, 46);
            this.btnGetVideos.Name = "btnGetVideos";
            this.btnGetVideos.Size = new System.Drawing.Size(136, 30);
            this.btnGetVideos.TabIndex = 3;
            this.btnGetVideos.Text = "Get Videos Info";
            this.btnGetVideos.UseVisualStyleBackColor = false;
            this.btnGetVideos.Click += new System.EventHandler(this.btnGetVideos_Click);
            // 
            // textVideoUrl
            // 
            this.textVideoUrl.Location = new System.Drawing.Point(93, 51);
            this.textVideoUrl.Name = "textVideoUrl";
            this.textVideoUrl.Size = new System.Drawing.Size(649, 23);
            this.textVideoUrl.TabIndex = 1;
            // 
            // lbUrlText
            // 
            this.lbUrlText.AutoSize = true;
            this.lbUrlText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbUrlText.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbUrlText.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Assertive;
            this.lbUrlText.Location = new System.Drawing.Point(3, 51);
            this.lbUrlText.Name = "lbUrlText";
            this.lbUrlText.Size = new System.Drawing.Size(84, 20);
            this.lbUrlText.TabIndex = 0;
            this.lbUrlText.Text = "Video Url:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 139);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.fLayoutPanel);
            this.Name = "MainForm";
            this.Text = "Youtube Video Downloader";
           
            this.fLayoutPanel.ResumeLayout(false);
            this.fLayoutPanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel fLayoutPanel;
        public Label lbAppTitle;
        private Panel mainPanel;
        private Label lbUrlText;
        public TextBox textVideoUrl;
        private Button btnGetVideos;
        private Panel panelVideoList;
        private Button btnDownload;
        private Button btnSetDownloadLocation;
        private ProgressBar SpinWheelProgressBar;
    }
}