Feature: Uri extensions

Scenario Outline: Uri.Combine(url)
	When I call Uri.Combine(<uri>, <url>)
	Then <expected> Uri should be returned
	Examples:
		| uri                     | url     | expected               |
		| http://www.example.org  | /anyurl | http://www.example.org/anyurl |
		| http://www.example.org/ | anyurl  | http://www.example.org/anyurl |
		| http://www.example.org/ | /anyurl | http://www.example.org/anyurl |
