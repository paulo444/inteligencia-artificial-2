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
using System.Threading;

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
		
		float W0 = 0;
		float W1 = 0;
		float W2 = 0;
		float ETA;
		int epochs;
		float EXPECTED_ERROR;
		
		int SLEEP_TIME = 100;
		
		int mode = 0;
			
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
			
			if(mode == 0){
				if(me.Button == MouseButtons.Right){
					drawCircle(coords);
				}else{
					drawSquare(coords);
				}
			}else{
				classify(coords);
			}
		}
		
		void drawCircle(Point p){
			const int SIZE = 3;
			
			p = realPixels(p);
			
			using (Graphics gfx = Graphics.FromImage(graphicImage.Image)){
				gfx.DrawEllipse(new Pen(Color.Red),p.X-SIZE/2,p.Y-SIZE/2,SIZE,SIZE);
				this.graphicImage.Refresh();
			}
			
			addPoint(p,1);
		}
		
		void drawSquare(Point p){
			const int SIZE = 3;
			
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
			
			PointValue pv = new PointValue((float)p.X/10, (float)p.Y/10, val);
			points.Add(pv);
		}
		
		void drawLine(){
			for(int i=0; i<HEIGHT; i++){
				for(int j=0; j<WIDTH; j++){
					bitmap2.SetPixel(j,i,Color.Transparent);
				}
			}
			
			int x1 = -WIDTH/20;
			int x2 = WIDTH/20;
			
			int y1 = 0;
			int y2 = 0;
			
			if(W2 != 0){
				y1 = (int)(-(W1*x1+W0)/W2);
				y2 = (int)(-(W1*x2+W0)/W2);
			}
			
			x1 = x1 + WIDTH/20;
			
			if(y1 < 0){
				y1 = (WIDTH/20) + (y1*-1);
			}else{
				y1 = (WIDTH/20) - y1;
			}
			
			if(y2 < 0){
				y2 = (WIDTH/20) + (y2*-1);
			}else{
				y2 = (WIDTH/20) - y2;
			}
			
			using (Graphics gfx = Graphics.FromImage(pictureBox1.Image)){
				gfx.DrawLine(new Pen(Color.OrangeRed),
				             (x1*10),
				             (y1*10),
				             (x2*20),
				             (y2*10));
			}
			
			graphicImage.Refresh();
			pictureBox1.Refresh();
		}
		
		void setRandomValues(){
			Random random = new Random();
			
			W0 = (float)GetRandomNumber(-WIDTH/20,WIDTH/20, random);
			W1 = (float)GetRandomNumber(-WIDTH/20,WIDTH/20, random);
			W2 = (float)GetRandomNumber(-WIDTH/20,WIDTH/20, random);
			
			setValuesToScreen();
		}
		
		public double GetRandomNumber(int minimum, int maximum, Random rand)
		{
		    return rand.NextDouble() * (maximum - minimum) + minimum;
		}
		
		void setDefaultValues(){
			ETA = .4f;
			epochs = 100;
			EXPECTED_ERROR = .1f;
			
			textBox1.Text = ETA.ToString();
			textBox2.Text = epochs.ToString();
			textBox3.Text = EXPECTED_ERROR.ToString();
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
			ETA = float.Parse(textBox1.Text);
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
			int finish = 0;
			int epoch = 0;
			float error = 0;
			
			while(finish == 0 && epoch < epochs){
				finish = 1;
				
				for(int i=0; i<points.Count; i++){
					error = points[i].V - Pw(points[i]);
					
					if(error != 0){
						finish = 0;
						W0 = W0 + ETA * error;
						W1 = W1 + ETA * error * points[i].X;
						W2 = W2 + ETA * error * points[i].Y;
					}
				}
				epoch++;
				drawLine();
				Thread.Sleep(SLEEP_TIME);
			}
			
			drawLine();
			setValuesToScreen();
			setResultsToScreen(epoch);
			mode = 1;
		}
		
		int Pw(PointValue pv){
			float sum = 0;
			
			sum = (W0) + (W1*pv.X) + (W2*pv.Y);
			
			if(sum >= 0){
				return 1;
			}else{
				return 0;
			}
		}
		
		void setValuesToScreen(){
			label5.Text = "W0: " + W0.ToString();
			label6.Text = "W1: " + W1.ToString();
			label7.Text = "W2: " + W2.ToString();
		}
		
		void setResultsToScreen(int e){
			if(e >= epochs){
				epochNumber.Text = "#Epochs: NO";
			}else{
				epochNumber.Text = "#Epochs: " + e.ToString();
			}
			generateConfusionTable();
		}
		
		void classify(Point p){
			Point rp = realPixels(p);
			
			PointValue pv = new PointValue();
			
			pv.X = (float)(-(WIDTH/2) + rp.X)/10;
			pv.Y = (float)(HEIGHT/2 - rp.Y)/10;
			pv.V = Pw(pv);
			
			if(pv.V == 1){
				drawCircle(p);
			}else{
				drawSquare(p);
			}
		}
		
		void generateConfusionTable(){
			int tt = 0, tf = 0, ft = 0, ff = 0;
			float error;
			
			for(int i=0; i<points.Count; i++){
				error = points[i].V - Pw(points[i]);
				
				if(error == 0){
					if(points[i].V == 0){
						ff++;
					}else{
						tt++;
					}
				}else if(error == 1){
					tf++;
				}else{
					ft++;
				}
			}
			
			dataGridView1.Rows.Clear();
			dataGridView1.Rows.Add("V",tt.ToString(),ft.ToString());
			dataGridView1.Rows.Add("F",tf.ToString(),ff.ToString());
		}
	}
}
