# KLA Coding Task

Write an application which converts a currency (dollars) from numbers into words.
The maximum number of dollars is 999 999 999.
The maximum number of cents is 99.
The separator between dollars and cents is a ‘,’ (comma).

---
Examples

| Input | Output
|----------|----------
| 0 | zero dollars | 
| 1 | one dollar | 
| 25,1 | twenty-five dollars and ten cents |

# Prerequisites 
##### .NET Version : <span style="color:blue">.NET 8</span>
##### Node Version : <span style="color:blue">19.0.1</span>

# Project Folder Structure

## Root Directory
- `backend`
  - `KLA.API` .NET Core API
  - `KLA.Conversion` .NET Core libary for converting numbers to words
  - `KLA.Tests` Unit tests
  - `KLA.Model` Request and Response Models
- `frontend` Vue 3 frontend

## Fronted Setup

```sh
cd frontend //from Root Folder
npm install
```

#### Compile and Hot-Reload for Development

```sh
npm run dev
```

#### Compile and Minify for Production

```sh
npm run build
```

## Backend Setup

from Root Folder
```sh
cd backend/KLA/KLA.API 
dotnet build
dotnet run
```