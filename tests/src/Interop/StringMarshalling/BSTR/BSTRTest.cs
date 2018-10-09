// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;
using System;
using System.Reflection;
using System.Text;
using NativeDefs;
using System.Diagnostics;

class Test
{

    #region "Report Failure"
    static int fails = 0; //record the fail numbers
    // Overload methods for reportfailure	
    static int ReportFailure(string s)
    {
        Console.WriteLine(" === Fail:" + s);
        return (++fails);
    }
    static int ReportFailure(string expect, string actual)
    {
        Console.WriteLine(" === Fail: Expected:" + expect + "\n          Actual:" + actual);
        return (++fails);
    }
    static int ReportFailure(string describe, string expect, string actual)
    {
        Console.WriteLine(" === Fail: " + describe + "\n\tExpected:" + expect + "\n\tActual:" + actual);
        return (++fails);
    }
    #endregion

    #region "Helper"
    // ************************************************************
    // Returns the appropriate exit code
    // *************************************************************
    static int ExitTest()
    {
        if (fails == 0)
        {
            Console.WriteLine("PASS");
            return 100;
        }
        else
        {
            Console.WriteLine("FAIL - " + fails + " failure(s) occurred");
            return 101;
        }
    }
    #endregion

    #region "Struct"
    static void TestStructIn()
    {
        string strManaged = "Managed\0String\0";
        Person person = new Person();
        person.age = 12;
        person.name = strManaged;
        if (!PInvokeDef.Marshal_Struct_In(person))
        {
            ReportFailure("Method PInvokeDef.Marshal_Struct_In[Managed Side],The native return false");
        }
    }

    #endregion

    public static int Main(string[] args)
    {
	TestStructIn();
        return ExitTest();
    }
}
