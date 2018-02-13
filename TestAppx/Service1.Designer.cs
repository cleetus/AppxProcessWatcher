namespace TestAppx
{
    partial class TestAppx
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TestAppxTimer = new System.Windows.Forms.Timer(this.components);
            // 
            // TestAppxTimer
            // 
            this.TestAppxTimer.Enabled = true;
            this.TestAppxTimer.Interval = 1000;
            this.TestAppxTimer.Tick += new System.EventHandler(this.TestAppxTimer_Tick);
            // 
            // TestAppx
            // 
            this.CanPauseAndContinue = true;
            this.ServiceName = "TestAppxService";

        }

        #endregion

        public System.Windows.Forms.Timer TestAppxTimer;
    }
}
