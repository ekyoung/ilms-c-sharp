Feature: Image Resizer Saves Scaled Images
	In order to have smaller images
	I want to be able to save scaled images

Scenario: Save a Thumbnail of a Full Size Image
	Given a sample image named "Bingham Canyon Mine.JPG"
	When I save the sample image with a scale factor of .0625 and file name "Bingham Canyon Mine Thumbnail.jpg"
	Then the output image should have dimensions of 160x120
