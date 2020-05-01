#pragma once
#include"LinearEquation.h"
#include<string>
class SysOfLinearEquation
{
private:
	vector<LinearEquation> system;
	int n;
public:
	SysOfLinearEquation(int _n) :n(_n) {}
	~SysOfLinearEquation() { vector<LinearEquation>().swap(system); }
	LinearEquation& operator[] (int index);
	int size();
	void add(LinearEquation&);
	void remove();
	void StepUp();
	vector<double> Solve();
	operator std::string();
};

