using System;

/// <summary>
/// Convert.ToChar(SByte)
/// Converts the value of the specified 8-bit signed integer to its equivalent Unicode character. 
/// </summary>
public class ConvertTochar
{
    public static int Main()
    {
        ConvertTochar testObj = new ConvertTochar();

        TestLibrary.TestFramework.BeginTestCase("for method: Convert.ToChar(SByte)");
        if(testObj.RunTests())
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("PASS");
            return 100;
        }
        else
        {
            TestLibrary.TestFramework.EndTestCase();
            TestLibrary.TestFramework.LogInformation("FAIL");
            return 0;
        }
    }

    public bool RunTests()
    {
        bool retVal = true;

        TestLibrary.TestFramework.LogInformation("[Positive]");
        retVal = PosTest1() && retVal;
        retVal = PosTest2() && retVal;
        retVal = PosTest3() && retVal;

        TestLibrary.TestFramework.LogInformation("[Negative]");
        retVal = NegTest1() && retVal;

        return retVal;
    }

    #region Positive tests
    public bool PosTest1()
    {
        bool retVal = true;
        string errorDesc;

        SByte i;
        char expectedValue;
        char actualValue;

        i = (SByte)(TestLibrary.Generator.GetByte(-55) % (SByte.MaxValue + 1));

        TestLibrary.TestFramework.BeginScenario("PosTest1: SByte value between 0 and SByte.MaxValue.");
        try
        {
            actualValue = Convert.ToChar(i);
            expectedValue = (char)i;
            if (actualValue != expectedValue)
            {
                errorDesc = string.Format(
                    "The character corresponding to SByte value {0} is not \\u{1:x} as expected: actual(\\u{2:x})", 
                    i, (int)expectedValue, (int)actualValue);
                TestLibrary.TestFramework.LogError("001", errorDesc);
                retVal = false;
            }
        }
        catch (Exception e)
        {
            errorDesc = "Unexpect exception:" + e;
            errorDesc += "\nThe SByte value is " + i;
            TestLibrary.TestFramework.LogError("002", errorDesc);
            retVal = false;
        }
        return retVal;
    }

    public bool PosTest2()
    {
        bool retVal = true;
        string errorDesc;

        SByte i;
        char expectedValue;
        char actualValue;

        i = SByte.MaxValue;

        TestLibrary.TestFramework.BeginScenario("PosTest2: SByte value is SByte.MaxValue.");
        try
        {
            actualValue = Convert.ToChar(i);
            expectedValue = (char)i;
            if (actualValue != expectedValue)
            {
                errorDesc = string.Format(
                    "The character corresponding to SByte value {0} is not \\u{1:x} as expected: actual(\\u{2:x})",
                    i, (int)expectedValue, (int)actualValue);
                TestLibrary.TestFramework.LogError("003", errorDesc);
                retVal = false;
            }
        }
        catch (Exception e)
        {
            errorDesc = "Unexpect exception:" + e;
            errorDesc += "\nThe SByte value is " + i;
            TestLibrary.TestFramework.LogError("004", errorDesc);
            retVal = false;
        }
        return retVal;
    }

    public bool PosTest3()
    {
        bool retVal = true;
        string errorDesc;

        SByte i;
        char expectedValue;
        char actualValue;

        i = 0;

        TestLibrary.TestFramework.BeginScenario("PosTest3: SByte value is zero.");
        try
        {
            actualValue = Convert.ToChar(i);
            expectedValue = (char)i;
            if (actualValue != expectedValue)
            {
                errorDesc = string.Format(
                    "The character corresponding to SByte value {0} is not \\u{1:x} as expected: actual(\\u{2:x})",
                    i, (int)expectedValue, (int)actualValue);
                TestLibrary.TestFramework.LogError("005", errorDesc);
                retVal = false;
            }
        }
        catch (Exception e)
        {
            errorDesc = "Unexpect exception:" + e;
            errorDesc += "\nThe SByte value is " + i;
            TestLibrary.TestFramework.LogError("006", errorDesc);
            retVal = false;
        }
        return retVal;
    }
    #endregion

    #region Negative tests
    //OverflowException
    public bool NegTest1()
    {
        bool retVal = true;

        const string c_TEST_ID = "N001";
        const string c_TEST_DESC = "NegTest1: SByte value is a negative integer between SByte.MinValue and -1.";
        string errorDesc;

        SByte i = (SByte)(-1 * TestLibrary.Generator.GetByte(-55) % (SByte.MaxValue + 1) - 1);

        TestLibrary.TestFramework.BeginScenario(c_TEST_DESC);
        try
        {
            Convert.ToChar(i);

            errorDesc = "OverflowException is not thrown as expected.";
            errorDesc += string.Format("\nThe SByte value is {0}", i);
            TestLibrary.TestFramework.LogError("007" + " TestId-" + c_TEST_ID, errorDesc);
            retVal = false;

        }
        catch (OverflowException)
        { }
        catch (Exception e)
        {
            errorDesc = "Unexpected exception: " + e;
            errorDesc += string.Format("\nThe SByte value is {0}", i);
            TestLibrary.TestFramework.LogError("008" + " TestId-" + c_TEST_ID, errorDesc);
            retVal = false;
        }

        return retVal;
    }
    #endregion
}
