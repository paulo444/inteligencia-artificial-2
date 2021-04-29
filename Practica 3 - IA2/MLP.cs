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
			
		}
		
		public void createMLP(List<int> layers){
			W = new List<float[,]>();
			B = new List<float[,]>();
			
			W.Add(new float[1,1]);
			B.Add(new float[1,1]);
			
			for(int i=1; i<layers.Count; i++){
				W.Add(new float[layers[i], layers[i-1]+1]);
				B.Add(new float[layers[i]+1, 1]);
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
				B[i][0,0] = -1;
				
				for(int j=1; j<W[i].GetUpperBound(0)+1; j++){
					B[i][j,0] = (float)GetRandomNumber(-5, 5, random);
				}
			}
		}
		
		double GetRandomNumber(int minimum, int maximum, Random rand)
		{
			return rand.NextDouble() * (maximum - minimum) + minimum;
		}
		
		public float[,] getFirstLayer(){
			return W[1];
		}
		
		public void trainMLP(List<PointValue> pv, int e, float lr){
			for(int i=0; i<e; i++){
				for(int j=0; j<pv.Count; j++){
					float[,] pvVector = new float[3,1];
					pvVector[0,0] = -1;
					pvVector[1,0] = pv[j].X;
					pvVector[2,0] = pv[j].Y;
					
					for(int k=1; i<W.Count;i++){
						float[,] resultMatrix = multiplyMatrix(W[k], pvVector);
						
						
					}
				}
			}
		}
		
		float[,] predictValue(PointValue pv){
			float[,] pvVector = new float[2,1];
			pvVector[0,0] = pv.X;
			pvVector[1,0] = pv.Y;
			
			for(int i=1; i<W.Count; i++){
				float[,] resultVector = multiplyMatrix(W[i], pvVector);
				resultVector = addMatrix(resultVector, B[i]);
				pvVector = Fw(resultVector, i);
			}
			
			return pvVector;
		}
		
		float[,] multiplyMatrix(float[,] a, float[,] b){
			float[,] c = new float[a.GetUpperBound(0)+1,1];
			
			for (int i=0; i<a.GetUpperBound(0)+1; i++) {
				for (int j=0; j<b.GetUpperBound(1)+1; j++) {
					for (int k=0; k<a.GetUpperBound(1)+1; k++) {
						c[i, j] += a[i, k] * b[k, j];
					}
				}
			}
			return c;
		}
		
		float[,] addMatrix(float[,] a, float[,] b){
			float[,] c = new float[a.GetUpperBound(0)+1,1];
			
			for(int i=0; i<a.GetUpperBound(0)+1; i++){
				for (int j=0; j<b.GetUpperBound(1)+1; j++) {
					c[i, j] = a[i, j] + b[i, j];
				}
			}
			return c;
		}
		
		float[,] Fw(float[,] pv, int b){
			float[,] sum = new float[pv.GetUpperBound(0)+1, 1];
			
			for(int i=0; i<pv.GetUpperBound(0)+1; i++){
				sum[i,0] = W[b][i,0] + (W[b][i,1]*pv[0,0]) + (W[b][i,2]*pv[1,0]);
				sum[i,0] = (float)(1 / (1 + Math.Exp(-sum[i,0])));
			}
			
			return sum;
		}
	}
}
