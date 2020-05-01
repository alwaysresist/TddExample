#pragma once
class Indexer
{
private:
	double *arr;
	int begin;
	int length;
	bool CheckArguments(int,int,int);
	bool CheckIndex(int, int, int);

public:
	Indexer(double *arr,int,int,int);
	~Indexer() {}
	int getLength() { return length; }
	double& operator[] (int index);
	
};

