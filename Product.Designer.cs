namespace ProductCatalog
{
    partial class Product
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            nameLabel = new Label();
            priceLabel = new Label();
            buyButton = new Button();
            toCartButton = new Button();
            idLabel = new Label();
            countLabel = new Label();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(13, 12);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(59, 15);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Название";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(299, 41);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(35, 15);
            priceLabel.TabIndex = 1;
            priceLabel.Text = "Цена";
            // 
            // buyButton
            // 
            buyButton.Location = new Point(414, 8);
            buyButton.Margin = new Padding(3, 2, 3, 2);
            buyButton.Name = "buyButton";
            buyButton.Size = new Size(82, 22);
            buyButton.TabIndex = 2;
            buyButton.Text = "Купить";
            buyButton.UseVisualStyleBackColor = true;
            // 
            // toCartButton
            // 
            toCartButton.Location = new Point(414, 34);
            toCartButton.Margin = new Padding(3, 2, 3, 2);
            toCartButton.Name = "toCartButton";
            toCartButton.Size = new Size(82, 22);
            toCartButton.TabIndex = 3;
            toCartButton.Text = "В корзину";
            toCartButton.UseVisualStyleBackColor = true;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(299, 15);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(17, 15);
            idLabel.TabIndex = 4;
            idLabel.Text = "id";
            // 
            // countLabel
            // 
            countLabel.AutoSize = true;
            countLabel.Location = new Point(13, 38);
            countLabel.Name = "countLabel";
            countLabel.Size = new Size(49, 15);
            countLabel.TabIndex = 5;
            countLabel.Text = "Кол-во:";
            // 
            // Product
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(countLabel);
            Controls.Add(idLabel);
            Controls.Add(toCartButton);
            Controls.Add(buyButton);
            Controls.Add(priceLabel);
            Controls.Add(nameLabel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Product";
            Size = new Size(500, 65);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private Label priceLabel;
        private Button buyButton;
        private Button toCartButton;
        private Label idLabel;
        private Label countLabel;
    }
}
