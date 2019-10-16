<!-- README
=============== --> 

<p align="center">
  <a href="https://github.com/sospep/dotnetThree">
    <img src="https://github.com/sospep/dotnetThree/blob/master/static/img/blog-layout-inspiration-resize-50-percent.png" alt="Blog Layout Example">
  </a>
</p>

<p align="center">"<i>dotnetThree - duh blog</i>"</p>

<h4 align="center"> dotnetThree - Is a web application designed to create and manage blog articles with comments.</h4>

<br>

<p align="center">
  <a href="https://github.com/sospep/dotnetThree/pulls">
    <img src="https://img.shields.io/badge/PRs-welcome-brightgreen.svg?longCache=true" alt="Pull Requests">
  </a>
  <a href="https://choosealicense.com/licenses/mit/">
    <img src="https://img.shields.io/github/license/sospep/dotnetThree" alt="License">
  </a>
</p>

<div align="center">
  <sub>Created by
  <a href="https://twitter.com/sospepTime">sospep</a> and
  <a href="https://github.com/sospep/dotnetThree/graphs/contributors">contributors</a>
</div>

<br>

description 
------------
dotnetThree -> duh blog is a simple blogging application. It enables users to create blog articles and to create comments on those articles.
It has some very cool features like a full blown authentication system for managing users and the capabilities that they have within the application.

objectives 
------------
* Use the latest version of dotnet core (v3) to build a basic application and see what kind of challenges that I will face. 
* Use the completed basic application to serve as a quick start template when creating new dotnet core v3 projects that may require similar functionality. 
* It could also be used as a lightweight simple application to manage a blog &#128512;!

demo
------------
The current version of this application is online at [blog.sospep.org](http://blog.sospep.org) for demonstration purposes. 

This application was developed using ...

dotnet core version
------------
* v 3.0.100

application version 
-------------
current: 0.12.0-alpha 

application dependencies
-------------------
* [] packages - ] codeGeneration, ] entity framework, ] entity framework core sqlite,] entity framework core sqlserver, ] entity framework tools,  ] entity framework design, ] entity framework identity ] asp.net core diagnostics ] asp.net identity, ] microsoft extensions logging ] mailKit, ] mimeKit

Configuration / Setup
-------------
[on windows || mac || linux ] 
1. [] use ">git clone https://github.com/sospep/dotnetThree.git" - to clone this application to your local machine
2. [] open a terminal window in the directory that you downloaded the application to, then ... 
3. [] use ">dotnet run" - to start the application on your local machine
4. [] use "http://localhost:5000" - in your browser's address bar to access the running application
5. [] use ">dotnet user-secrets mailServer {your-smtp-serverName} to set the mail server name for outgoing email
6. [] use ">dotnet user-secrets SMTPUser {your-smtp-server-username} to specify the email user account to use
7. [] use ">dotnet user-secrets SMTPKey {your-smtp-server-password} to set the password for the specified email account

Database Creation
-----------------
* [] The application includes an sqlite3 database implementation that is ready to use
* [] coming-soon - ARTICLE - how-to use this application with a RDBMS like ] mysql, ] sqlserver, ] postgres 

Database initialization
-----------------------
* [] add instructions to ...

How to run the test suite
-------------------------
* [] add instructions to ...

Services (job queues, cache servers, search engines, etc.)
----------------------------------------------------------
* [] add instructions to ...

Deployment instructions
------------
* [] use ">dotnet publish" - to generate new application binaries after you have implemented any code changes
* [] coming-soon - ARTICLE - deploying your dotnet core 3.x application to shared windows hosting service. 
* [] coming-soon - ARTICLE - deploying your dotnet core 3.x application your digital ocean droplet. 
