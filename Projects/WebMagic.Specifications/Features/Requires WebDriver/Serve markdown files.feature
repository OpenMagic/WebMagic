@web
Feature: Serve markdown files
	As a developer
	I want to serve markdown files as easily as I can serve html files or mvc views

Scenario Outline: Correct Url is used
	Given the website is <WebsiteName>
	When I visit <Url>
	Then the page should include <Heading>
	And the page is rendered with a layout page
	Examples:
		| WebsiteName                       | Url                   | Heading                                     |
		| MarkdownEmptyAspNetWebApplication | /                     | <h1>/index.md</h1>                          |
		| MarkdownEmptyAspNetWebApplication | /index                | <h1>/index.md</h1>                          |
		| MarkdownEmptyAspNetWebApplication | /readme               | <h1>Markdown.EmptyAspNetWebApplication</h1> |
		| MarkdownEmptyAspNetWebApplication | /directory-test       | <h1>/directory-test/index.md</h1>           |
		| MarkdownEmptyAspNetWebApplication | /directory-test/      | <h1>/directory-test/index.md</h1>           |
		| MarkdownEmptyAspNetWebApplication | /directory-test/index | <h1>/directory-test/index.md</h1>           |
		| MarkdownEmptyAspNetWebApplication | /directory-test/file  | <h1>/directory-test/file.md</h1>            |
