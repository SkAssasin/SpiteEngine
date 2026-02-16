using System.ComponentModel;

namespace SpiteEngine
{
    partial class Form1
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
            components = new Container();
            GameLoopTimer = new System.Windows.Forms.Timer(components);
            backgroundWorker1 = new BackgroundWorker();
            SuspendLayout();
            // 
            // GameLoopTimer
            // 
            GameLoopTimer.Enabled = true;
            GameLoopTimer.Interval = 20;
            GameLoopTimer.Tick += UpdateLoop;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            ClientSize = new Size(800, 450);
            Name = "Form1";
            Text = "Form1";
            KeyDown += KeyPressed;
            KeyUp += KeyReleased;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer GameLoopTimer;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
