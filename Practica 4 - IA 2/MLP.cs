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
		List<float[,]> S;
		List<float[,]> A;
		
		const int V = 10;
		float[,] JK;
		float[,] E;
		
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
		
		public void trainMLP(List<PointValue> pv, int e, float lr, float er, int errorsWidth, int errorsHeight, Bitmap bm, PictureBox pb,
		                     Label lbl, Bitmap bm2, PictureBox pb2, Label eL){
			float[,] pvVector;
			float currentError = 1;
			int i, j;
			
			for(i=0; i<e && currentError > er; i++){
				currentError = 0;
				drawLines(getFirstLayer(), bm2, pb2);
				
				for(j=0; j<pv.Count; j++){
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
					
					float cError = 0;
					for(int k=0; k<errorV.GetUpperBound(0)+1; k++){
						//cError += Math.Abs(errorV[k, 0]);
						cError += errorV[k, 0] * errorV[k, 0];
					}
					
					cError = (float)Math.Sqrt(cError);
					//cError = cError/(errorV.GetUpperBound(0)+1);
					currentError += cError * cError;
					
					for(int k=0; k<errorV.GetUpperBound(0)+1; k++){
						errorV[k,0] = -2 * errorV[k,0] * fwVector[k,0];
					}
					S[S.Count-1] = errorV;
					
					for(int k=S.Count-2; k>0; k--){
						fwVector = FwVectorBack(B[k]);
						fwVector = FwVectorPoint(fwVector);
						transposeV = removeFirst(W[k+1]);
						transposeV = transposeMatrix(transposeV);
						fwVector = multiplyMatrix(fwVector, transposeV);
						fwVector = multiplyMatrix(fwVector, S[k+1]);
						S[k] = fwVector;
					}
					
					float[,] addW;
					
					for(int k=S.Count-1; k>0; k--){
						addW = multiplyMatrix(S[k], transposeMatrix(A[k-1]));
						addW = multiplyByNumber(addW, -lr);
						
						W[k] = addMatrix(W[k], addW);
					}
				}
				currentError = currentError / pv.Count;
				drawCuadraticError(i*2, (int)(currentError*errorsHeight), errorsWidth, errorsHeight, bm, pb);
				eL.Text = "Error: " + currentError;
			}
			
			if(i < e){
				lbl.Text = "#Epochs: " + i.ToString();
			}else{
				lbl.Text = "#Epochs: NO";
			}
		}
		
		public void trainLevenbergMarquardt(List<PointValue> pv, int e, float lr, float er, int errorsWidth, int errorsHeight, Bitmap bm, PictureBox pb,
		                                    Label lbl, Bitmap bm2, PictureBox pb2, Label eL){
			float[,] pvVector;
			float currentError = 1;
			int i, j;
			float newError = 0;
			float MU = lr;
			
			for(i=0; i<e && currentError > er; i++){
				currentError = 0;
				drawLines(getFirstLayer(), bm2, pb2);
				JK = null;
				E = null;
				
				for(j=0; j<pv.Count; j++){
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
					
					float cError = 0;
					for(int k=0; k<errorV.GetUpperBound(0)+1; k++){
						cError += errorV[k, 0] * errorV[k, 0];
					}
					
					cError = (float)Math.Sqrt(cError);
					currentError += cError * cError;
					
					//concatenateError(errorV);
					
					
					
					float[,] fwVector = FwVectorBack(B[B.Count-1]);
					float[,] transposeV;
					
					for(int k=0; k<errorV.GetUpperBound(0)+1; k++){
						errorV[k,0] = -2 * errorV[k,0] * fwVector[k,0];
					}
					S[S.Count-1] = errorV;
					
					for(int k=S.Count-2; k>0; k--){
						fwVector = FwVectorBack(B[k]);
						fwVector = FwVectorPoint(fwVector);
						transposeV = removeFirst(W[k+1]);
						transposeV = transposeMatrix(transposeV);
						fwVector = multiplyMatrix(fwVector, transposeV);
						fwVector = multiplyMatrix(fwVector, S[k+1]);
						S[k] = fwVector;
					}
					
					for(int k=S.Count-1; k>0; k--){
						S[k] = multiplyMatrix(S[k], transposeMatrix(A[k-1]));
					}
					createJacobian(pv.Count, j);
					createError(pv.Count, j, cError);
					
					
					//for(int k=S.Count-1; k>0; k--){
					//addW = multiplyMatrix(S[k], transposeMatrix(A[k-1]));
					//addW = multiplyByNumber(addW, -lr);
					
					//float[,] jacobian = multiplyMatrix(S[k], B[k]);
					/*float[,] transposeJacobian = transposeMatrix(S[k]);
					float[,] semiHessian = multiplyMatrix(transposeJacobian, S[k]);
					float[,] identityMatrix = identityMU(MU, semiHessian.GetUpperBound(1)+1);
					float[,] addIdentity = addMatrix(semiHessian, identityMatrix);
					float[,] inverse = inverseMatrix(addIdentity);
					float[,] multiplyJacobian = multiplyMatrix(inverse, transposeJacobian);
					float[,] multiplyError = multiplyMatrix(multiplyJacobian, errorV);
					
					W[k] = subtractMatrix(W[k], multiplyError);
					 */
					//W[k] = addMatrix(W[k], addW);
					//}
				}
				
				currentError = currentError / pv.Count;
				drawCuadraticError(i*2, (int)(currentError*errorsHeight), errorsWidth, errorsHeight, bm, pb);
				eL.Text = "Error: " + currentError;
				
				
				JK = transposeMatrix(JK);
				float[,] transposeJacobian = transposeMatrix(JK);
				float[,] semiHessian = multiplyMatrix(transposeJacobian, JK);
				float[,] identityMatrix = identityMU(MU, semiHessian.GetUpperBound(1)+1);
				float[,] addIdentity = addMatrix(semiHessian, identityMatrix);
				float[,] inverse = inverseMatrix(addIdentity);
				float[,] multiplyJacobian = multiplyMatrix(inverse, transposeJacobian);
				float[,] multiplyError = multiplyMatrix(multiplyJacobian, E);
				
				subtractMatrixData(multiplyError);
				
				
				
				for(j=0; j<pv.Count; j++){
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
					
					float cError = 0;
					for(int k=0; k<errorV.GetUpperBound(0)+1; k++){
						cError += errorV[k, 0] * errorV[k, 0];
					}
					
					cError = (float)Math.Sqrt(cError);
					newError += cError * cError;
				}
				
				newError = newError / pv.Count;
				
				if(newError > currentError){
					MU *= V;
					addMatrixData(multiplyError);
				}else{
					MU /= V;
				}
			}
			
			if(i < e){
				lbl.Text = "#Epochs: " + i.ToString();
			}else{
				lbl.Text = "#Epochs: NO";
			}
		}
		
		public float[,] predict(PointValue pv){
			float[,] pvVector;

			pvVector = new float[3,1];
			pvVector[0,0] = -1;
			pvVector[1,0] = pv.X;
			pvVector[2,0] = pv.Y;
			
			for(int k=1; k<W.Count;k++){
				B[k] = multiplyMatrix(W[k], pvVector);
				pvVector = FwVector(B[k]);
			}

			return pvVector;
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
				sum[i,0] = sum[i,0] * (1 - sum[i,0]);
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
		
		float[,] subtractMatrix(float[,] a, float[,] b){
			float[,] c = new float[a.GetUpperBound(0)+1, a.GetUpperBound(1)+1];
			
			for(int i=0; i<a.GetUpperBound(0)+1; i++){
				for (int j=0; j<b.GetUpperBound(1)+1; j++) {
					c[i, j] = a[i, j] - b[i, j];
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
		
		float[,] FwVectorPoint(float[,] a){
			float[,] b = new float[a.GetUpperBound(0)+1, a.GetUpperBound(0)+1];
			
			for(int i=0; i<a.GetUpperBound(0)+1; i++){
				b[i,i] = a[i,0];
			}
			
			return b;
		}
		
		float[,] identityMU(float mu, int size){
			float[,] identity = new float[size, size];
			
			for(int i=0; i<size; i++){
				identity[i,i] = 1*mu;
			}
			
			return identity;
		}
		
		float[,] inverseMatrix(float[,] a){
			float[,] b = new float[a.GetUpperBound(0)+1, a.GetUpperBound(1)+1];
			
			for(int i=0; i<a.GetUpperBound(0)+1; i++){
				for(int j=0; j<a.GetUpperBound(1)+1; j++){
					b[i,j] = 1/a[i,j];
				}
			}
			return b;
			
			//return cofactor(a, a.GetUpperBound(0)+1);
		}
		
		float determinant(float[,] a, float k)
		{
			float s = 1, det = 0;
			float[,] b = new float[a.GetUpperBound(0)+1, a.GetUpperBound(1)+1];
			int i, j, m, n, c;

			if (k == 1)
			{
				return (a[0,0]);
			}
			else
			{
				det = 0;
				for (c = 0; c < k; c++)
				{

					m = 0;

					n = 0;

					for (i = 0;i < k; i++)

					{

						for (j = 0 ;j < k; j++)

						{

							b[i,j] = 0;

							if (i != 0 && j != c)

							{

								b[m,n] = a[i,j];

								if (n < (k - 2))

									n++;

								else

								{

									n = 0;

									m++;

								}

							}

						}

					}

					det = det + s * (a[0,c] * determinant(b, k - 1));

					s = -1 * s;

				}

			}
			
			return (det);
		}

		

		float[,] cofactor(float[,] num, float f)
		{
			float[,] b = new float[num.GetUpperBound(0)+1, num.GetUpperBound(0)+1];
			float[,] fac = new float[num.GetUpperBound(0)+1, num.GetUpperBound(0)+1];

			int p, q, m, n, i, j;

			for (q = 0;q < f; q++)

			{

				for (p = 0;p < f; p++)

				{

					m = 0;

					n = 0;

					for (i = 0;i < f; i++)

					{

						for (j = 0;j < f; j++)

						{

							if (i != q && j != p)

							{

								b[m,n] = num[i,j];

								if (n < (f - 2))

									n++;

								else

								{

									n = 0;

									m++;

								}

							}

						}

					}

					fac[q,p] = (float)(Math.Pow(-1, q + p)) * determinant(b, f - 1);

				}

			}

			return transpose(num, fac, f);

		}

		float[,] transpose(float[,] num, float[,] fac, float r)
		{

			int i, j;

			float d;
			float [,] b = new float[num.GetUpperBound(0)+1, num.GetUpperBound(0)+1];
			float [,] inverse = new float[num.GetUpperBound(0)+1, num.GetUpperBound(0)+1];

			

			for (i = 0;i < r; i++)

			{

				for (j = 0;j < r; j++)

				{

					b[i,j] = fac[j,i];

				}

			}

			d = determinant(num, r);

			for (i = 0;i < r; i++)

			{

				for (j = 0;j < r; j++)

				{

					inverse[i,j] = b[i,j] / d;

				}

			}
			
			return inverse;

		}

		void createJacobian(int input, int row){
			int size = 0;
			
			for(int i=1; i<W.Count; i++){
				size = size + (W[i].GetUpperBound(0)+1) * (W[i].GetUpperBound(1)+1);
			}
			
			if(row == 0){
				JK = new float[size, input];
			}

			int l = 0;
			
			for(int i=1; i<S.Count; i++){
				for(int j=0; j<S[i].GetUpperBound(0)+1; j++){
					for(int k=0; k<S[i].GetUpperBound(1)+1; k++){
						JK[l, row] = S[i][j,k];
						l++;
					}
				}
			}
		}

		void createError(int input, int row, float e){
			if(row == 0){
				E = new float[input, 1];
			}
			
			E[row, 0] = e;
		}

		void concatenateJacobian(float[,] a){
			float[,] JK2 = new float[JK.GetUpperBound(0)+1 + a.GetUpperBound(0)+1, JK.GetUpperBound(1)+1 + a.GetUpperBound(0)+1];
			
			for(int i=0; i<JK.GetUpperBound(0)+1; i++){
				for(int j=0; j<JK.GetUpperBound(1)+1; j++){
					JK2[i,j] = JK[i,j];
				}
			}
			
			for(int i=0; i<a.GetUpperBound(0)+1; i++){
				for(int j=0; j<a.GetUpperBound(1)+1; j++){
					JK2[a.GetUpperBound(0)+1+i, a.GetUpperBound(1)+1+j] = a[i,j];
				}
			}
			
			JK = JK2;
		}

		void concatenateError(float[,] a){
			float[,] E2 = new float[E.GetUpperBound(0)+1 + a.GetUpperBound(0)+1, E.GetUpperBound(1)+1 + a.GetUpperBound(0)+1];
			
			for(int i=0; i<E.GetUpperBound(0)+1; i++){
				for(int j=0; j<E.GetUpperBound(1)+1; j++){
					E2[i,j] = E[i,j];
				}
			}
			
			for(int i=0; i<a.GetUpperBound(0)+1; i++){
				for(int j=0; j<a.GetUpperBound(1)+1; j++){
					E2[a.GetUpperBound(0)+1+i, a.GetUpperBound(1)+1+j] = a[i,j];
				}
			}
			
			E = E2;
		}

		void subtractMatrixData(float[,] a){
			int l = 0;
			
			for(int i=1; i<W.Count; i++){
				for(int j=0; j<W[i].GetUpperBound(0)+1; j++){
					for(int k=0; k<W[i].GetUpperBound(1)+1; k++){
						W[i][j,k] = W[i][j,k] - a[l,0];
						l++;
					}
				}
			}
		}

		void addMatrixData(float[,] a){
			int l = 0;
			
			for(int i=1; i<W.Count; i++){
				for(int j=0; j<W[i].GetUpperBound(0)+1; j++){
					for(int k=0; k<W[i].GetUpperBound(1)+1; k++){
						W[i][j,k] = W[i][j,k] + a[l,0];
						l++;
					}
				}
			}
		}

		void drawCuadraticError(int x, int y, int errorW, int errorH, Bitmap bm, PictureBox pb){
			if(x >= errorW){
				return;
			}
			
			if(y >= errorH){
				y = errorH-1;
			}
			
			for(int i=errorH-1; i>errorH-y; i--){
				bm.SetPixel(x, i, Color.Silver);
			}
			
			pb.Refresh();
		}

		void drawLines(float[,] ws, Bitmap bm, PictureBox pb){
			const int HEIGHT = 100;
			const int WIDTH = 100;
			
			for(int i=0; i<HEIGHT; i++){
				for(int j=0; j<WIDTH; j++){
					bm.SetPixel(j,i,Color.Transparent);
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
				
				using (Graphics gfx = Graphics.FromImage(pb.Image)){
					gfx.DrawLine(new Pen(Color.OrangeRed),
					             (x1*10),
					             (y1*10),
					             (x2*20),
					             (y2*10));
				}
				
			}
			
			pb.Refresh();
		}
	}
}
