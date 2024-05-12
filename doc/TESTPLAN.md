# Test Plan

### Scope
The test will only focus on the result of the algorithm, to make sure the result is correct for different kind of format which is allowed
**NOTE:** Will not support larger than QUADRILLION based on current settings, if required, settings must be change

### Approach
- The test will mainly run using manual and automated testing for functional testing
- Automated testing will be added in CICD pipeline which focus on code unit testing, it will triggered when the code is plan to be merge to the main branch

### Test Case
Invalid input as below and it should return "Success = false"
- ABC
- 123.999
- 123.45.67
- 123.AA
- 0123.34
- $123.45
Valid input as below and it should return "Success = true" with the correct word in the response
- 0 - ZERO DOLLARS
- 0.80 - EIGHTY CENTS
- 888 - EIGHT HUNDRED AND EIGHTY-EIGHT DOLLARS
- 123.9 - ONE HUNDRED AND TWENTY-THREE DOLLARS AND NINETY CENTS
- 567.75 - FIVE HUNDRED AND SIXTY-SEVEN DOLLARS AND SEVENTY-FIVE CENTS
- 700450.90 - SEVEN HUNDRED THOUSAND FOUR HUNDRED AND FIFTY DOLLARS AND NINETY CENTS
- 2300880 - TWO MILLION THREE HUNDRED THOUSAND EIGHT HUNDRED AND EIGHTY DOLLARS
- 90000000000000000000.80 - NINETY THOUSAND QUADRILLION DOLLARS AND EIGHTY CENTS
