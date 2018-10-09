// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#include "platformdefines.h"

WCHAR strManaged[] = W("Managed\0String\0");
size_t lenstrManaged = sizeof(strManaged) - sizeof(WCHAR);

WCHAR strReturn[] = W("a\0\0\0\0\0\0\0\0\0\0\0\0\0\0\0");
WCHAR strerrReturn[] = W("error");

WCHAR strNative[] = W(" Native");
size_t lenstrNative = sizeof(strNative) - sizeof(WCHAR);

typedef struct Person Person;
struct Person{
    int age;
    int _pedding;
    BSTR name;
};

extern "C" DLL_EXPORT BOOL Marshal_Struct_In(Person person)
{
    if (person.age != 12)
    {
        printf("Error in Marshal_Struct_In, The value for age field is incorrect\n");
        return FALSE;
    }

    size_t len = TP_SysStringByteLen(person.name);
    if (len != lenstrManaged || memcmp(person.name, strManaged, lenstrManaged) != 0)
    {
        printf("Error in Marshal_Struct_In, The value for name field is incorrect\n");
        return FALSE;
    }

    return TRUE;
}
