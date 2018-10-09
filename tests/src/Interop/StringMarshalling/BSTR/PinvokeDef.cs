// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Runtime.InteropServices;
using System;
using System.Reflection;
using System.Text;

namespace NativeDefs
{
    public struct Person
    {
        public int age;
	public int _pedding;
        [MarshalAs(UnmanagedType.BStr)]
        public string name;
    }

    public static class PInvokeDef
    {
        public const string NativeBinaryName = "BSTRTestNative";

        [DllImport(NativeBinaryName)]
        public static extern bool Marshal_Struct_In(Person person);

    }
}
