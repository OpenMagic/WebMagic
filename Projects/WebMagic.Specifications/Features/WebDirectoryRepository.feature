Feature: WebDirectoryRepository

Scenario Outline: DirectoryExists(directory) always returns false
	Given WebDirectoryRepository(<rootDirectory>)
	When I call WebDirectoryRepository.DirectoryExists(<directory>)
	Then <expected> boolean should be returned
	Examples:
		| rootDirectory | directory    | expected |
		| .\            | abc          | false    |
		| .\            | string.Empty | false    |