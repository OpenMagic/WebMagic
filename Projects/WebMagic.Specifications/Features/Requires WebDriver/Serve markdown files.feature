@web
Feature: Serve markdown files
	As a developer
	I want to serve markdown files as easily as I can serve html files or mvc views

Scenario: Empty ASP.NET Web Application
	Given the website is a 'Empty ASP.NET Web Application'
	When I visit '/'
	Then the page should include '<h1>/index.md</h1>'
	And the page is rendered with a layout page
