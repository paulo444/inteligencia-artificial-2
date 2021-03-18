/*
 * Created by SharpDevelop.
 * User: paulo
 * Date: 02/03/2021
 * Time: 04:14 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Practica_1___IA_2
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.graphicImage = new System.Windows.Forms.PictureBox();
			this.startPerceptron = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.epochNumber = new System.Windows.Forms.Label();
			this.InitializeValues = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.V_Esperado = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.graphicImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(192, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(217, 44);
			this.label1.TabIndex = 0;
			this.label1.Text = "Práctica 2 - IA2";
			// 
			// graphicImage
			// 
			this.graphicImage.Location = new System.Drawing.Point(80, 56);
			this.graphicImage.Name = "graphicImage";
			this.graphicImage.Size = new System.Drawing.Size(400, 400);
			this.graphicImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.graphicImage.TabIndex = 1;
			this.graphicImage.TabStop = false;
			// 
			// startPerceptron
			// 
			this.startPerceptron.Location = new System.Drawing.Point(218, 462);
			this.startPerceptron.Name = "startPerceptron";
			this.startPerceptron.Size = new System.Drawing.Size(98, 23);
			this.startPerceptron.TabIndex = 2;
			this.startPerceptron.Text = "Adaline";
			this.startPerceptron.UseVisualStyleBackColor = true;
			this.startPerceptron.Click += new System.EventHandler(this.StartPerceptronClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(636, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "M:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(734, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(116, 22);
			this.textBox1.TabIndex = 4;
			this.textBox1.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(734, 40);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(116, 22);
			this.textBox2.TabIndex = 6;
			this.textBox2.TextChanged += new System.EventHandler(this.TextBox2TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(636, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "#Epochmax:";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(668, 189);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(127, 23);
			this.label4.TabIndex = 7;
			this.label4.Text = "Resultados";
			// 
			// epochNumber
			// 
			this.epochNumber.Location = new System.Drawing.Point(611, 223);
			this.epochNumber.Name = "epochNumber";
			this.epochNumber.Size = new System.Drawing.Size(143, 23);
			this.epochNumber.TabIndex = 8;
			this.epochNumber.Text = "#Epochs: ";
			// 
			// InitializeValues
			// 
			this.InitializeValues.Location = new System.Drawing.Point(653, 133);
			this.InitializeValues.Name = "InitializeValues";
			this.InitializeValues.Size = new System.Drawing.Size(75, 23);
			this.InitializeValues.TabIndex = 10;
			this.InitializeValues.Text = "Inicializa";
			this.InitializeValues.UseVisualStyleBackColor = true;
			this.InitializeValues.Click += new System.EventHandler(this.InitializeValuesClick);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(734, 107);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(116, 23);
			this.label5.TabIndex = 11;
			this.label5.Text = "W0: ";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(734, 132);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(116, 23);
			this.label6.TabIndex = 12;
			this.label6.Text = "W1: ";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(734, 156);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(116, 23);
			this.label7.TabIndex = 13;
			this.label7.Text = "W2: ";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(80, 56);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(400, 400);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 14;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.PictureBox1Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Column2,
									this.V_Esperado,
									this.Column1});
			this.dataGridView1.Location = new System.Drawing.Point(586, 261);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(293, 150);
			this.dataGridView1.TabIndex = 15;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Valor";
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			this.Column2.Width = 50;
			// 
			// V_Esperado
			// 
			this.V_Esperado.HeaderText = "V Esperado";
			this.V_Esperado.Name = "V_Esperado";
			this.V_Esperado.ReadOnly = true;
			// 
			// Column1
			// 
			this.Column1.HeaderText = "F Esperado";
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(734, 68);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(116, 22);
			this.textBox3.TabIndex = 17;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(636, 68);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(92, 23);
			this.label8.TabIndex = 16;
			this.label8.Text = "E. Deseado:";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(627, 433);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(181, 23);
			this.label9.TabIndex = 18;
			this.label9.Text = "Error Acumulado";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(514, 462);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(365, 138);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 19;
			this.pictureBox2.TabStop = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(906, 612);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.InitializeValues);
			this.Controls.Add(this.epochNumber);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.startPerceptron);
			this.Controls.Add(this.graphicImage);
			this.Controls.Add(this.label1);
			this.Name = "MainForm";
			this.Text = "Practica 1 - IA 2";
			((System.ComponentModel.ISupportInitialize)(this.graphicImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn V_Esperado;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button InitializeValues;
		private System.Windows.Forms.Label epochNumber;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button startPerceptron;
		private System.Windows.Forms.PictureBox graphicImage;
		private System.Windows.Forms.Label label1;
	}
}
