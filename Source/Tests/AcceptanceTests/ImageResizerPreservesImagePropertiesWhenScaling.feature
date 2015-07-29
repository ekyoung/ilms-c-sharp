Feature: Image Resizer Preserves Image Properties When Scaling
	In order to be able to read the properties of a thumbnail
	I want the image resizer to preserve the properties of the original image in the scaled image

Scenario: Date Taken is Preserved
	Given a sample image named "Bingham Canyon Mine.JPG"
	When I save the sample image with a scale factor of .0625 and file name "Bingham Canyon Mine Thumbnail.jpg"
	Then the date taken of the output image should be the same as the date taken of the sample image
