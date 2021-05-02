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
		
		int ERRORS_WIDTH = 300;
		int ERRORS_HEIGHT = 100;
		
		Bitmap bitmap;
		Bitmap bitmap2;
		Bitmap bitmap3;
		
		List<PointValue> points;
		
		float W0 = 0;
		float W1 = 0;
		float W2 = 0;
		
		float ETA;
		int epochs;
		float EXPECTED_ERROR;
		
		int SLEEP_TIME = 100;
		
		int mode = 0;
		
		//MLP
		Classes classes;
		MLP mlp;
		
		int classNumber;
		int hiddenLayers;
		
		public MainForm()
		{
			InitializeComponent();
			setGraphic();
			setDefaultValues();
			
			points = new List<PointValue>();
			classes = new Classes();
			mlp = new MLP();
		}
		
		//Graficas principal
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
				if(me.Button == MouseButtons.Left){
					drawCircle(coords);
				}
			}else{
				classify(coords);
			}
		}
		
		void drawCircle(Point p){
			const int SIZE = 3;
			
			p = realPixels(p);
			
			using (Graphics gfx = Graphics.FromImage(graphicImage.Image)){
				gfx.DrawEllipse(new Pen(classes.getColorClass(int.Parse(comboBoxClasses.Text))),p.X-SIZE/2,p.Y-SIZE/2,SIZE,SIZE);
				this.graphicImage.Refresh();
			}
			
			addPoint(p, int.Parse(comboBoxClasses.Text));
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
		
		void drawLines(float[,] ws){
			for(int i=0; i<HEIGHT; i++){
				for(int j=0; j<WIDTH; j++){
					bitmap2.SetPixel(j,i,Color.Transparent);
				}
			}
			
			for(int i=0; i<ws.GetUpperBound(0)+1; i++){
				int x1 = -WIDTH/20;
				int x2 = WIDTH/20;
				
				int y1 = 0;
				int y2 = 0;
				
				if(ws[i,2] != 0){
					y1 = (int)(-(ws[i,1]*x1+ws[i,0])/ws[i,2]);
					y2 = (int)(-(ws[i,1]*x2+ws[i,0])/ws[i,2]);
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
				
			}
			
			graphicImage.Refresh();
			pictureBox1.Refresh();
		}
		
		void setDefaultValues(){
			ETA = .4f;
			epochs = 100;
			EXPECTED_ERROR = .1f;
			classNumber = 3;
			hiddenLayers = 3;
			
			textBox1.Text = ETA.ToString();
			textBox2.Text = epochs.ToString();
			textBox3.Text = EXPECTED_ERROR.ToString();
			textBoxClasses.Text = classNumber.ToString();
			textBoxArquitecture.Text = hiddenLayers.ToString();
			comboBoxClasses.Text = "0";
			setClasses();
		}
		
		//Datos de TextBox
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			float parsedValue;
			if (!float.TryParse(textBox1.Text, out parsedValue))
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
		
		void TextBox3TextChanged(object sender, EventArgs e)
		{
			float parsedValue;
			if (!float.TryParse(textBox3.Text, out parsedValue))
			{
				return;
			}
			EXPECTED_ERROR = float.Parse(textBox3.Text);
		}
		
		//Adaline
		void StartAdalineClick(object sender, EventArgs e)
		{
			int epoch = 0;
			float error = 0;
			float acumulateError = 1;
			
			createErrorGraphic();
			
			while(acumulateError > EXPECTED_ERROR && epoch < epochs){
				acumulateError = 0;
				
				for(int i=0; i<points.Count; i++){
					error = points[i].V - Fw(points[i]);
					acumulateError += (error*error)/2;
					
					W0 = W0 + ETA * error * FwSingle(W0) * (1 - FwSingle(W0));
					W1 = W1 + ETA * error * FwSingle(W1) * (1 - FwSingle(W1)) * points[i].X;
					W2 = W2 + ETA * error * FwSingle(W2) * (1 - FwSingle(W2)) * points[i].Y;
				}
				
				epoch++;
				
				drawCuadraticError(epoch*2, (int)(acumulateError*ERRORS_HEIGHT));
				
				Thread.Sleep(SLEEP_TIME);
			}
			
			drawErrorNumbers();
			fullEvaluation();
			
			mode = 1;
		}
		
		float Fw(PointValue pv){
			float sum = 0;
			
			sum = (W0) + (W1*pv.X) + (W2*pv.Y);
			sum = (float)(1 / (1 + Math.Exp(-sum)));
			
			return sum;
		}
		
		float FwSingle(float w){
			float sum = 0;
			
			sum = (float)(1 / (1 + Math.Exp(-w)));
			
			return sum;
		}
		
		float abs(float pv){
			if(pv < 0){
				return pv * -1;
			}
			return pv * -1;
		}
		
		void classify(Point p){
			Point rp = realPixels(p);
			
			PointValue pv = new PointValue();
			
			pv.X = (float)(-(WIDTH/2) + rp.X)/10;
			pv.Y = (float)(HEIGHT/2 - rp.Y)/10;
			pv.V = Fw(pv);
			
			if(pv.V > 0.5){
				drawCircle(p);
			}else{
				//drawSquare(p);
			}
		}
		
		//Error cuadratico
		void createErrorGraphic(){
			ERRORS_WIDTH = epochs * 2;
			ERRORS_HEIGHT = ERRORS_WIDTH/3;
			
			bitmap3 = new Bitmap(ERRORS_WIDTH,ERRORS_HEIGHT);
			
			for(int i=0; i<ERRORS_HEIGHT; i++){
				for(int j=0; j<ERRORS_WIDTH; j++){
					bitmap3.SetPixel(j,i, Color.White);
				}
			}
			
			pictureBox2.Image = bitmap3;
			
			drawErrorNumbers();
		}
		
		void drawErrorNumbers(){
			int fontSize = (int)(ERRORS_WIDTH*.03);
			int moveString = fontSize*2;
			
			if(epochs < 30){
				return;
			}
			
			using (Graphics gfx = Graphics.FromImage(pictureBox2.Image)){
				gfx.DrawString("1", new Font("Arial",fontSize), new SolidBrush(Color.Black),0,0);
				gfx.DrawString("0", new Font("Arial",fontSize), new SolidBrush(Color.Black),0,ERRORS_HEIGHT-moveString);
				
				gfx.DrawString(epochs.ToString(), new Font("Arial",fontSize), new SolidBrush(Color.Black),ERRORS_WIDTH-moveString,ERRORS_HEIGHT-moveString);
			}
			
			pictureBox2.Refresh();
		}
		
		void drawCuadraticError(int x, int y){
			if(x >= ERRORS_WIDTH){
				return;
			}
			
			if(y >= ERRORS_HEIGHT){
				y = ERRORS_HEIGHT-1;
			}
			
			for(int i=ERRORS_HEIGHT-1; i>ERRORS_HEIGHT-y; i--){
				bitmap3.SetPixel(x, i, Color.Silver);
			}
			
			pictureBox2.Refresh();
		}
		
		void fullEvaluation(){
			for(int i=0; i<HEIGHT; i++){
				for(int j=0; j<WIDTH; j++){
					bitmap2.SetPixel(j,i,Color.Transparent);
				}
			}
			
			for(int i=0; i<HEIGHT; i++){
				for(int j=0; j<WIDTH; j++){
					if(bitmap.GetPixel(j,i).R == 255 && bitmap.GetPixel(j,i).G == 255 && bitmap.GetPixel(j,i).B == 255){
						Point rp = new Point(j,i);
						
						PointValue pv = new PointValue();
						
						pv.X = (float)(-(WIDTH/2) + rp.X)/10;
						pv.Y = (float)(HEIGHT/2 - rp.Y)/10;
						pv.V = Fw(pv);
						
						if(pv.V >= .5){
							bitmap.SetPixel(j,i, Color.FromArgb(getColor(pv.V),0,0));
						}else{
							bitmap.SetPixel(j,i, Color.FromArgb(0,0,getColor(pv.V)));
						}
					}
				}
			}
			
			graphicImage.Refresh();
			pictureBox2.Refresh();
		}
		
		int getColor(float c){
			int color;
			
			if(c >= .5){
				color = (int)(50 + (150 * (c-.5)) / .5);
			}else{
				color = (int)(50 + (150 * (.5-c)) / .5);
			}
			
			return color;
		}
		
		//MLP
		void ButtonClassesClick(object sender, EventArgs e)
		{
			int parsedValue;
			if (!int.TryParse(textBoxClasses.Text, out parsedValue))
			{
				return;
			}
			classNumber = int.Parse(textBoxClasses.Text);
			setClasses();
		}
		
		void setClasses(){
			comboBoxClasses.Items.Clear();
			
			for(int i=0; i<classNumber; i++){
				comboBoxClasses.Items.Add(i.ToString());
			}
		}
		
		void ButtonArquitectureClick(object sender, EventArgs e)
		{
			int parsedValue;
			if (!int.TryParse(textBoxArquitecture.Text, out parsedValue))
			{
				return;
			}
			hiddenLayers = int.Parse(textBoxArquitecture.Text);
			setArquitecture();
		}
		
		void setArquitecture(){
			dataGridView2.Rows.Clear();
			
			for(int i=0; i<hiddenLayers; i++){
				dataGridView2.Rows.Add(i.ToString());
			}
		}
		
		void ButtonCreateArquitectureClick(object sender, EventArgs e)
		{
			//setRandomValues();
			//drawLine();
			
			List<int> layers = new List<int>();
			
			layers.Add(2);
			for(int i=0; i<hiddenLayers; i++){
				layers.Add(int.Parse(dataGridView2.Rows[i].Cells[1].Value.ToString()));
			}
			
			layers.Add(classNumber);
			
			mlp.createMLP(layers);
			drawLines(mlp.getFirstLayer());
		}
		
		void StartMLPClick(object sender, EventArgs e)
		{
			createErrorGraphic();
			mlp.trainMLP(points, epochs, ETA, EXPECTED_ERROR, ERRORS_WIDTH, ERRORS_HEIGHT, bitmap3, pictureBox2, labelEpochs);
			evaluateAll();
		}
		
		void evaluateAll(){
			for(int i=0; i<HEIGHT; i++){
				for(int j=0; j<WIDTH; j++){
					bitmap2.SetPixel(j,i,Color.Transparent);
				}
			}
			
			for(int i=0; i<HEIGHT; i++){
				for(int j=0; j<WIDTH; j++){
					if(bitmap.GetPixel(j,i).R == 255 && bitmap.GetPixel(j,i).G == 255 && bitmap.GetPixel(j,i).B == 255){
						Point rp = new Point(j,i);
						
						PointValue pv = new PointValue();
						
						pv.X = (float)(-(WIDTH/2) + rp.X)/10;
						pv.Y = (float)(HEIGHT/2 - rp.Y)/10;
						float[,] prediction = mlp.predict(pv);
						float color = -1;
						int colorIndex = 0;
						
						for(int k=1; k<prediction.GetUpperBound(0)+1; k++){
							if(color < prediction[k,0]){
								colorIndex = k-1;
								color = prediction[k,0];
							}
						}
						
						bitmap.SetPixel(j,i, classes.getColorClass(colorIndex));
					}
				}
			}
			
			graphicImage.Refresh();
			pictureBox2.Refresh();
		}
	}
}
