#include "pch.h"
#include "CppUnitTest.h"
#include <stdexcept>
#include "../Task1/Indexer.cpp"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace IndexerTestCpp
{
	TEST_CLASS(IndexerTestCpp)
	{
	private:
		double* array = new double[4]{ 1, 2, 3, 4 };
	public:

		TEST_METHOD(HaveCorrectLength)
		{
			auto indexer = Indexer(array, 4, 1, 2);
			Assert::AreEqual(2, indexer.getLength());
		}
		TEST_METHOD(GetCorrectly)
		{
			auto indexer = Indexer(array, 4, 1, 2);
			Assert::AreEqual((double)2, indexer[0]);
			Assert::AreEqual((double)3, indexer[1]);
		}
		TEST_METHOD(SetCorrectly)
		{
			auto indexer = Indexer(array, 4, 1, 2);
			indexer[0] = 10;
			Assert::AreEqual((double)10, array[1]);
		}
		TEST_METHOD(IndexerDoesNotCopyArray)
		{
			auto indexer1 = Indexer(array, 4, 1, 2);
			auto indexer2 = Indexer(array, 4, 0, 2);
			indexer1[0] = 100500;
			Assert::AreEqual((double)100500, indexer2[1]);
		}
		TEST_METHOD(FailWithWrongArguments1)
		{
			Assert::ExpectException<std::invalid_argument>([&] { Indexer(array, 4, -1, 3); });

		}
		TEST_METHOD(FailWithWrongArguments2)
		{
			Assert::ExpectException<std::invalid_argument>([&] { Indexer(array, 4, 1, -1); });

		}
		TEST_METHOD(FailWithWrongArguments3)
		{
			Assert::ExpectException<std::invalid_argument>([&] { Indexer(array, 4, 1, 10); });
		}
		TEST_METHOD(FailWithWrongIndexing1)
		{
			auto indexer = Indexer(array, 4, 1, 2);
			Assert::ExpectException<std::out_of_range>([&] { indexer[-1]; });
		}
		TEST_METHOD(FailWithWrongIndexing2)
		{
			auto indexer = Indexer(array, 4, 1, 2);
			Assert::ExpectException<std::out_of_range>([&] { indexer[10]; });
		}
	};
}