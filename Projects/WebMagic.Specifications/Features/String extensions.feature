Feature: String extensions

Scenario Outline: string.AddLeadingDot()
	When I call <string>.AddLeadingDot()
	Then <expected> string should be returned
	Examples:
		| string | expected |
		| .txt   | .txt      |
		| txt    | .txt      |
		| .txt.  | .txt.     |
		| txt.   | .txt.     |

Scenario Outline: string.RemoveLeadingDot()
	When I call <string>.RemoveLeadingDot()
	Then <expected> string should be returned
	Examples:
		| string | expected |
		| .txt   | txt      |
		| txt    | txt      |
		| .txt.  | txt.     |
		| txt.   | txt.     |

