# Picross App

## TODO

- Automatically generate and save board to JSON if one doesn't exist
- Define solvers base cases
- Test that importing variable sized Picrosses displays correctly
    - 5x5
    - 10x15
    - 20x20
- Fix printing to work with numbers greater than 9
    - Only affects Length, not height
(x) Decide if JSON hint dictionaries should index from 0

## Notes to Self

Handling the Dictionary flattening is easy if I want to just check for the existence of a value

When I need to find what Key that value is living at, then it becomes harder

-----

- Since we're always assuming one printed space is a single digit, we end up with issues when
trying to print the double digit values:

I know I need to allocate space for the hints on each side by length of the hints together as a string rather than by the number of hints