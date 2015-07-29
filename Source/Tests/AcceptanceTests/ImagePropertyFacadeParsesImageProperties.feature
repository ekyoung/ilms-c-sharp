Feature: Image Property Facade Parses Image Properties
	In order to read the properties embeded in an image
	I want code that makes it easy

Scenario: Image With Date Taken Embeded
	Given a sample image named "Arctic Circle.JPG"
	Then the date taken of the sample image is 6/23/2005 12:19:03 AM

Scenario: Image Without Date Taken Embeded
	Given a sample image named "Logo.gif"
	Then the date taken of the sample image is null
