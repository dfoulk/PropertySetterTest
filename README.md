# PropertySetterTest

## Instructions

Please use the following instructions to reproduce the bug in Visual Studio.

1. Insert a breakpoint at **PropertySetterTest.sln > Test.csproj > Child.cs > Line 46** *(The line that reads **"_networkCredential = value;"**)*
2. *Once the breakpoint is in place:* Run the app and let it hit the breakpoint
3. *Once the breakpoint is hit:* Hit **F10** once to step to the next line
4. ***IMPORTANT (bug is triggered by this action)***: Examine **value** and **this > _networkCredential** in the **Locals** tab (_networkCredential != value for some reason?)
5. Hit **Continue** to finish executing the app
6. Notice that **Program.RunTest() > Child.Test()** returns **false**; indicating a test failure
7. Disable all breakpoints
8. Run the app again
9. Notice that **Program.RunTest() > Child.Test()** returns **true**; indicating a test success
10. Try to wipe the confused look off your face
