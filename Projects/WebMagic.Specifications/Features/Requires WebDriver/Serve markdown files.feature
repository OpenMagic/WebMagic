@web
Feature: Serve markdown files
	As a developer
	I want to serve markdown files as easily as I can serve html files or mvc views

Scenario Outline: Correct Url is used
	Given the website is <WebsiteProject>
	When I visit <Url>
	Then the page should include <Heading>
	And the page is rendered with a layout page
	Examples:
		| WebsiteProject                       | Url                   | Heading                                     |
		| Markdown.EmptyAspNetWebApplication | /                     | <h1>/index.md</h1>                          |
		| Markdown.EmptyAspNetWebApplication | /index                | <h1>/index.md</h1>                          |
		| Markdown.EmptyAspNetWebApplication | /readme               | <h1>Markdown.EmptyAspNetWebApplication</h1> |
		| Markdown.EmptyAspNetWebApplication | /directory-test       | <h1>/directory-test/index.md</h1>           |
		| Markdown.EmptyAspNetWebApplication | /directory-test/      | <h1>/directory-test/index.md</h1>           |
		| Markdown.EmptyAspNetWebApplication | /directory-test/index | <h1>/directory-test/index.md</h1>           |
		| Markdown.EmptyAspNetWebApplication | /directory-test/file  | <h1>/directory-test/file.md</h1>            |
