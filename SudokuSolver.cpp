#include <iostream>
#include <cstdlib>
#include <cmath>

using namespace std;

int board[9][9] =
{
	{0, 0, 7, 0, 0, 0, 9, 0, 0},
	{0, 0, 0, 0, 1, 0, 4, 7, 2},
	{0, 0, 4, 0, 8, 0, 0, 0, 0},
	{0, 6, 0, 9, 0, 0, 0, 1, 0},
	{0, 0, 0, 0, 0, 0, 0, 3, 0},
	{0, 9, 0, 6, 0, 3, 0, 0, 0},
	{1, 0, 0, 7, 0, 8, 0, 0, 0},
	{7, 0, 0, 0, 0, 6, 0, 0, 0},
	{3, 0, 0, 0, 0, 0, 0, 8, 5}
};

void print(int array[9][9]){
	 for(int i = 1; i < 10; i++){
	 	for(int j = 1; j < 10; j++){
	 		cout << " " << array[i-1][j-1] << " ";
	 		if(j%3 == 0){
	 			cout << "|";
			 }
		 }
		 cout << endl;
		 if(i%3 ==0 && i != 9){
		 	cout << "------------------------------" << endl;
		 }
	 }
}

bool isValid(int array[9][9], int row, int col, int num){
	for(int i = 0; i < 9; i++){
		if(array[row][i] == num && i != col){
		
			return false;
		}
		if(array[i][col] == num && i != row){
			
			return false;
		}
	}
	for(int i = 0; i < 3; i++){
		for(int j = 0; j < 3; j++){
			if(array[3*((row)/3) + i][3*((col)/3) + j] == num){
			
				return false;
			}
		}
	}
	return true;
}

bool isFull(int array[9][9]){
	for(int i = 0; i < 10; i++){
		for(int j = 0; j < 10; j++){
			if(array[i][j] == 0){
				return false;
			}
		}
	}
	return true;
}

bool findNext(int array[9][9], int& row, int& col){
	for(int i = 0; i < 9; i++){
		for (int j = 0; j < 9; j++){
			if(array[i][j] == 0){
				row = i;
				col = j;
				return true;
			}
		}
	}
	
	return false;
}


bool solved(int array[9][9]){
	int row;
	int col;
	if(!findNext(array, row, col)){
		return true;
	}
	
	for(int i = 1; i < 10; i++){
		if(isValid(array, row, col, i)){
			array[row][col] = i;
			if(solved(array)){
				return true;
			}
			else{
				array[row][col] = 0;	
			}
		}	
	}
	return false;
}

/*
	{0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0},
	{0, 0, 0, 0, 0, 0, 0, 0, 0}
	*/


int main(){
	
	solved(board);
	print(board);

}
