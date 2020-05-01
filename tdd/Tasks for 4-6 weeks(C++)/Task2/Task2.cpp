// Task2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//
#include"SystemLinearEquation.h"
#include"LinearEquation.h"
#include <iostream>
#include<vector>
#include<ctime>
using namespace std;

int main()
{
	srand(time(NULL));
	int n = 3;
	SystemLinearEquation s(n);
	LinearEquation a1(3);
	LinearEquation a2(3);
	LinearEquation a3(3);
	a1.random_initialization();
	a2.random_initialization();
	a3.random_initialization();
	s.add(a1);
	s.add(a2);
	s.add(a3);
	cout << (string)s << endl;
	s.steppingUp();
	cout << (string)s << endl;
	vector<double> solve = s.solveSystem();
	for (int i = 0; i < solve.size(); i++)
		cout << solve[i] << "   ";
}

