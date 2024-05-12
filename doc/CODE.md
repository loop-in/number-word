# Code Approach

1. The solution is based on the configurable settings with JSON (It can be easily switch over with Database)
- Configurable for different locale where the currency numbering approach is different, example, India: 1 LAKH = 100000
- Configurable to large range of digit if required, example, Octillion

2. Algorithm was written based on how the code can be simplify when generating the word
- Initial algorithm, parsing the number from left to right, one digit by one digit, but the algorithm get more complex as the number of digit increase
- Parse from right to left, divide the digits into group, process all groups recursively, this way, the code look much simplified
- How it was divided is based on the settings
- Each group has different size depending on the settings, as each locale is different
