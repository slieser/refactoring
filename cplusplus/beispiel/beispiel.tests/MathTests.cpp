#include "stdafx.h"
#include "CppUnitTest.h"
#include "../beispiel/Math.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace beispieltests
{		
	TEST_CLASS(MathTests)
	{
	public:
		
		TEST_METHOD(Add_2_3)
		{
			int result = Math::Add(2, 3);

			Assert::AreEqual(5, result);
		}

	};
}