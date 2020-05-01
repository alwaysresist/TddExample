// Task1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include"Indexer.h"
#include <cassert>
using namespace std;
int main()
{
	double* arr = new double[4]{ 1, 2, 3, 4 };
	Indexer indexer1(arr,4, 1, 2);
	Indexer indexer2(arr,4, 0, 2);
	indexer1[0] = 100500;
	for (int i = 0; i < 4; i++)
	{
		std::cout << indexer2[i] << std::endl;
	}
	assert(100500.0 == indexer2[1]);
}

