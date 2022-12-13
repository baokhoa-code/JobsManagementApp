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

#warning: this application is created in fix height and width, meaning that some device with 
		screen smaller than 15,6 inch will catch promblem in app rendering