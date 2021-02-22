Feature: CarInfo


@smoke
Scenario Outline: Get car information by type
	Given The system knows about all cars
	When the client requests a car information by type <type>
	Then the client sees response code <code> for <type>

	Examples: 
	| type      | code |
	| SUV       | 200  |
	| Hatchback | 200  |
	| Saloon    | 200  |
	| Sedan     | 404  |

@smoke
Scenario Outline: Ensure content of get car info contains the correct parameter value
	Given The system knows about all cars
	When the client requests a car information by type <type>
	Then the response contains the make <make> of the car

	Examples: 
	| type      | make   |
	| SUV       | Toyota |

@smoke
	Scenario: Verify car makes for Hatchback
	Given The system knows about all cars
	When the client requests a car information by type Hatchback
	Then the response has the following makes
	| ID | Make       |
	| 1  | Ford       |
	| 2  | Volkswagen |

