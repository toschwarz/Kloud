# kloud.code
Kloud Code Test as provided by Kloud Solutions

There are two parts to the [KloudCodingTest](https://kloudcodingtest.azurewebsites.net).
* Build a website that shows the cars grouped by their brand, then sorted alphabetically by coulour.  Then for each brand, display the names of owners.
* Create a replica webservice of the given API

## Installation
The service it built on ASP.NET Core 2.0, using JQuery for the API call.
## Author
* **Todd Schwarzbrott**
## Solution
I built a single web site as part of this test, which serves two APIs.

One is the 'api/RepeaterAPI' endpoint, which serves the Owner Json data in the same manner as served by the [Kloud test API](https://kloudcodingtest.azurewebsites.net/api/cars).

The other API is the 'api/CarOwnerAPI' endpoint.  This is the original data grouped by Brand and listing the owners of each brand. This data is sorted alphabetically by colour.

The website itself is a straightforward MVC site, utilizing JQuery to call and then format the CarOwner API into HTML.  This is shown on the main page upon loading.

I also decided to filter records in the result set which had missing owner, brand, or colour attributes. I also performed a distinct on the result set, since certain owners had cars of the same brand, but in differing colours.

## Testing
The website contains a test project in XUnit to conduct a series of unit tests.