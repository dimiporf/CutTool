# CutTool

CutTool is a command-line tool for text manipulation and data extraction.

## Table of Contents
- [Introduction](#introduction)
- [Installation](#installation)
- [Usage](#usage)
- [Functionality](#functionality)
- [Contributing](#contributing)

## Introduction

**CutTool** is a lightweight command-line utility written in C# designed for efficiently cutting and extracting data from text files. It allows users to specify delimiters, field indices, and additional options to precisely manipulate data.

## Installation

To use CutTool, you need to have the .NET runtime installed on your machine. You can download it from the official .NET website.

Once you have .NET installed, you can clone this repository or download the source code as a ZIP file and extract it to your desired location.

## Usage

CutTool is a command-line tool that accepts various arguments to perform different operations. Here's how you can run it:

```bash
dotnet run -- <inputfile> -field <fields> -delim <delimiter> -uniq -count
```
## Arguments

< inputfile > : Specifies the path to the input text file.

## Options:

-field < fields >: Specifies the indices of the fields to extract from each line of the input file. Fields are separated by commas.

-delim < delimiter >: Specifies the delimiter used to separate fields in the input file.

-uniq: Flag indicating to output only unique field values.

-count: Flag indicating to output the count of occurrences of each unique field value.

Example:

```bash
dotnet run -- input.txt -field 1,3,5 -delim "," -uniq -count
```
This command will extract fields 1, 3, and 5 from each line of the input.txt file using comma as the delimiter. It will output only unique field values and their respective counts of occurrences.

## Functionality

CutTool provides the following functionality:

- Data Extraction: Extract specific fields from text files based on delimiters and field indices.
- Unique Values: Option to output only unique field values.
- Count: Option to output the count of occurrences of each unique field value.

## Contributing

Contributions are welcome! If you find any bugs, have feature requests, or want to contribute code, please open an issue or submit a pull request on the GitHub repository.
