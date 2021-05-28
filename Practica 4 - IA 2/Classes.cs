/*
 * Created by SharpDevelop.
 * User: paulo
 * Date: 4/29/2021
 * Time: 12:30 PM
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
	/// Description of Classes.
	/// </summary>
	public class Classes
	{
		public Classes()
		{
		}
		
		public Color getColorClass(int i){
			switch(i){
				case 0:
					return Color.BlueViolet;
					
				case 1:
					return Color.OrangeRed;
					
				case 2:
					return Color.Brown;
					
				case 3:
					return Color.Gold;
					
				case 4:
					return Color.DimGray;
					
				case 5:
					return Color.ForestGreen;
					
				case 6:
					return Color.Coral;
					
				case 7:
					return Color.HotPink;
					
				case 8:
					return Color.IndianRed;
					
				case 9:
					return Color.Khaki;
					
				default:
					return Color.YellowGreen;
			}
		}
	}
}
