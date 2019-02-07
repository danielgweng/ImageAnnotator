namespace ImageAnnotator
{
    partial class FormImageAnnotator
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormImageAnnotator));
            this.chartAnnotate = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonSaveCloud = new System.Windows.Forms.Button();
            this.labelImageDragDrop = new System.Windows.Forms.Label();
            this.labelEllipse = new System.Windows.Forms.Label();
            this.labelSquare = new System.Windows.Forms.Label();
            this.buttonRectangle = new System.Windows.Forms.Button();
            this.buttonCircle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnnotate)).BeginInit();
            this.SuspendLayout();
            // 
            // chartAnnotate
            // 
            this.chartAnnotate.AllowDrop = true;
            chartArea1.Name = "ChartArea1";
            this.chartAnnotate.ChartAreas.Add(chartArea1);
            this.chartAnnotate.Location = new System.Drawing.Point(12, 62);
            this.chartAnnotate.Name = "chartAnnotate";
            series1.ChartArea = "ChartArea1";
            series1.Name = "Series1";
            this.chartAnnotate.Series.Add(series1);
            this.chartAnnotate.Size = new System.Drawing.Size(604, 550);
            this.chartAnnotate.TabIndex = 0;
            this.chartAnnotate.Text = "chartAnnotate";
            this.chartAnnotate.DragDrop += new System.Windows.Forms.DragEventHandler(this.chartAnnotate_DragDrop);
            this.chartAnnotate.DragEnter += new System.Windows.Forms.DragEventHandler(this.chartAnnotate_DragEnter);
            this.chartAnnotate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseDown);
            this.chartAnnotate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseMove);
            this.chartAnnotate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCanvas_MouseUp);
            // 
            // buttonSaveCloud
            // 
            this.buttonSaveCloud.BackColor = System.Drawing.Color.White;
            this.buttonSaveCloud.BackgroundImage = global::ImageAnnotator.Properties.Resources.download;
            this.buttonSaveCloud.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSaveCloud.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSaveCloud.FlatAppearance.BorderSize = 0;
            this.buttonSaveCloud.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveCloud.Location = new System.Drawing.Point(622, 472);
            this.buttonSaveCloud.Name = "buttonSaveCloud";
            this.buttonSaveCloud.Size = new System.Drawing.Size(118, 104);
            this.buttonSaveCloud.TabIndex = 3;
            this.buttonSaveCloud.UseVisualStyleBackColor = false;
            this.buttonSaveCloud.Click += new System.EventHandler(this.buttonSaveCloud_Click);
            // 
            // labelImageDragDrop
            // 
            this.labelImageDragDrop.AutoSize = true;
            this.labelImageDragDrop.Location = new System.Drawing.Point(23, 36);
            this.labelImageDragDrop.Name = "labelImageDragDrop";
            this.labelImageDragDrop.Size = new System.Drawing.Size(203, 20);
            this.labelImageDragDrop.TabIndex = 4;
            this.labelImageDragDrop.Text = "Drag and drop image below";
            // 
            // labelEllipse
            // 
            this.labelEllipse.AutoSize = true;
            this.labelEllipse.Location = new System.Drawing.Point(651, 193);
            this.labelEllipse.Name = "labelEllipse";
            this.labelEllipse.Size = new System.Drawing.Size(55, 20);
            this.labelEllipse.TabIndex = 5;
            this.labelEllipse.Text = "Ellipse";
            // 
            // labelSquare
            // 
            this.labelSquare.AutoSize = true;
            this.labelSquare.Location = new System.Drawing.Point(651, 340);
            this.labelSquare.Name = "labelSquare";
            this.labelSquare.Size = new System.Drawing.Size(61, 20);
            this.labelSquare.TabIndex = 6;
            this.labelSquare.Text = "Square";
            // 
            // buttonRectangle
            // 
            this.buttonRectangle.BackColor = System.Drawing.Color.White;
            this.buttonRectangle.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRectangle.BackgroundImage")));
            this.buttonRectangle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRectangle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonRectangle.FlatAppearance.BorderSize = 0;
            this.buttonRectangle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRectangle.Location = new System.Drawing.Point(636, 239);
            this.buttonRectangle.Name = "buttonRectangle";
            this.buttonRectangle.Size = new System.Drawing.Size(85, 85);
            this.buttonRectangle.TabIndex = 2;
            this.buttonRectangle.UseVisualStyleBackColor = false;
            this.buttonRectangle.Click += new System.EventHandler(this.buttonRectangle_Click);
            // 
            // buttonCircle
            // 
            this.buttonCircle.BackColor = System.Drawing.Color.White;
            this.buttonCircle.BackgroundImage = global::ImageAnnotator.Properties.Resources.Cirklo_svg;
            this.buttonCircle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCircle.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCircle.FlatAppearance.BorderSize = 0;
            this.buttonCircle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCircle.Location = new System.Drawing.Point(636, 92);
            this.buttonCircle.Name = "buttonCircle";
            this.buttonCircle.Size = new System.Drawing.Size(85, 85);
            this.buttonCircle.TabIndex = 1;
            this.buttonCircle.UseVisualStyleBackColor = false;
            this.buttonCircle.Click += new System.EventHandler(this.buttonCircle_Click);
            // 
            // FormImageAnnotator
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(760, 649);
            this.Controls.Add(this.labelSquare);
            this.Controls.Add(this.labelEllipse);
            this.Controls.Add(this.labelImageDragDrop);
            this.Controls.Add(this.buttonSaveCloud);
            this.Controls.Add(this.buttonRectangle);
            this.Controls.Add(this.buttonCircle);
            this.Controls.Add(this.chartAnnotate);
            this.Name = "FormImageAnnotator";
            this.Text = "Image Annotator";
            this.Load += new System.EventHandler(this.FormImageAnnotator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartAnnotate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartAnnotate;
        private System.Windows.Forms.Button buttonCircle;
        private System.Windows.Forms.Button buttonRectangle;
        private System.Windows.Forms.Button buttonSaveCloud;
        private System.Windows.Forms.Label labelImageDragDrop;
        private System.Windows.Forms.Label labelEllipse;
        private System.Windows.Forms.Label labelSquare;
    }
}

