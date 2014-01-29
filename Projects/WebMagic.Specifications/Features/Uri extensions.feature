Feature: Uri extensions

Scenario Outline: Uri.Combine(url)
	When I call Uri.Combine(<uri>, <url>)
	Then the result should be <expected>
	Examples:
		| uri                     | url     | expected               |
		| http://www.example.org  | /anyurl | http://www.example.org/anyurl |
		| http://www.example.org/ | anyurl  | http://www.example.org/anyurl |
		| http://www.example.org/ | /anyurl | http://www.example.org/anyurl |
