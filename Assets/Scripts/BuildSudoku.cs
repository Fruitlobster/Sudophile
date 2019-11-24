using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO template on grid size?
public static class BuildSudoku
{
  public static int[] Build(){
    int[] grid = new int[81];
    int[] nums = {1,2,3,4,5,6,7,8,9};
    List<int> idcs = new List<int>();
    
    for(int i=0;i<grid.Length;i++){
      idcs.Add(i);
    }
    
    while(idcs.Count !=0){
      int randGridIdx = UnityEngine.Random.Range(0, grid.Length);
      int randNumIdx = UnityEngine.Random.Range(0, nums.Length);
      idcs.Remove(randGridIdx);
      int numToSet = nums[randNumIdx];
      bool bNumOk = bPlacementOK(numToSet, grid);
      while(!bNumOk){
        randNumIdx = UnityEngine.Random.Range(0, nums.Length);
        numToSet = nums[randNumIdx];
        bNumOk = bPlacementOK(numToSet, grid);
      }
      grid[randGridIdx] = numToSet;
      
    }
    


    return grid;
  }

// private static bool buildGrid(int[] grid, int[] nums, System.Random rand, int recursionDepth){
//   for (int i=0; i < grid.Length; ++i) {
//       int row = i/9;
//       int col = i%9;
//       // if cell is 0 assign it a random number
//       if(grid[i] == 0){
//         int propEntry = nums[rand.Next(nums.Length)];
        
//         // check if assigned number is admissible
//         // find index of proposed number if number is already in grid
//         int IdxToCheck = Array.FindIndex(grid, (gridEntry)=>{return gridEntry == propEntry;});
//         if(IdxToCheck != -1){
//           // if propEntry is already in grid, check if its in the row, column or 3x3 block of index i
//           int RowToCheck = IdxToCheck/9;
//           int ColToCheck = IdxToCheck%9;
//           if(RowToCheck == row || ColToCheck == col || bIsInBlock(row, col, RowToCheck, ColToCheck)){
//             grid[i] = 0;
//             int d = recursionDepth+1;
//             grid = buildGrid(grid, nums, rand, d);
//           }
//         }else{
//           grid[i] = propEntry;
//         }
//       }else{
//         if(!bGridFull(grid)){
//           int d = recursionDepth+1;
//           grid = buildGrid(grid, nums, rand,d);
          
//         }
//       }
//     }
//     return grid;
// }

private static bool bIsInBlock(int currRow, int currCol, int checkRow, int checkCol){
  return (Math.Abs(checkRow-currRow)<=2) && (Math.Abs(checkCol-currCol)<=2);
}
  /// <summary>
  /// Check if grid is fully populated, i.e. no value is 0.
  /// </summary>
  /// <param name="grid">The grid to check.</param>
  /// <returns>True if no entry in grid is equal to 0, false otherwise.</returns>
  private static bool bGridFull(int[] grid){
    foreach(int cell in grid){
      if(cell == 0){
        return false;
      }
    }
    return true;
  }

private static void PrintGrid(int[] grid){
  for(int i=0; i<81; i++){
 	int row = i/9;
	int col = i%9;
 	if((i+1)%9!=0){
		Debug.Log(grid[i] + " ");
	}else{
		Debug.Log(grid[i] + "\n");
	}
 }
}

private static void logArray(int[] arr){
  string dbgString = "";
    foreach (var item in arr)
    {
      dbgString += item.ToString()+" ";
    }
    Debug.Log(dbgString);
}

private static void shuffleArray(int[] arr, int numShuffles=20){
  int passes = numShuffles*arr.Length;
  int forwardIdx = 0;
  for(int i=0;i<passes;i++){
    if(forwardIdx >= arr.Length){
      forwardIdx = 0;
    }
    int rndIdx = UnityEngine.Random.Range(0, arr.Length);
    int temp = arr[forwardIdx];
    arr[forwardIdx] = arr[rndIdx];
    arr[rndIdx] = temp;
    forwardIdx+=1;  
  }
}

private static void changeArr(int[] arr){
  arr[4] = 69;

}

  ///<summary>
  /// Generates indices of the rows and columns of a square grid:
  /// <para/>Usage: 
  ///         <para/>var myDict = generateRowColIndices(4);
  ///         <para/>int[] idcsRow0 = myDict["row"][0]
  ///</summary>
  ///<returns>
  /// Dictionary with keys "row" and "col" whose values are Lists of integer arrays
  /// containing the indices for the row or column indexed by the List index.
  ///</returns>
  ///<param name="gridSize">Size of the square grid to generate indices.</param>
  private static Dictionary<string,List<int[]>> generateRowColIndices(int gridSize){
    int[,] colIdcs = new int[gridSize,gridSize];
		int[,] rowIdcs = new int[gridSize,gridSize];
    // generate column indices
    for(int i=0;i<gridSize;i++){
			for(int j=0; j<gridSize; j++){
				colIdcs[i,j] = j*gridSize+i;
			}
		}
		// generate row indices
		for(int i=0;i<gridSize;i++){
			for(int j=0; j<gridSize; j++){
				rowIdcs[i,j] = colIdcs[j,i];
			}
		}
    List<int[]> rowIdxList = new List<int[]>();
		List<int[]> colIdxList = new List<int[]>();
		for(int i = 0; i<gridSize;i++){
			rowIdxList.Add(new int[gridSize]);
			colIdxList.Add(new int[gridSize]);
		}
		for(int i=0; i<gridSize; i++){
			for(int j=0; j<gridSize; j++){
				rowIdxList[i][j] = rowIdcs[i,j];
				colIdxList[i][j] = colIdcs[i,j];
			}
		}
		return new Dictionary<string,List<int[]>>(){
			{"row", rowIdxList},
			{"col", colIdxList}
		};
  }





}
