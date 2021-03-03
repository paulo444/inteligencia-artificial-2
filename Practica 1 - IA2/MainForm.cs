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
		List<Point> points;
			
		public MainForm()
		{
			InitializeComponent();
			setGraphic();
			
			points = new List<Point>();
		}
		
		void setGraphic(){
			bitmap = new Bitmap(WIDTH, HEIGHT);
			
			for(int i=0; i<HEIGHT; i++)
			{
				for(int j=0; j<WIDTH; j++){
					bitmap.SetPixel(j,i,Color.White);
				}
			}
			
			drawCenterLines();
			
			graphicImage.Image = bitmap;
		}
		
		void drawCenterLines(){
			for(int i=0; i<HEIGHT; i++){
				bitmap.SetPixel(WIDTH/2, i, Color.Black);
			}
			
			for(int i=0; i<WIDTH; i++){
				bitmap.SetPixel(i, HEIGHT/2, Color.Black);
			}
		}
		
		void GraphicImageClick(object sender, EventArgs e)
		{
			MouseEventArgs me = (MouseEventArgs)e;
			Point coords = me.Location;
			
			textBox1.Text = coords.X.ToString();
			textBox2.Text = coords.Y.ToString();
			
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
			
			points.Add(p);
		}
		
		void drawSquare(Point p){
			const int SIZE = 6;
			
			p = realPixels(p);
			
			using (Graphics gfx = Graphics.FromImage(graphicImage.Image)){
				gfx.DrawRectangle(new Pen(Color.Blue),p.X-SIZE/2,p.Y-SIZE/2,SIZE,SIZE);
				this.graphicImage.Refresh();
			}
			
			points.Add(p);
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
		
				
		void StartPerceptronClick(object sender, EventArgs e)
		{
			
		}
	}
}
