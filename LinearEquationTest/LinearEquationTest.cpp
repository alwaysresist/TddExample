#include "pch.h"
#include "CppUnitTest.h"
#include"../Task2/LinearEquation.h";
#include"../Task2/LinearEquation.cpp";
using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace LinearEquationTest
{
	TEST_CLASS(LinearEquationTest)
	{
	public:

		TEST_METHOD(CorrectIndex1)
		{
			vector<double>_a{ 1,2,3,4,5,6 };
			LinearEquation a(_a);
			Assert::AreEqual(4.0, a[3]);
		}
		TEST_METHOD(CorrectIndex2)
		{
			string s = "1, 2, 3, 4, 5, 6, 7";
			LinearEquation a(s);
			Assert::AreEqual(7.0, a[6]);
		}

		TEST_METHOD(CorrectIndex3)
		{
			LinearEquation a(10);
			Assert::AreEqual(0.0, a[5]);
		}
		TEST_METHOD(CorrectMult1)
		{
			string s = "1, 2, 3, 4, 5";
			LinearEquation a(s);
			a = a * 2.0;
			Assert::AreEqual(10.0, a[0]);
		}
		TEST_METHOD(CorrectMult2)
		{
			string s = "4, 5, 6, -7, 4, 2.9, 1,2";
			LinearEquation a(s);
			a = 4.0 * a;
			Assert::AreEqual(11.6, a[5]);
		}

		TEST_METHOD(CorrectSum)
		{
			string s1 = "1, 2, 3, 4, 5, 6, 7";
			string s2 = "7, 6, 5, 4, 3, 2, 1";
			LinearEquation a(s1);
			LinearEquation b(s2);
			LinearEquation res("8, 8, 8, 8, 8, 8, 8");
			Assert::AreEqual(true, res == (a + b));
		}
		TEST_METHOD(CorrectSub)
		{
			string s1 = "1, 2, 3, 4, 5, 6, 7";
			string s2 = "1, 2, 3, 4, 5, 6, 7";
			LinearEquation a(s1);
			LinearEquation b(s2);
			LinearEquation res("0, 0, 0, 0, 0, 0, 0");
			Assert::AreEqual(true, res == (a - b));
		}

		TEST_METHOD(SameInit)
		{
			LinearEquation a(10);
			a.SameInitialization(15.432);
			Assert::AreEqual(15.432, a[6]);
		}

		TEST_METHOD(CorrectUnaryMinus)
		{
			LinearEquation a("-4, -8, -10, -5, 5, -7, -4, -4");
			a = -a;
			Assert::AreEqual(8.0, a[1]);
		}

		TEST_METHOD(CheckContradictoryEquation)
		{
			LinearEquation a("0, 0, 0, -4");
			bool check = (a) ? true : false;
			Assert::AreEqual(false, check);
		}

		TEST_METHOD(FailWithWrongIndexing2)
		{
			auto func = []() {

				LinearEquation a("0, 2, 0, -4");
				double temp = a[-1];
			};
			Assert::ExpectException<std::out_of_range>(func);
		}
		TEST_METHOD(FailWithWrongIndexing1)
		{
			auto func = []() {

				LinearEquation a("0, 2, 0, -4");
				double tmp = a[15];
			};
			Assert::ExpectException<std::out_of_range>(func);
		}

		TEST_METHOD(CheckSolvableEquation)
		{
			LinearEquation a("0, 2, 0, -4");
			bool check = (a) ? true : false;
			Assert::AreEqual(true, check);
		}
		TEST_METHOD(CopyToList)
		{
			LinearEquation a("0, 2, 0, -4");
			list<double> tmp = a;
			Assert::AreEqual(0.0, tmp.front());
		};
	};
}
