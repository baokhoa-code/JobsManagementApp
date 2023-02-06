<div id="Top"></div>

# JobsManagementApp
This is an app for manage your jobs, tasks.

## Index

 [I. Introduction](#intro)

 [II. Description](#descript)

> [1. Idea](#idea)
>
> [2. Techonlogy](#tech)
>
> [3. Target User](#user)
>
> [4. Goal](#goal)
>
> [5. Function](#funct)

[III. Author](#auth)

[IV. Summary](#sum)

<div id="intro"></div>

## I. Introduction
The assignment and work management is an important factor that allows created leaders in the field of education to easily run the organization's activities. This also helps lecturers look up work calendar and personal work.
However, the work assignment is complicated because it is difficult to access information about the type of work and the working schedule of the individual. In addition, looking up reports and making performance charts is also very time -consuming.
From the above reasons, I would like to propose solutions to use the application of work management to the assignment of educational organizations.

<div id="descript"></div>

## II. Description

<div id="idea"></div>

### 1. Idea
* Towards improving the user experience, using WPF technology, the XamL language meets the demanding requirements, newer, more modern and intuitive interface, in accordance with current standards. , programming language is easy to understand, easy to access, easy to create and edit GUI.

* Use MVVM model to separate the interface and process, increase the ability to re -use the components or changes in the program interface without having to rewrite the code too much, can develop the application quickly, Easy to upgrade, maintain, expand or repair.

* Multithreading in the direction of hardware, increasing processing speed and improving application speed.

* Use MD5 encryption technique in user account management to ensure security during use, reduce maximum damage when unfortunately lost data to the outside.

<div id="tech"></div>

### 2. Techonlogy
* API system: WPF - MVVM model
* IDE: Visual Studio 2022 (C#/Net)
* Database: SQL Database
* Management tool: git, github


<div id="user"></div>

### 3. Target User
* Applications towards objects are organizations in the educational environment. The application is applied to all small and medium -sized organizations, in need of applying information technology to work management.
* Scope of research: In addition to learning about applications, if you want to apply well, we need to build in the system environment with many support and popularity, namely Windows operating system.

<div id="goal"></div>

### 4. Goal

 * <strong>Practical application</strong>
 
   * Meeting the requirements of customers, the system is highly stable, easy to use, does not cause difficulties for users.
   * Widely used in organizations, replacing old applications is still limited, outdated interface or forms of management according to traditional crafts, which are bulky, difficult to manage and easily lead to. The errors are not worth it.
   * Becoming one of the applications that customers choose, trust and use.


 * <strong>Application requirements</strong>
 
    * Meet the standard features required on existing work management applications on the market. In addition, expanding and developing new features to maximize users, automation of stages and work management operations, overcoming the limitations and weaknesses of the current management system .
    
    * Improve accuracy and security in business, user information management.
    
    * Making reports, statistics, data updates, and synchronization between computers must take place quickly and accurately.
    
    * Easy to look up, search for information related to work, work reports.
    
    * Friendly interface, easy to use, reasonable layout, harmonious color and high uniformity, decentralization for users through account.
    
    * Applications must be compatible with most popular operating systems such as Window Vista SP1, Windows 8.1, Window 10, ... Especially, the application during use must operate stably, avoiding fields The conflict error occurs with the system that causes discomfort for users during use. The expansion and upgrade of applications later must be easy when users need.
    
<div id="funct"></div>

### 5. Function
* Login management, support account recovery for users when forgetting passwords.

* Admin:
  * Manage, add, delete, edit the information of the admin.
  * Manage, add, delete, edit information of lecturers.
  * Manage, add, delete, edit the type of job.
  * Manage, add, delete, edit the work information of each lecturer.
  * Manage, add, delete, edit the job information of the admin.
  * Manage, add, delete, edit information lists for completion progress.
  * See the pouring schedule showing the operational capacity of the lecturers.
  * See the current job list.
  * See today's job list.
  * See the list of overdue work.
  * Make a report on the work progress of the admin.
* User:
  * Manage, add, delete, edit the information of the lecturer itself.
  * Manage, add, delete, edit the job information of the lecturer itself.
  * Manage, add, delete, edit information listing reports on the completion of the work of the lecturer itself.
  * See the reflection of the operational capacity of the lecturer itself.
  * See the current job list.
  * See today's job list.
  * See the list of overdue work.
  * Make a report on the work progress of the lecturer itself.
  * Make a report for each completed work of the lecturer.

<div id="auth"></div>
#install xampp, mysql, import './Database/auto.sql'

#install .NET 6.0 Desktop Runtime 
	https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-6.0.11-windows-x64-installer?cid=getdotnetcore

#if visual code studio 2022 is not installed
	run './JobsManagementApp/bin/Debug/net6.0-windows/JobsManagementApp.exe'

#if visual code studio 2022 is installed
	open './JobsManagementApp.sln'
	in solution exploere, right click 'Solution 'JobsManagementApp', choose 'Clean Solution'
	in solution exploere, right click 'Solution 'JobsManagementApp', choose 'Build Solution'
	in handle bar click run build button to execute app.

#github repository link
	https://github.com/baokhoa-code/JobsManagementApp

#warning: this application is created in fix height and width, meaning that some device with 
		screen smaller than 15,6 inch will catch promblem in app rendering
## III. Author

* [Jouhny Koh](https://github.com/JouhnyKoh)

<div id="sum"></div>

## IV. Summary
