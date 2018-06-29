# PropertySetterTest

This project should demonstrate a bug discovered in **Visual Studio 2017** that occurs when you examine a variable in the **Locals** tab.

## Environment

- Windows 10 Pro
- Visual Studio 2017 v15.7.4
- No extensions

## Repro Instructions

Please use the following instructions to reproduce the bug:

1. Insert a breakpoint at **PropertySetterTest.sln > Test.cs > Line 22** *(The line that reads `_string = value;`)*
2. *Once the breakpoint is in place:* Run the app and let it hit the breakpoint
3. *Once the breakpoint is hit:* Hit **F10** once to step to the next line
4. ***IMPORTANT (bug is triggered by this action)***: Examine **value** and **this > _string** in the **Locals** tab *(**_string** != **value** for some reason...)*
5. Hit **Continue** to finish executing the app
6. Notice that **Program.RunTest() > Child.Test()** returns **false**; indicating a test failure
7. Disable all breakpoints
8. Run the app again
9. Notice that **Program.RunTest() > Child.Test()** returns **true**; indicating a test success

## Expected Behavior

I expected **_string** to be set to **value** in the **String** property's setter, even after examining **_string**'s value via the **Locals** tab in Visual Studio.

## Actual Behavior

Examining the **_string** variable prevents it from being set to **value**- which doesn't happen if you do not examine the value in the **Locals** tab during execution.

## Additional Information

If you remove the **_storage** variable from the **Test** class- the bug does not occur.
