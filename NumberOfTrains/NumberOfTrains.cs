using System;
using System.Linq;
		
public class Program
{
	public static void Main()
	{
		int rows; int cols;
		string line = Console.ReadLine();
		string[] args = line.Split(' ');
		rows = Convert.ToInt32(args[0]);
		cols = Convert.ToInt32(args[1]);
		Console.WriteLine(rows);
		Console.WriteLine(cols);
		int[][] parkingBase = new int[rows][];
		bool[][] visited = new bool[rows][];
		
		for(int i =0;i<rows;i++)
		{
			string row = Console.ReadLine();
			int[] rowValues = row.Split(' ').Select(int.Parse).ToArray();
			parkingBase[i] = new int[cols];
			visited[i] = new bool[cols];
			for(int j = 0; j <cols;j++)
			{
				visited[i][j] = false;
				parkingBase[i][j] = rowValues[j];
			}
		}
		Console.WriteLine();
		DisplayMatrix(parkingBase, rows, cols);
		Console.WriteLine("***********************************************************");
		int result = CountTrains(parkingBase, rows, cols, visited);
		Console.WriteLine("Result = " + result);
		
	}
	
	public static int CountTrains(int[][] mat, int rows, int cols, bool[][] visited)
	{
		int count = 0;
		for(int i=0;i<rows;i++)
		{
			for(int j = 0; j <cols;j++)
			{
				if(!IsVisited(visited, i,j) && mat[i][j] == 1)
				{
					var trainAxis = CheckTrainIsHorizontalOrVertical(mat,i,j,visited);
					if(trainAxis == TrainEnum.Horizontal)
					{
						count++;
						FollowHorizontalPath(mat, i, j, visited);
					}
					else if(trainAxis == TrainEnum.Vertical)
					{
						count++;
						FollowVerticalPath(mat, i, j, visited);
					}
					else
					{
						count++;
					}
				}
				else
				{
					MarkVisited(i,j,visited);
				}
			}
		}
		
		return count;
	}
	
	public static void FollowHorizontalPath(int[][] mat, int row, int col, bool[][] visited)
	{
		Console.WriteLine("FollowHorizontalPath Row = "+row+", Column = "+col);
		for(int i = col+1; i < mat[0].Length; i++)
		{
			if(mat[row][i] == 1 && !IsVisited(visited, row, i))
			{
				MarkVisited(row, i, visited);
			}
			else return;
		}
	}
	
	public static void FollowVerticalPath(int[][] mat, int row, int col, bool[][] visited)
	{
		Console.WriteLine("FollowVerticalPath Row = "+row+", Column = "+col);
		for(int i = row+1; i < mat.Length; i++)
		{
			if(mat[i][col] == 1 && !IsVisited(visited, i, col))
			{
				MarkVisited(i, col, visited);
			}
			else return;
		}
	}
	
	public static void MarkVisited(int row, int col, bool[][] visited)
	{
		visited[row][col] = true;
	}
	
	public static TrainEnum CheckTrainIsHorizontalOrVertical(int[][] mat, int row, int col, bool[][] visited)
	{
		Console.WriteLine("Row = "+row+", Column = "+col);
		if(row >= 0 && row < mat.Length && col+1 >= 0 && col+1 < mat[0].Length)
		{
			int right = mat[row][col+1];
			if(right == 1 && !visited[row][col+1])
			{
				return TrainEnum.Horizontal;
			}
		}
		
		if(row+1 >= 0 && row+1 < mat.Length && col >= 0 && col < mat[0].Length)
		{
			int bottom = mat[row+1][col];
			if(bottom == 1 && !visited[row+1][col])
			{
				return TrainEnum.Vertical;
			}
		}
		return TrainEnum.None;
	}
	
	public static bool IsVisited(bool[][] visited, int row, int col)
	{
		return visited[row][col];
	}
	
	public static void DisplayMatrix(int[][] mat, int rows, int cols)
	{
		for(int i =0;i<rows;i++)
		{
			for(int j = 0; j <cols;j++)
			{
				Console.Write(mat[i][j]+" ");
			}
			Console.WriteLine();
		}
	}
	public enum TrainEnum{Horizontal, Vertical, None}
}
