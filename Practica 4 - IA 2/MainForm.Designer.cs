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
			this.startAdaline = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.textBoxClasses = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.comboBoxClasses = new System.Windows.Forms.ComboBox();
			this.buttonClasses = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.buttonArquitecture = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.textBoxArquitecture = new System.Windows.Forms.TextBox();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.Capa = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Neuronas = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.buttonCreateArquitecture = new System.Windows.Forms.Button();
			this.labelEpochs = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.labelError = new System.Windows.Forms.Label();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.graphicImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(192, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(217, 44);
			this.label1.TabIndex = 0;
			this.label1.Text = "Práctica 4 - IA2";
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
			// startAdaline
			// 
			this.startAdaline.Location = new System.Drawing.Point(218, 462);
			this.startAdaline.Name = "startAdaline";
			this.startAdaline.Size = new System.Drawing.Size(98, 23);
			this.startAdaline.TabIndex = 2;
			this.startAdaline.Text = "MLP";
			this.startAdaline.UseVisualStyleBackColor = true;
			this.startAdaline.Click += new System.EventHandler(this.StartMLPClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(556, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "M:";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(654, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(116, 22);
			this.textBox1.TabIndex = 4;
			this.textBox1.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(654, 40);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(116, 22);
			this.textBox2.TabIndex = 6;
			this.textBox2.TextChanged += new System.EventHandler(this.TextBox2TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(556, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(92, 23);
			this.label3.TabIndex = 5;
			this.label3.Text = "#Epochmax:";
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
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(654, 68);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(116, 22);
			this.textBox3.TabIndex = 17;
			this.textBox3.TextChanged += new System.EventHandler(this.TextBox3TextChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(556, 68);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(92, 23);
			this.label8.TabIndex = 16;
			this.label8.Text = "E. Deseado:";
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(199, 510);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(181, 23);
			this.label9.TabIndex = 18;
			this.label9.Text = "Error Acumulado";
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(97, 539);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(365, 138);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 19;
			this.pictureBox2.TabStop = false;
			// 
			// textBoxClasses
			// 
			this.textBoxClasses.Location = new System.Drawing.Point(654, 161);
			this.textBoxClasses.Name = "textBoxClasses";
			this.textBoxClasses.Size = new System.Drawing.Size(116, 22);
			this.textBoxClasses.TabIndex = 23;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(556, 164);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(82, 23);
			this.label12.TabIndex = 24;
			this.label12.Text = "N. Clases:";
			// 
			// comboBoxClasses
			// 
			this.comboBoxClasses.FormattingEnabled = true;
			this.comboBoxClasses.Location = new System.Drawing.Point(595, 226);
			this.comboBoxClasses.Name = "comboBoxClasses";
			this.comboBoxClasses.Size = new System.Drawing.Size(121, 24);
			this.comboBoxClasses.TabIndex = 25;
			// 
			// buttonClasses
			// 
			this.buttonClasses.Location = new System.Drawing.Point(608, 190);
			this.buttonClasses.Name = "buttonClasses";
			this.buttonClasses.Size = new System.Drawing.Size(95, 23);
			this.buttonClasses.TabIndex = 26;
			this.buttonClasses.Text = "Seleccionar";
			this.buttonClasses.UseVisualStyleBackColor = true;
			this.buttonClasses.Click += new System.EventHandler(this.ButtonClassesClick);
			// 
			// label13
			// 
			this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(608, 125);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(100, 23);
			this.label13.TabIndex = 27;
			this.label13.Text = "Clases";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label14
			// 
			this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label14.Location = new System.Drawing.Point(583, 278);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(143, 23);
			this.label14.TabIndex = 28;
			this.label14.Text = "Arquitectura";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonArquitecture
			// 
			this.buttonArquitecture.Location = new System.Drawing.Point(608, 344);
			this.buttonArquitecture.Name = "buttonArquitecture";
			this.buttonArquitecture.Size = new System.Drawing.Size(95, 23);
			this.buttonArquitecture.TabIndex = 31;
			this.buttonArquitecture.Text = "Seleccionar";
			this.buttonArquitecture.UseVisualStyleBackColor = true;
			this.buttonArquitecture.Click += new System.EventHandler(this.ButtonArquitectureClick);
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(537, 316);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(111, 23);
			this.label15.TabIndex = 30;
			this.label15.Text = "Capas Ocultas:";
			// 
			// textBoxArquitecture
			// 
			this.textBoxArquitecture.Location = new System.Drawing.Point(654, 315);
			this.textBoxArquitecture.Name = "textBoxArquitecture";
			this.textBoxArquitecture.Size = new System.Drawing.Size(116, 22);
			this.textBoxArquitecture.TabIndex = 29;
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToAddRows = false;
			this.dataGridView2.AllowUserToDeleteRows = false;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Capa,
									this.Neuronas});
			this.dataGridView2.Location = new System.Drawing.Point(537, 383);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.RowTemplate.Height = 24;
			this.dataGridView2.Size = new System.Drawing.Size(240, 150);
			this.dataGridView2.TabIndex = 32;
			// 
			// Capa
			// 
			this.Capa.HeaderText = "Capa";
			this.Capa.Name = "Capa";
			this.Capa.Width = 50;
			// 
			// Neuronas
			// 
			this.Neuronas.HeaderText = "Neuronas";
			this.Neuronas.Name = "Neuronas";
			this.Neuronas.Width = 90;
			// 
			// buttonCreateArquitecture
			// 
			this.buttonCreateArquitecture.Location = new System.Drawing.Point(608, 539);
			this.buttonCreateArquitecture.Name = "buttonCreateArquitecture";
			this.buttonCreateArquitecture.Size = new System.Drawing.Size(95, 23);
			this.buttonCreateArquitecture.TabIndex = 33;
			this.buttonCreateArquitecture.Text = "Crear";
			this.buttonCreateArquitecture.UseVisualStyleBackColor = true;
			this.buttonCreateArquitecture.Click += new System.EventHandler(this.ButtonCreateArquitectureClick);
			// 
			// labelEpochs
			// 
			this.labelEpochs.Location = new System.Drawing.Point(855, 57);
			this.labelEpochs.Name = "labelEpochs";
			this.labelEpochs.Size = new System.Drawing.Size(150, 23);
			this.labelEpochs.TabIndex = 34;
			this.labelEpochs.Text = "# Epochs: ";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(876, 15);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(143, 23);
			this.label5.TabIndex = 39;
			this.label5.Text = "Resultados";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelError
			// 
			this.labelError.Location = new System.Drawing.Point(855, 83);
			this.labelError.Name = "labelError";
			this.labelError.Size = new System.Drawing.Size(150, 23);
			this.labelError.TabIndex = 40;
			this.labelError.Text = "Error: ";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(826, 125);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowTemplate.Height = 24;
			this.dataGridView1.Size = new System.Drawing.Size(240, 224);
			this.dataGridView1.TabIndex = 41;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1101, 689);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.labelError);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.labelEpochs);
			this.Controls.Add(this.buttonCreateArquitecture);
			this.Controls.Add(this.dataGridView2);
			this.Controls.Add(this.buttonArquitecture);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.textBoxArquitecture);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.buttonClasses);
			this.Controls.Add(this.comboBoxClasses);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.textBoxClasses);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.startAdaline);
			this.Controls.Add(this.graphicImage);
			this.Controls.Add(this.label1);
			this.Name = "MainForm";
			this.Text = "Practica 1 - IA 2";
			((System.ComponentModel.ISupportInitialize)(this.graphicImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label labelError;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label labelEpochs;
		private System.Windows.Forms.Button buttonCreateArquitecture;
		private System.Windows.Forms.DataGridViewTextBoxColumn Neuronas;
		private System.Windows.Forms.DataGridViewTextBoxColumn Capa;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.TextBox textBoxArquitecture;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Button buttonArquitecture;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button buttonClasses;
		private System.Windows.Forms.ComboBox comboBoxClasses;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBoxClasses;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button startAdaline;
		private System.Windows.Forms.PictureBox graphicImage;
		private System.Windows.Forms.Label label1;
	}
}
