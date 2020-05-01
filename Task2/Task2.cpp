#include"SysOfLinearEquation.h"
#include"LinearEquation.h"
#include <iostream>
#include<vector>
#include<ctime>

using namespace std;

int main()
{
	srand(time(NULL));
	int n = 3;
	SysOfLinearEquation s(n);
	LinearEquation a1(3);
	LinearEquation a2(3);
	LinearEquation a3(3);
	a1.RandomInitialization();
	a2.RandomInitialization();
	a3.RandomInitialization();
	s.add(a1);
	s.add(a2);
	s.add(a3);
	cout << (string)s << endl;
	s.StepUp();
	cout << (string)s << endl;
	vector<double> solve = s.Solve();
	for (int i = 0; i < solve.size(); i++)
		cout << solve[i] << "   ";
}

