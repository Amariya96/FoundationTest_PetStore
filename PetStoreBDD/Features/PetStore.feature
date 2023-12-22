Feature: PetStore

Background: User will be on Homepage

@tag1
Scenario: Product Select And AddToCart
	When User click on the Petname Dogs
	Then The page will be loaded
	When User click on the ProductIds
	Then The pet details will be loaded
	When User click on the ItemIds
	Then The item page will be loaded
	When The user click on the AddToCart
	Then The carted page is loaded
	When user click on the ProceedToCheckout
	And  Page will be loaded
	And user will enter the '<username>', '<password>'
	And User will click on the login button
	Then The page will be loaded

Examples: 
	| username | password   |
	| Kavi     | Qwerty@123 |

