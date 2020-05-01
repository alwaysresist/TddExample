#include "SystemLinearEquation.h"
#include<stdexcept>

LinearEquation& SystemLinearEquation::operator[](int index)
{
	if (index >= 0 && index < system.size())
		return system[index];
	else throw std::out_of_range("Out of range!");
}
int SystemLinearEquation::size()
{
	return system.size();
}
void SystemLinearEquation::add(LinearEquation& a)
{
	if (a.size() == n + 1)
		system.push_back(a);
	else throw std::invalid_argument("Invalid argument!");
}
void SystemLinearEquation::remove()
{
	system.pop_back();
}
void SystemLinearEquation::steppingUp()
{
	int c, z;
	for (int i = 0; i < size(); i++)
	{
		z = i;
		if (system[i][z] == 0)
		{
			while (system[i][z] == 0 && z < n) z++;//find not zero coefficient in equation
			c = 1;
			while ((i + c) < size() && system[i + c][z] == 0) c++;
			if ((i + c) == size())//last equation
			{
				return;
			}
			swap(system[i], system[i + c]);//swap to get a stepped look
		}
		for (int j = i + 1; j < size(); j++)
		{
			LinearEquation tmp1 = system[j] * system[i][z];
			LinearEquation tmp2 = system[i] * system[j][z];
			system[j] = tmp1 - tmp2;
		}
	}
}
vector<double> SystemLinearEquation::solveSystem()
{
	while (system[size() - 1].isNull())
		system.pop_back();
	if (system[size() - 1])
	{
		if (size() == n)
		{
			vector<double> solve(n);
			for (int i = size() - 1; i >= 0; i--)
			{
				solve[i] = system[i][n];//take free member
				for (int j = i + 1; j < n; j++)
				{
					solve[i] -= system[i][j] * solve[j];
				}
				solve[i] /= system[i][i];
			}
			return solve;
		}
		else throw std::invalid_argument("The system has infinitely many solutions!");
	}
	else throw std::invalid_argument("The system has no solutions!");
}
SystemLinearEquation::operator std::string()
{
	string res = "";
	for (int i = 0; i < size(); i++)
		res += (string)system[i] + '\n';
	return res;
}