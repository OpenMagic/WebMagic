Feature: Serve files from repository
	As a developer
	I want to serve files from a repository

Scenario Outline: Correct page url is used
	Given the website is <WebsiteProject>
	When I visit <Url>
	Then the page should include <Heading>
	And the page is rendered with a layout page
	Examples:
		| WebsiteProject                         | Url                   | Heading                           |
		| Repository.EmptyAspNetWebApplication | /                     | <h1>/index.md</h1>                |
		| Repository.EmptyAspNetWebApplication | /index                | <h1>/index.md</h1>                |
		| Repository.EmptyAspNetWebApplication | /page                 | <h1>/page.md</h1>                 |
		| Repository.EmptyAspNetWebApplication | /directory-test       | <h1>/directory-test/index.md</h1> |
		| Repository.EmptyAspNetWebApplication | /directory-test/      | <h1>/directory-test/index.md</h1> |
		| Repository.EmptyAspNetWebApplication | /directory-test/index | <h1>/directory-test/index.md</h1> |
		| Repository.EmptyAspNetWebApplication | /directory-test/page  | <h1>/directory-test/page.md</h1>  |

#Scenario Outline: Correct image url is used
#Scenario Outline: Repository directory is return 404, page not found
