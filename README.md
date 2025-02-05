### Tech test requirement
[NET Developer Practical Exercise.pdf](https://github.com/user-attachments/files/18886316/NET.Developer.Practical.Exercise.pdf)

### Running this app locally

**Prerequisite:** 
Visual Studio 2022 version 17.8 or higher

I. Clone this repository onto your machine

II. Install
```
press Ctrl + Shift + B in visual studio
```

III. Run
```
press F5 in visual studio
```

The application will then be accessible at:

https://localhost:7093/swagger/index.html

IV. Test on swagger
```
1. Click "Try it out"
2. In request body replace string with your input, for example
{
  "numbers": "string"
}
Your input
{
  "numbers": "1,3"
}
3. Click Execute
4. To test with another input, click "Reset" and repeat step 1 - 3
```

### Running unit tests
```
dotnet test
```

### Technology stack used
- [X] C# ASP.Net 8.0
