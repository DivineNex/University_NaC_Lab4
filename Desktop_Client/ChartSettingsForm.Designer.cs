﻿namespace Desktop_Client
{
    partial class ChartSettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAddSerie = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonAcceptEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название";
            // 
            // buttonAddSerie
            // 
            this.buttonAddSerie.Location = new System.Drawing.Point(16, 86);
            this.buttonAddSerie.Name = "buttonAddSerie";
            this.buttonAddSerie.Size = new System.Drawing.Size(75, 23);
            this.buttonAddSerie.TabIndex = 1;
            this.buttonAddSerie.Text = "Добавить";
            this.buttonAddSerie.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Серии";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(16, 115);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 252);
            this.panel1.TabIndex = 4;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(222, 12);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonEdit.TabIndex = 5;
            this.buttonEdit.Text = "EditButton";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(16, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(109, 29);
            this.textBox1.TabIndex = 6;
            this.textBox1.Visible = false;
            // 
            // buttonAcceptEdit
            // 
            this.buttonAcceptEdit.Location = new System.Drawing.Point(222, 41);
            this.buttonAcceptEdit.Name = "buttonAcceptEdit";
            this.buttonAcceptEdit.Size = new System.Drawing.Size(75, 23);
            this.buttonAcceptEdit.TabIndex = 7;
            this.buttonAcceptEdit.Text = "AcceptEditButton";
            this.buttonAcceptEdit.UseVisualStyleBackColor = true;
            // 
            // ChartSettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 379);
            this.Controls.Add(this.buttonAcceptEdit);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonAddSerie);
            this.Controls.Add(this.label1);
            this.Name = "ChartSettingsForm";
            this.Text = "Настройки графика";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddSerie;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonAcceptEdit;
    }
}