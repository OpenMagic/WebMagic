Feature: Serve files from repository
	As a developer
	I want to serve files from a repository

Scenario Outline: Correct page url is used
	Given the website is <WebsiteName>
	When I visit <Url>
	Then the page should include <Heading>
	And the page is rendered with a layout page
	Examples:
		| WebsiteName                         | Url                   | Heading                           |
		| RepositoryEmptyAspNetWebApplication | /                     | <h1>/index.md</h1>                |


		# todo
		# | RepositoryEmptyAspNetWebApplication | /index                | <h1>/index.md</h1>                |
		# | RepositoryEmptyAspNetWebApplication | /page                 | <h1>/page.md</h1>                 |
		# | RepositoryEmptyAspNetWebApplication | /directory-test       | <h1>/directory-test/index.md</h1> |
		# | RepositoryEmptyAspNetWebApplication | /directory-test/      | <h1>/directory-test/index.md</h1> |
		# | RepositoryEmptyAspNetWebApplication | /directory-test/index | <h1>/directory-test/index.md</h1> |
		# | RepositoryEmptyAspNetWebApplication | /directory-test/page  | <h1>/directory-test/page.md</h1>  |

#Scenario Outline: Correct image url is used
#Scenario Outline: Repository directory is return 404, page not found
