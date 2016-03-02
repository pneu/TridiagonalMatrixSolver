@ECHO OFF

SETLOCAL
SET OLDPATH=%PATH%
CALL "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\Tools\VsDevCmd.bat"

CALL :build
CALL :test
GOTO :finish

:build
msbuild /p:OutputPath=bin\Debug src\MatrixUtility\MatrixUtility.csproj
msbuild /p:OutputPath=bin\Debug src\TridiagonalSolver\TridiagonalSolver.csproj

msbuild /p:OutputPath=bin\Debug test\MatrixUtilityTests\MatrixUtilityTests.csproj
msbuild /p:OutputPath=bin\Debug test\TridiagonalSolverTests\TridiagonalSolverTests.csproj

set BUILDEXITSTATUS=%ERRORLEVEL%
GOTO :eof

:test
mstest /testcontainer:test\MatrixUtilityTests\bin\Debug\MatrixUtilityTests.dll /testcontainer:test\TridiagonalSolverTests\bin\Debug\TridiagonalSolverTests.dll /nologo /usestderr

set TESTEXITSTATUS=%ERRORLEVEL%
GOTO :eof

:finish
SET PATH=%OLDPATH%

ECHO.
ECHO [build] exit status=%BUILDEXITSTATUS%
ECHO [test] exit status=%TESTEXITSTATUS%
IF "%BUILDEXITSTATUS%:::%TESTEXITSTATUS%" == "0:::0" (
  EXIT /b 0
) ELSE (
  EXIT /b 1
)
