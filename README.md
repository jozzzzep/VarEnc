![Imgur](https://i.imgur.com/jnXHECv.png)
<p align="center">
        <img src="https://img.shields.io/codefactor/grade/github/JosepeDev/VarEnc/main">
        <img src="https://img.shields.io/github/languages/code-size/JosepeDev/VarEnc">
        <img src="https://img.shields.io/github/license/JosepeDev/VarEnc">
        <img src="https://img.shields.io/github/v/release/JosepeDev/VarEnc">
</p>
<p align="center">
        <img src="https://img.shields.io/github/followers/JosepeDev?style=social">
        <img src="https://img.shields.io/github/watchers/JosepeDev/VarEnc?style=social">
        <img src="https://img.shields.io/github/stars/JosepeDev/VarEnc?style=social">
</p>

The idea is to make the **encryption** of values in C# **easier**. Let's say you have a video game with an "int" variable containing the **player's score**. With simple software like **CheatEngine** and many more, you can **search for this variable and change it**. The VarEnc project has an easy solution for that. All you got to do is to change the type of the variable from "int", to "EncInt". Done. Your game will work the same but the score of the player will be encrypted in the background.
These called **EncTypes**, they are the alternative **encrypted** version of **their normal variables version** (**EncString** for string, **EncInt** for int, and so on). You can also **combine** and/or **compare** an EncType **with its normal type** and vice versa. They will **work the same as their normal type**, and every EncType has **every** method its normal version has. The **performance cost** is also **minimal** considering the **encryption level**, especially for videogames made with Unity (Just don't make every variable encrypted, only the ones you know you don't want a player to change with cheating software. At least not that easily, every "Client-Side" stuff can be hacked).

**Content**
- [**EncTypes**](#enctypes)
  - [Which type to use?](#which-type-to-use)
  - [Examples](#examples)
  - [**Documentations**](#documentations)
- [**Benchmark**](#benchmark)
  - [Performance](#performance)
  - [Example of usage](#example-of-usage)
  - [Files](#files)
- [**Cloning And Importing**](#cloning-and-importing)
  - [Visual Studio](#visual-studio)
  - [Unity](#unity)

# EncTypes
![img](https://i.imgur.com/F2fxgOn.png)

**A group of classes and structures for storing values while efficiently keeping them encrypted in the memory.**  
**In memory, they are saved as a "weird" array of bytes that is affected by random values (encryption keys).**  
**You can find all the EncTypes in [this](https://github.com/JosepeDev/VarEnc/tree/main/EncTypes) folder. You can also use the** 
**[benchmark](https://github.com/JosepeDev/VarEnc/tree/main/Benchmark) executable file, to speed test each type.**  

Let's say you want to create a variable for a score inside a video game.  
With a simple program like CheatEngine and many more, anyone can edit the value of this variable.  
This is when you want to use an EncType. Each type does not depend on the other, so you can copy only the types you need.  

## Which type to use?

- **EncInt** - For storing an int. Every time you change its value, the random encryption keys that affect its value change too.
- **EncLong** - The same thing as the struct above, but for a 64-bit integer (a long).
- **EncFloat** - The same thing as the struct above, but for a Single (float).
- **EncDouble** - The same thing as the struct above, but for a Double.
- **EncDecimal** - The same thing as the struct above, but for a Decimal.
- **EncString** - An EncType class for a string type.

You can find the EncTypes folder [here](https://github.com/JosepeDev/VarEnc/tree/main/EncTypes)

## Examples

#### Creating and assigning

```csharp
int normalInt = 11;
EncInt encryptedInt = 11;

// Works the same with these

double normalDouble = 8.109901;
EncDouble encryptedDouble = 8.109901;

// Works the same with these

string normalString = "That's a text";
EncString encryptedString = "That's a text";
```

#### Math

```csharp

// An int example, but works the same with doubles.
int normalInt = 0;
EncInt encryptedInt = 0;
normalInt += 18;
encryptedInt += 18; 
normalInt /= 9;
encryptedInt /= 9; 

// Strings
string normalString = "That's a text";
EncString encryptedString = "That's a text";
normalString += "more text";
encryptedString += "more text";

```

**They will work the same as their normal type.**  
**Even with Incrementing/Decrementing/Multiplying/Dividing/Comparing.**  
**But in the background it is encrypted.**  
**Without you worrying about encryption or decryption, you work with your variables just the same.**  
**You can also combine and/or compare an EncType with its normal type and vice versa.**  
**Every EncType has every method its normal version has.**

## Documentations
**Every EncType contains the same methods and fields as its normal type.**  
**So it'll link you to the official .NET documentaions.**
### CSharp
- [EncInt](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-5.0)
- [EncLong](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-5.0)
- [EncFloat](https://docs.microsoft.com/en-us/dotnet/api/system.single?view=net-5.0)
- [EncDouble](https://docs.microsoft.com/en-us/dotnet/api/system.double?view=net-5.0)
- [EncDecimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal?view=net-5.0)
- [EncString](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-5.0)

# Benchmark
![img](https://i.imgur.com/C8YKbnd.png)

The VarEnc repo contains a benchmark console application to test the efficiency of its types.  
When it's running, the application will perform a certain amount of tests on the types you chose.  
In each test, the application will change the value of a certain variable-type a certain amount of time.  

#### What you'll have to choose
* Types to compare (EncInt vs int, EncDouble vs double, etc)
* How long you want the benchmark to be
* A benchmark preset

At first, you'll have to choose the types you want to compare.  
Then how long you want the benchmark to be (Fast, Normal, Long, etc), and after that choose a benchmark preset.  
After the benchmark is finished, the results will be printed. From there you can press Enter (or any key) and it'll take you back to the main menu.  

### Performance

I ran a few benchmarks on my Laptop (Intel Core **i7-8750h**, **GTX1060-MaxQ**), and these are the results:  
| Variable Type | CPS (Changes per second) |
|---------------|--------------------------|
|     EncInt    |         5,837,044        |
|    EncLong    |         3,980,810        |
|    EncFloat   |         5,625,961        |
|   EncDouble   |         3,928,240        |
|   EncDecimal  |         4,213,448        |
|   EncString   |          584,270         |

This is the size of each EncType compared to its normal type
|         Types        | Size in bytes |
|:--------------------:|:-------------:|
|     int - EncInt     |     4 - 8     |
|    long - EncLong    |     8 - 16    |
|   float - EncFloat   |     4 - 8     |
|  double - EncDouble  |     8 - 16    |
| decimal - EncDecimal |    16 - 32    |

It may seem heavy but it's **very light** considering its **simple** and **efficient encryption**.  
In a game where you want to have an encrypted "**score**" for the player, you can just **switch** the score's variable **type** from an **int** to an **EncInt**.  
They **work** the same, **behave** the same, and have the same **methods** and **functionality**.  
How many times did you change the score variable? How many variables do you want to be encrypted?  
Even if you'll have **1,000,000 encrypted variables** that you want to change **at once** (it is probably unnecessary to have all of them enc), you can do it and you'll have exactly the same **framerate**. It is a **very light** encryption solution.

### Example of usage:  
I **opened** the application from the "**Benchmark**" folder.  
And now it shows **all** the **types** you can **compare**.  

![img](https://i.imgur.com/vuzWLeA.jpg)  
I chose to make a comparison between the **EncString** and its first version, the **EncString (0.5.0)**.  
So I typed **11** and pressed Enter.  

![img](https://i.imgur.com/4lOG5MR.jpg)  
I chose to perform a benchmark of type "**Fastest**".  
So I typed **1** and pressed Enter.   

![img](https://i.imgur.com/OffKwtz.jpg)  
From the **presets** of type "Fastest" I chose to perform the **fourth**.  
The fourth one will perform **10** test, in each test, **100,000** changes.  
So I typed **4** and pressed Enter.  

![img](https://i.imgur.com/8mjwNFG.jpg)  
These are the **results**. It performed **10 tests** on each type.  
Each test performed **100,000 changes** to a variable on type **EncString**, then **EncString's first version (0.5.0)**.  
It says that the **EncString** type performed **better** by **29.140987%**.  
It also says shows the **amount of changes** you can perform **in a second** on each type.  

### Run benchmark again
You can **run again** the same benchmark by pressing **Space** when the results are shown.  
You can also run the previous benchmark again by typing **"p"** or **"prev"** in the first menu.  

### Multiple choices at once
I could perform the same benchmark as before, by inputting all the choices at once.  
Before, we typed **"11"**, pressed Enter, then **"1"**, pressed Enter, and then **"4"**, and pressed Enter again.  
We can do it faster just by typing **"11 1 4"** (separate each choice with a space) and pressing Enter.  

### Seeing the sizes of the types
By typing **"size"** or **"s"** in the opening menu, you can see the sizes of every type in bytes.  

![img](https://i.imgur.com/qHPx9CA.jpg)


### Files
You can lunch the benchmark executable from [here](https://github.com/JosepeDev/VarEnc/tree/main/Benchmark)  
You can also see the Benchmark Application's Solution in [this](https://github.com/JosepeDev/VarEnc/tree/main/Benchmark/Solution) folder  

# Cloning And Importing
![img](https://i.imgur.com/n7PAr9D.png)

- .NET CLI: ```dotnet add package VarEnc --version x.x.x```

- NuGet Package Manager: ```Install-Package VarEnc -Version x.x.x```

- Nuget Package Link: https://www.nuget.org/packages/VarEnc

## Visual Studio
You can also get the package through VisualStudio's NuGet package manager.
**IT DOESN'T WORK WITH UNITY PROJECTS** Click on **Tools**>**NuGet Package Manager**>**Manage NuGet Packages for Solution...**  

![img](https://i.imgur.com/T6Mwuzx.png)  
It'll open the **"NuGet - Solution"** Window. From there, click on the **"Browse"** tab, and search **"varenc" or "VarEnc"**  

![img](https://i.imgur.com/zQDshL0.png)  
When you see the **"VarEnc" package**, click on it, and click on the **Install** button in the right panel  

![img](https://i.imgur.com/VmSArI0.png)  
Click **OK** to proceed, accept the **licence** and you're done (:  

## Unity
I use this project on every Unity game I've created.
Unity games are the reason I created this project.
You can import the script to unity in many ways.

### Way #1 - Importing scripts
This way will require you to download or clone the repository.  
You can **clone** from this page by **clicking** the green **"Code" button**:  

![img](https://i.imgur.com/LhNSi5i.png)  

You can also **download** the content of this repo through the recent **release page**: [Releases page](https://github.com/JosepeDev/VarEnc/releases)  
From there, **scroll to the bottom** of the **current release** and click on the file "**Source code (zip)**".  
It'll **download** the repository as a zip file to you computer. Just **Unzip** and you're reasy.  

![img](https://i.imgur.com/hgB06A9.png)

After that, when you have the repository on you computer, the next step is to enter the &&EncTypes directory&&.

![img](https://i.imgur.com/tVOQBzG.png)

From there **select all the scripts you want**, and **drag** them to your **Unity** project.

![img](https://i.imgur.com/SnIYfLJ.png)

**Done!**

![img](https://i.imgur.com/mwAtfTx.png)

### Way #2 - Copying to a Unity Projcet
This way will take more time for all the scripts, but will be quick if you only need a few scripts.  
Lets say you want only the **EncInt** script and the **EncString**.  
Go to **your Unity project**, and **create 2 new scripts**, one foreach type you want.  
(EncInt and EncString in this case)  

![img](https://i.imgur.com/y00Pc6m.png)  
From this repository, enter the **EncTypes folder**.  
It contains **every** Encrypted Variable Type.  

![img](https://i.imgur.com/CHxddy7.png)  
Click on the ones you want, in my case I start with with EncInt.  

![img](https://i.imgur.com/w8JCnIw.png)  
**Copy** the content from the script you want, and **paste** it **inside the scripts you created in Unity**.  

![img](https://i.imgur.com/BMrIwTf.png)  
**Done!**
