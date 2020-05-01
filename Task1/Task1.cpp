#include <iostream>
#include"Indexer.h"
#include <cassert>
using namespace std;
int main()
{
	double* arr = new double[4]{ 1, 2, 3, 4 };
	Indexer indexer1(arr,4, 1, 2);
	Indexer indexer2(arr,4, 0, 2);
	indexer1[0] = 1000000;
	for (int i = 0; i < 4; i++)
	{
		std::cout << indexer2[i] << std::endl;
	}

	assert(1000000.0 == indexer2[1]);
}

