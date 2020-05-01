#include "Indexer.h"
#include<stdexcept>
#include<exception>
Indexer::Indexer(double* arr, int arrLength, int begin, int length)
{
	if (CheckArguments(arrLength, begin, length)) {
		this->arr = arr;
		this->begin = begin;
		this->length = length;
	}
	else 
		throw std::invalid_argument("Недопустимое значение.");
}
double& Indexer::operator[](int index)
{
	if (CheckIndex(begin, length, index))
		return arr[begin + index];
	else 
		throw std::out_of_range("Недопустимое значение.");
}
bool Indexer::CheckArguments(int arrLength, int begin, int length)
{
	if (begin<0 || length <= 0 || begin + length>arrLength) 
		return false;
	else 
		return true;
}
bool Indexer::CheckIndex(int begin, int length, int index)
{
	if (index<0 || index + begin>length) 
		return false;
	else 
		return true;
}

