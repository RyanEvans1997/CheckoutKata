# Assumptions
For this solution, I am assuming this is a requirement from a client and thus we need to
convert the problem from a high level one to a lower level. 

We have 4 products and we need to take into account different promotions that can be applied to these product prices.

-- Individual prices --

Product A - 10
Product B - 15
Product C - 40
Product D - 55

Promotions

If we scan 3 B's (BBB) then instead of 45 it would be 40 
If we scan 2 D's (DD) then instead of 110 with a 25% discount it would be (110 * 0.75) = 82.5

# Decision making

## Following Single Responsibility Principle
Abstract everything out even including the core project and tests.
Product separate from promotions etc

## Following Open/Closed Principle
Make the core code easy to extend from

## Interface segregation
Split out interfaces into simple ones

## Using decimals over double 
Realistically if we are dealing with currency - we should be using 
a more precise data type. This would be a follow up question for the client.

## Why string over char for SKU's?
Using only one character for SKU's, we are limited to the A-Z alphabet. So we essentially can only have 26 SKU's. Realistically we should be using GUIDs and tying that to the ID of items but for now using strings we can at least move that 27 to the memory of a string.

## TDD
Test Driven development is best practice for greenfield projects so if any test fails we know a recent change caused this

## Branching off
As I know this is a simple project, everything will be committed to a master branch. In a real world project, I would branch off per feature (aka, create a ticket regarding the product component and label the branch the JIRA number or call it Products). Only then would I merge a working branch into main as main should be the production ready source of truth.

## Guard clauses and null checks
If this required user inputs instead of hardcoded item scans - these null checks should guard from user input breaking our application

## .NET 7
No requirement for what version of framework to use. Though I understand most projects are done in .NET 6. Some of this code may change depending on the framework used and this would be a consideration I would need to ask the client/project manager before starting work to avoid rewriting code.

## xUnit
No requirement was given for what test framework to use but as discussed in the initial interview I understand this is the frequently used one and thus will be the one used for this project.

