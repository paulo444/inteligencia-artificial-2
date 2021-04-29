/*
 * Created by SharpDevelop.
 * User: paulo
 * Date: 4/29/2021
 * Time: 12:36 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Diagnostics;

namespace Practica_1___IA_2
{
	/// <summary>
	/// Description of MLP.
	/// </summary>
	public class MLP
	{
		List<float[,]> W;
		List<float[,]> B;
		
		public MLP()
		{
			//W = new List<float[,]>();
			//W.Add(new float[3,3]);
			//W[0][0,0] = 0;
		}
		
		public void createMLP(List<int> layers){
			W = new List<float[,]>();
			B = new List<float[,]>();
			
			W.Add(new float[1,1]);
			B.Add(new float[1,1]);
			
			for(int i=1; i<layers.Count; i++){
				W.Add(new float[layers[i], layers[i-1]]);
				B.Add(new float[layers[i], 1]);
			}
			
			setRandomData();
		}
		
		public void setRandomData(){
			Random random = new Random();
			
			for(int i=1; i<W.Count; i++){
				for(int j=0; j<W[i].GetUpperBound(0)+1; j++){
					for(int k=0; k<W[i].GetUpperBound(1)+1; k++){
						W[i][j,k] = (float)GetRandomNumber(-5, 5, random);
					}
				}
			}
			
			for(int i=1; i<B.Count; i++){
				for(int j=0; j<W[i].GetUpperBound(0)+1; j++){
					B[i][j,0] = (float)GetRandomNumber(-5, 5, random);
				}
			}
		}
		
		double GetRandomNumber(int minimum, int maximum, Random rand)
		{
		    return rand.NextDouble() * (maximum - minimum) + minimum;
		}
	}
}
