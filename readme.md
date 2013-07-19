#The Problem

> Write a number prettifier: Write tested code (in C#) that accepts an integer type and returns a truncated, "prettified" string version. The prettified version should include one number after the decimal when the truncated number is not an integer. It should prettify numbers greater than 6 digits and support millions, billions and trillions.

**Examples**

    input: 1000000
    output: 1M
 
    input: 2500000.34
    output: 2.5M
 
    input: 532
    output: 532
 
    input: 1123456789
    output: 1.1B

#Introduction

> A couple of years ago I was explaining some of my code to Keith and he mentioned that my situation might be a good application for the Chain of Responsibility (CoR) pattern. At that time I dug into Design Patters as the next logical step in my development, but in the end I decided against CoR for that particular application. When this challenge was given to me, I remembered the conversation and decided to use CoR to solve the problem. I had to brush up a little, but in the end, I'm happy with the result.

#The Approach

> I'm using a `Console Application` to initialize the Chain and build out the successors.

> Each Prettifier is abstracted away from the other using a common `PrettificationHandler`. Each prettifier implements two methods [`HandleRequest`, and `ShouldHandleRequest`]. Many other CoR examples put the "Should" logic right inside the primary method using an `if` statement, but I believe that it is far more testable and cleaner if the "Should" logic is broken out.

> I've written a number of tests to prove that the chain works. The tests are written using NUnit, and the test runners are included within the repository.

> The `Build.bat` is what you will run in order to build the application. I chose to use a Batch file to launch the Powershell Script in order to avoid possible `ExecutionPolicy` issues that could arise on a different machine where the user could forget to run `Set-ExecutionPolicy Unrestricted`.  
> The entire build logic is located in `./Secure.Build/Build.ps1`.

> *note: the original challenge said to use an `Integer`, However `int.MaxValue = 2,147,483,647`, and therefore is too large to be handled by the `BillionNumberPrettifier` and the `TrillionNumberPrettifier`.*

#So Now You Want To Run It!?
**prerequisites:** 

  - [posh-git](https://github.com/dahlbyk/posh-git "posh-git"), or some other git client  
  - .NET framework V4.0 or higher
  - Powershell v2 or higher

**STEP 1:** launch powershell and run the following 4 lines.

    > cd /path/to/where/you/want/to/test/
    > git clone https://github.com/ChaseFlorell/SecurePrettifier.git
    > cd SecurePrettifier
    > cmd /c build

**STEP 2:** sit back and watch the magic.