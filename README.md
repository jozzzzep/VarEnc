![Imgur](https://i.imgur.com/2FPrdWN.png)
**Content**
- [**EncTypes**](#enctypes)
  - [Which type to use?](#which-type-to-use)
  - [Examples](#examples)
- [**Benchmark**](#benchmark)
  - [Example of usage](#example-of-usage)
  - [Files](#files)
- [**Documentations**](#documentations)
  - [CSharp](#csharp)

# EncTypes
![img](https://i.imgur.com/rIKRq3i.png)

**A group of classes and structures for storing values while efficiently keeping it encrypted in the memory.**  
**In memory, they are saved as a "weird" value that is affected by random values (encryption keys).**  
**You can find all the EncTypes in [this](https://github.com/JosepeDev/Variable-Encryption/tree/main/EncTypes) folder. You can also use the** 
**[benchmark](https://github.com/JosepeDev/Variable-Encryption/wiki/VarEnc's-Benchmark) executable file, to speed test each type.**  

Let's say you want to create a variable for a score inside a video game.  
With a simple program like CheatEngine and many more, anyone can edit the value of this variable.  
This is when you want to use an EncType. Each type does not depend on the other.  

## Which type to use?

- **EncInt** - For storing an int. Every time you change its value, the random numbers that affect its value change too.
- **EncLong** - The same thing as the struct above, but for a 64-bit integer (a long).
- **EncFloat** - The same thing as the struct above, but for a Single (float).
- **EncDouble** - The same thing as the struct above, but for a Double.
- **EncDecimal** - The same thing as the struct above, but for a Decimal.
- **EncString** - An EncType class for a string type, that uses an XOR bitwise encryption.

You can find the EncTypes library [here](https://github.com/JosepeDev/Variable-Encryption/tree/main/EncTypes)

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

# Benchmark
![img](https://i.imgur.com/ZiTbLZv.png)

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

### Example of usage:  
I **opened** the application from the "**Benchmark**" folder.  
And now it shows **all** the **types** you can **compare**.  

![img](https://i.imgur.com/O9khnDw.jpg)  
I chose to make a comparison between the **EncInt** and the **int** types.  
So I typed **1** and pressed Enter.  

![img](https://i.imgur.com/TlD1yM6.jpg)  
I chose to perform a benchmark of type "**Fastest**".  
So I typed **1** again and pressed Enter.   

![img](https://i.imgur.com/NT5SHRR.jpg)  
From the **presets** of type "Fastest" I chose to perform the **first**.  
So again, I typed **1** and pressed Enter.  

![img](https://i.imgur.com/iyHdlt6.jpg)  
These are the **results**. It performed **10 tests** on each type.  
Each test performed **50 changes** to a variable of type **EncInt**, then **int**.  
It says that the **int** type performed **better** by **1.946%**. (only **0.1 milliseconds**)  
Be aware that the **shortest** benchmarks are the **least accurate**.  
**Feel free to test the efficiency of other EncTypes (:**  

### Files

You can lunch the benchmark executable from [here](https://github.com/JosepeDev/Variable-Encryption/tree/main/Benchmark)

# Documentations
Every EncType contains the same methods and fields as its normal type.
So it'll link you to the official .NET documentaions for eash method/field.
## CSharp
- [EncInt](https://docs.microsoft.com/en-us/dotnet/api/system.int32?view=net-5.0)
- [EncLong](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=net-5.0)
- [EncFloat](https://docs.microsoft.com/en-us/dotnet/api/system.single?view=net-5.0)
- [EncDouble](https://docs.microsoft.com/en-us/dotnet/api/system.double?view=net-5.0)
- [EncDecimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal?view=net-5.0)
- [EncString](https://docs.microsoft.com/en-us/dotnet/api/system.string?view=net-5.0)
