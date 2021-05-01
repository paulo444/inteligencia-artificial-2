﻿/*
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
		List<float[,]> S;
		List<float[,]> A;
		
		public MLP()
		{
			
		}
		
		public void createMLP(List<int> layers){
			W = new List<float[,]>();
			B = new List<float[,]>();
			S = new List<float[,]>();
			A = new List<float[,]>();
			
			W.Add(new float[1,1]);
			B.Add(new float[1,1]);
			S.Add(new float[1,1]);
			A.Add(new float[1,1]);
			
			for(int i=1; i<layers.Count; i++){
				W.Add(new float[layers[i], layers[i-1]+1]);
				B.Add(new float[layers[i], 1]);
				S.Add(new float[layers[i], 1]);
				A.Add(new float[layers[i-1]+1, 1]);
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
				for(int j=0; j<B[i].GetUpperBound(0)+1; j++){
					B[i][j,0] = (float)GetRandomNumber(-5, 5, random);
				}
			}
			
			for(int i=1; i<S.Count; i++){
				for(int j=0; j<S[i].GetUpperBound(0)+1; j++){
					S[i][j,0] = (float)GetRandomNumber(-5, 5, random);
				}
			}
			
			for(int i=1; i<A.Count; i++){
				A[i][0,0] = -1;
				
				for(int j=1; j<A[i].GetUpperBound(0)+1; j++){
					A[i][j,0] = (float)GetRandomNumber(-5, 5, random);
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
			float[,] pvVector;
			
			for(int i=0; i<e; i++){
				for(int j=0; j<pv.Count; j++){
					pvVector = new float[3,1];
					pvVector[0,0] = -1;
					pvVector[1,0] = pv[j].X;
					pvVector[2,0] = pv[j].Y;
					
					A[0] = pvVector;
					
					for(int k=1; k<W.Count;k++){
						B[k] = multiplyMatrix(W[k], pvVector);
						pvVector = FwVector(B[k]);
						A[k] = pvVector;
					}

					
					
					
					
					float[,] errorV = errorVector(pv[j].V);
					float[,] fwVector = FwVectorBack(B[B.Count-1]);
					float[,] transposeV;
					
					for(int k=0; k<errorV.GetUpperBound(0)+1; k++){
						errorV[k,0] = -2 * errorV[k,0] * fwVector[k,0];
					}
					S[S.Count-1] = errorV;
					
					for(int k=S.Count-2; k>0; k--){
						fwVector = new float[S[k].GetUpperBound(0)+1, S[k].GetUpperBound(0)+1];
						transposeV = removeFirst(W[k+1]);
						transposeV = transposeMatrix(transposeV);
						fwVector = multiplyMatrix(transposeV, S[k+1]);
					}
					
					
					
					float[,] addW;
					
					for(int k=S.Count-1; k>0; k--){
						addW = multiplyMatrix(S[k], transposeMatrix(A[k-1]));
						addW = multiplyByNumber(addW, -lr);
						
						W[k] = addMatrix(W[k], addW);
					}
					
					
				}
			}
		}
		
		public float predict(PointValue pv){
			float[,] pvVector;

			pvVector = new float[3,1];
			pvVector[0,0] = -1;
			pvVector[1,0] = pv.X;
			pvVector[2,0] = pv.Y;
			
			for(int k=1; k<W.Count;k++){
				B[k] = multiplyMatrix(W[k], pvVector);
				pvVector = FwVector(B[k]);
			}

			return pvVector[1,0];
		}
		
		float[,] FwVector(float[,] ws){
			float[,] sum = new float[ws.GetUpperBound(0)+2,1];
			
			sum[0,0] = -1;
			
			for(int i=1; i<ws.GetUpperBound(0)+2; i++){
				sum[i,0] = (float)(1 / (1 + Math.Exp(-ws[i-1,0])));
			}
			
			return sum;
		}
		
		float[,] FwVectorBack(float[,] ws){
			float[,] sum = new float[ws.GetUpperBound(0)+1,1];
			
			for(int i=0; i<ws.GetUpperBound(0)+1; i++){
				sum[i,0] = (float)(1 / (1 + Math.Exp(-ws[i,0])));
			}
			
			return sum;
		}
		
		float[,] errorVector(float expectedValue){
			float[,] errors = new float[B[B.Count-1].GetUpperBound(0)+1 ,1];
			
			for(int i=0; i<errors.GetUpperBound(0)+1; i++){
				if(expectedValue == i){
					errors[i,0] = 1 - A[A.Count-1][i+1,0];
				}else{
					errors[i,0] = 0 - A[A.Count-1][i+1,0];
				}
			}
			
			return errors;
		}
		
		float[,] removeFirst(float[,] a){
			float[,] b = new float[a.GetUpperBound(0)+1,a.GetUpperBound(1)];
			
			for(int i=0; i<a.GetUpperBound(0)+1; i++){
				for(int j=0; j<a.GetUpperBound(1); j++){
					b[i,j] = a[i,j+1];
				}
			}
			
			return b;
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
			float[,] c = new float[a.GetUpperBound(0)+1, b.GetUpperBound(1)+1];
			
			for (int i=0; i<a.GetUpperBound(0)+1; i++) {
				for (int j=0; j<b.GetUpperBound(1)+1; j++) {
					for (int k=0; k<a.GetUpperBound(1)+1; k++) {
						c[i, j] += a[i, k] * b[k, j];
					}
				}
			}
			return c;
		}
		
		float[,] multiplyByNumber(float[,] a, float n){
			for (int i=0; i<a.GetUpperBound(0)+1; i++) {
				for (int j=0; j<a.GetUpperBound(1)+1; j++) {
					a[i,j] = a[i,j] * n;
				}
			}
			
			return a;
		}
		
		float[,] addMatrix(float[,] a, float[,] b){
			float[,] c = new float[a.GetUpperBound(0)+1, a.GetUpperBound(1)+1];
			
			for(int i=0; i<a.GetUpperBound(0)+1; i++){
				for (int j=0; j<b.GetUpperBound(1)+1; j++) {
					c[i, j] = a[i, j] + b[i, j];
				}
			}
			return c;
		}
		
		float[,] transposeMatrix(float[,] a){
			float[,] b = new float[a.GetUpperBound(1)+1, a.GetUpperBound(0)+1];

			for (int i = 0; i < a.GetUpperBound(0)+1; i++)
			{
				for (int j = 0; j < a.GetUpperBound(1)+1; j++)
				{
					b[j, i] = a[i, j];
				}
			}
			
			return b;
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
