OCCUWebsite
=================
This respository consists of the source files used to create the sample website.

Also available are:
1) OCCUWebsite.zip
[OCCUWebsite.zip](https://github.com/user-attachments/files/23150683/OCCUWebsite.zip)

2) OCCUExampleSqlscript.zip[OCCUExampleSqlscript.zip](https://github.com/user-attachments/files/23150684/OCCUExampleSqlscript.zip)

3) OCCUExampleMSDEBackup.zip[OCCUExampleMSDEBackup.zip](https://github.com/user-attachments/files/23150685/OCCUExampleMSDEBackup.zip)


You have the choice of how you would like to evaluate this project. 

To run the website, you can choose how you wish to evaluate:

A) First- attached the OCCUExample msde sql database to your local windows instance.
	-alternatively, you could extract and run the OCCUExampleSqlScript to generate the database.
	
	There are 2 tables in the db: Person and StatusReport that hold the datasets used for this application.
	
	I am assuming you have Admin rights on this machine to install.

Bi) Run the source code with a local browser instance. This solution was developed in .net framework 9.0 and Visual Studio 22; I did not test with other environments

OR Bii) Download the OCCUWebsite deploy files to your IIS wwwroot folder. This was tested in a Windows 10 environment.


If you have any questions for this setup, please contact me at stephenhotard@gmail.com.


---------------------------------------------------------

Implementation details:

In general, for the last several years, most project work I have done is within existing codebases and frameworks. It is rare that I am building a web app from 'scratch'. I reviewed the old MS tutorial Contoso University and used that as a framework as it has the basic MVC framework. I found, because of the simple pages, it was not necessary to generate Controllers because there was not complex business logic to join tables or transform the data.


1) The website will open to a home page with links to 'Person' or 'Status Report'. 

2) Status Report will open a page that lists the 37 statuses with their values. I put these values in the StatusReport db table for reference.

	-I added javascript to adjust value color and text aligment based on the row value. Without knowing who or how the report would be used, I kept it simple. In a real environment, I would add responsive and Accessible styling. For the purpose of this project, I did not add these features in.

3) Person - this link will open the Person page. The page will default with a list of current 'persons'. There is a link to Create a new field, as well as Edit, Delete or display the details.

	-The specification mentions there must be a name field, 3 other text fields and a date. I created these: LastName, FirstName, NickName, Other and a date field: StartDate. I did not add much for data validation or comparison, since these are usually handled within a larger framework. So, the UI is a little brittle- I am not checking for data validation or other context in the user interface for this exercise; but it is essential for real production code.

	-Bonus item: I fiddled around for the Bonus point to compare items; I added a columns that allowed users to select controls to compare items. But it was messy scripting and not robust. I attempted a Comparable interface based on previous experience, but could not add this in the time frame allowed.
	
	
4) Development environment: I developed this in Visual Studio 22 with .net framework 9.0. I choose this as I am familiar with these design patterns to develop simple sites like this. I have worked in .net for the majority of my career, developing custom solutions in Transportation Engineering for PTV, web applications for OSU and Samaritan Health Services. The most important part of any software project like this would be to first work with the customer to develop the requirements to determine the right tool and platform to support.









