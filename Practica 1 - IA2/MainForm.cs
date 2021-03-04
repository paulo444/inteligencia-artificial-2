/*
 * Created by SharpDevelop.
 * User: paulo
 * Date: 02/03/2021
 * Time: 04:14 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Practica_1___IA_2
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		const int WIDTH = 100;
		const int HEIGHT = 100;
		Bitmap bitmap;
		Bitmap bitmap2;
		List<PointValue> points;
		
		int W0;
		int W1;
		int W2;
		float eta;
		int epochs;
			
		public MainForm()
		{
			InitializeComponent();
			setGraphic();
			setDefaultValues();
			
			points = new List<PointValue>();
		}
		
		void setGraphic(){
			bitmap = new Bitmap(WIDTH, HEIGHT);
			bitmap2 = new Bitmap(WIDTH,HEIGHT);
			
			pictureBox1.BackColor = Color.Transparent;
			pictureBox1.Parent = graphicImage;
			pictureBox1.Location = new Point(0, 0);
			
			for(int i=0; i<HEIGHT; i++)
			{
				for(int j=0; j<WIDTH; j++){
					bitmap.SetPixel(j,i,Color.White);
				}
			}
			
			drawCenterLines();
			
			graphicImage.Image = bitmap;
			pictureBox1.Image = bitmap2;
		}
		
		void drawCenterLines(){
			for(int i=0; i<HEIGHT; i++){
				bitmap.SetPixel(WIDTH/2, i, Color.Black);
			}
			
			for(int i=0; i<WIDTH; i++){
				bitmap.SetPixel(i, HEIGHT/2, Color.Black);
			}
		}
		
		void PictureBox1Click(object sender, EventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			Point coords = me.Location;
			
			if(me.Button == MouseButtons.Right){
				drawCircle(coords);
			}else{
				drawSquare(coords);
			}
		}
		
		void drawCircle(Point p){
			const int SIZE = 6;
			
			p = realPixels(p);
			
			using (Graphics gfx = Graphics.FromImage(graphicImage.Image)){
				gfx.DrawEllipse(new Pen(Color.Red),p.X-SIZE/2,p.Y-SIZE/2,SIZE,SIZE);
				this.graphicImage.Refresh();
			}
			
			addPoint(p,1);
		}
		
		void drawSquare(Point p){
			const int SIZE = 6;
			
			p = realPixels(p);
			
			using (Graphics gfx = Graphics.FromImage(graphicImage.Image)){
				gfx.DrawRectangle(new Pen(Color.Blue),p.X-SIZE/2,p.Y-SIZE/2,SIZE,SIZE);
				this.graphicImage.Refresh();
			}
			
			addPoint(p,0);
		}
		
		Point realPixels(Point p){
			Int32 realW = graphicImage.Image.Width;
		    Int32 realH = graphicImage.Image.Height;
		    Int32 currentW = graphicImage.ClientRectangle.Width;
		    Int32 currentH = graphicImage.ClientRectangle.Height;
		    Double zoomW = (currentW / (Double)realW);
		    Double zoomH = (currentH / (Double)realH);
		    Double zoomActual = Math.Min(zoomW, zoomH);
		    Double padX = zoomActual == zoomW ? 0 : (currentW - (zoomActual * realW)) / 2;
		    Double padY = zoomActual == zoomH ? 0 : (currentH - (zoomActual * realH)) / 2;
		
		    Int32 realX = (Int32)((p.X - padX) / zoomActual);
		    Int32 realY = (Int32)((p.Y - padY) / zoomActual);
		    
		    Point realPoint = new Point(realX,realY);
		    return realPoint;
		}
		
		void addPoint(Point p, int val){
			p.X = -(WIDTH/2) + p.X;
			p.Y = HEIGHT/2 - p.Y;
			
			PointValue pv = new PointValue(p.X, p.Y, val);
			points.Add(pv);
		}
		
		void drawLine(){
			for(int i=0; i<HEIGHT; i++){
				for(int j=0; j<WIDTH; j++){
					bitmap2.SetPixel(j,i,Color.Transparent);
				}
			}
			
			for(int i=0; i<WIDTH; i++){
				if(W2 == 0){
					break;
				}
				
				int y = (-W1*i+W0)/W2;
				
				if(y < 0 || y >= HEIGHT){
					
				}else{
					bitmap2.SetPixel(i,y,Color.OrangeRed);
				}
			}
			
			graphicImage.Refresh();
			pictureBox1.Refresh();
		}
		
		void setRandomValues(){
			Random random = new Random();
			
			W0 = random.Next(-WIDTH,WIDTH);
			W1 = random.Next(-WIDTH,WIDTH);
			W2 = random.Next(-WIDTH,WIDTH);
			
			label5.Text = "W0: " + W0.ToString();
			label6.Text = "W1: " + W1.ToString();
			label7.Text = "W2: " + W2.ToString();
		}
		
		void setDefaultValues(){
			eta = .4f;
			epochs = 100;
			
			textBox1.Text = eta.ToString();
			textBox2.Text = epochs.ToString();
		}
		
		void InitializeValuesClick(object sender, EventArgs e)
		{
			setRandomValues();
			drawLine();
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (!int.TryParse(textBox1.Text, out parsedValue))
			{
			    return;
			}
			eta = float.Parse(textBox1.Text);
		}
		
		void TextBox2TextChanged(object sender, EventArgs e)
		{
			int parsedValue;
			if (!int.TryParse(textBox2.Text, out parsedValue))
			{
			    return;
			}
			epochs = int.Parse(textBox2.Text);
		}
		
		void StartPerceptronClick(object sender, EventArgs e)
		{
			
		}
	}
}
