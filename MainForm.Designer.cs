namespace ProductCatalog
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
            productsFLP = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // productsFLP
            // 
            productsFLP.AutoScroll = true;
            productsFLP.BorderStyle = BorderStyle.FixedSingle;
            productsFLP.Location = new Point(12, 219);
            productsFLP.Name = "productsFLP";
            productsFLP.Size = new Size(560, 219);
            productsFLP.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 450);
            Controls.Add(productsFLP);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel productsFLP;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
