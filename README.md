# Visual Studio Live! Orlando - November 2023  

## Description  
This repository contains slides and code samples for sessions presented at Visual Studio Live! Orlando - November 12 - 17, 2023.  

## Sessions  

**VSHOL03 - Hands-On Lab: Asynchronous and Parallel Programming in C#**  
*Level: Intermediate*  

Asynchronous programming is a critical skill to take full advantage of today's multi-core systems. But async programming brings its own set of issues. In this workshop, we'll work through some of those issues and get comfortable using parts of the .NET Task Parallel Library (TPL).  

We'll start by calling asynchronous methods using the Task Asynchronous Pattern (TAP), including how to handle exceptions and cancellation. With this in hand, we'll look at creating our own asynchronous methods and methods that use asynchronous libraries. Along the way, we'll see how to avoid deadlocks, how to isolate our code for easier async, and why it's important to stay away from "async void".  

In addition, we'll look at some patterns for running code in parallel, including using Parallel.ForEachAsync, channels, and other techniques. We'll see pros and cons so that we can use the right pattern for a particular problem.  

Throughout the day, we'll go hands-on with lab exercises to put these skills into practice.  

Objectives:  

* Use asynchronous methods with Task and await  
* Create asynchronous methods and libraries  
* How to avoid deadlocks and other pitfalls  
* Understand different parallel programming techniques  

Pre-Requisites:  

Basic understanding of C# and object-oriented programming (classes, inheritance, methods, and properties). No prior experience with asynchronous programming is necessary; we'll take care of that as we go.  

Attendee Requirements:

* You must provide your own laptop computer (Windows or Mac) for this hands-on lab.

* You need to have the .NET 6 SDK or .NET 7 SDK installed as well as the code editor of your choice (Visual Studio 2022 Community Edition or Visual Studio Code are both good (free) choices).

* Interactive labs, web application samples, and console samples will work with Windows, macOS, and Linux (anywhere .NET 6/7 will run).

* WPF desktop samples will only work on Windows machines. There are equivalent web and console examples for these projects.

Links:

* .NET 7.0 SDK
[https://dotnet.microsoft.com/en-us/download](https://dotnet.microsoft.com/en-us/download)

* Visual Studio 2022 (Community)
[https://visualstudio.microsoft.com/downloads/](https://visualstudio.microsoft.com/downloads/)
Note: Install the "ASP.NET and web development" workload for the labs and samples. Include ".NET desktop development" for "digit-display" sample and WPF-based samples.

* Visual Studio Code
[https://code.visualstudio.com/download](https://code.visualstudio.com/download)

Resources:  
* Slides: [/VSHOL03-hol-async-and-parallel-programming/SLIDES-VSHOL03-hol-async-and-parallel-programming.pdf](./VSHOL03-hol-async-and-parallel-programming/SLIDES-VSHOL03-hol-async-and-parallel-programming.pdf)
* Sample Code: [/VSHOL03-hol-async-and-parallel-programming/](./VSHOL03-hol-async-and-parallel-programming/)  
* Labs (for easy download): [https://github.com/jeremybytes/async-workshop-labs-only-2023](https://github.com/jeremybytes/async-workshop-labs-only-2023)

---  

**VSTH07 - DI Why? Getting a Grip on Dependency Injection**  
*Level: Introductory / Intermediate*  

Many of our modern frameworks have Dependency Injection (DI) built in. But how do you use that effectively? We need to look at what DI is and why we want to use it. We’ll look at the problems caused by tight coupling. Then we’ll use some DI patterns such as constructor injection and property injection to break that tight coupling. We’ll see how loosely-coupled applications are easier to extend and test. With a better understanding of the basic patterns, we’ll remove the magic behind DI containers so that we can use the tools appropriately in our code.  

What you will learn:  
* See the problems that DI can solve  
* Understand DI by using it without a container  
* See how a DI container can add some magic and reduce some code

Resources:  
* Slides: [/VSTH07-dependency-injection/SLIDES-VSTH07-dependency-injection.pdf](./VSTH07-dependency-injection/SLIDES-VSTH07-dependency-injection.pdf)  
* Sample Code: [/VSTH07-dependency-injection/](./VSTH07-dependency-injection/)

---

**VSTH13 - LINQ - It's Not Just for Databases**  
*Level: Introductory / Intermediate*  

LINQ (Language Integrated Query) is mostly associated with Entity Framework and database access. But it can be used for much more. LINQ lets us sort, filter, and aggregate data all in memory without needing to make another database call. We will use the LINQ fluent syntax to combine functions and make a great experience for our users.

What you will learn:  
* Use LINQ methods to sort, filter, and aggregate data  
* Understand the Func parameter commonly used in LINQ methods  
* Use lambda expressions as LINQ parameters  

Resources:  
* Slides [/VSTH13-linq/SLIDES-VSTH13-linq.pdf](./VSTH13-linq/SLIDES-VSTH13-linq.pdf)
* Sample Code [/VSTH13-linq/](./VSTH13-linq/)  

---

