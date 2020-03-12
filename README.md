# TeacherComputerRetrieval

Prerequisites
--
Visual Studio (2019 preferred)
.Net Framework 4.5.1 or higher

Setup Instructions
--
Clone the repository using Git on your desktop (or) Download the repository as ZIP.
You might have to install NUnit 3 Test Adapter extension for Visual Studio in order to run tests.

Open the solution in Visual Studio (2019 preferred) and build solution.
Navigate to the build directory (/bin/Release)
The application expects an input file to read input from. This path has to be configured in App.config for the key "InputFilePath". Add absolute path to input file as value for this key.
Open the executable TeacherComputerRetrieval.exe to find answers to the questions asked in the test.

Assumptions
--
The input file exists at the path specified and each line of file contains a valid route (AB5, BC4 etc.,)
The first two letters of the route are uppercase letters.

Tests
--
If NUnit 3 Test Adapter extension is installed, click on the 'Test' button on Visual Studio's ribbon and run all tests.
Since the requirements are not fully implemented, many test cases should fail.

Code & Logic explanation
--
To keep this read me section short and for convenience of the reviewer, the comments are included in code accordingly.

-- **Thank you.**
