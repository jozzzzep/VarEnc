# VarEnc
The idea is to make the **encryption** of values in C# **easier**. Let's say you have a video game with an "int" variable containing the **player's score**. With simple software like **CheatEngine** and many more, you can **search for this variable and change it**. The VarEnc project has an easy solution for that. All you got to do is to change the type of the variable from "int", to "EncInt". Done. Your game will work the same but the score of the player will be encrypted in the background.
These called **EncTypes**, they are the alternative **encrypted** version of **their normal variables version** (**EncString** for string, **EncInt** for int, and so on). You can also **combine** and/or **compare** an EncType **with its normal type** and vice versa. They will **work the same as their normal type**, and every EncType has **every** method its normal version has. The **performance cost** is also **minimal** considering the **encryption level**, especially for videogames made with Unity (Just don't make every variable encrypted, only the ones you know you don't want a player to change with cheating software. At least not that easily, every "Client-Side" stuff can be hacked).

## Which types to use?
- **EncInt** - For storing an int. Every time you change its value, the random encryption keys that affect its value change too.
- **EncLong** - The same thing as the struct above, but for a 64-bit integer (a long).
- **EncFloat** - The same thing as the struct above, but for a Single (float).
- **EncDouble** - The same thing as the struct above, but for a Double.
- **EncDecimal** - The same thing as the struct above, but for a Decimal.
- **EncString** - An EncType class for a string type.

# Benchmark And Performance
The VarEnc repo contains a [benchmark](https://github.com/JosepeDev/VarEnc/tree/main/Benchmark) console application to test the efficiency of its types.  
When it's running, the application will perform a certain amount of tests on the types you chose.  
In each test, the application will change the value of a certain variable-type a certain amount of time.  

At first, you'll have to choose the types you want to compare.  
Then how long you want the benchmark to be (Fast, Normal, Long, etc), and after that choose a benchmark preset.  
After the benchmark is finished, the results will be printed. From there you can press Enter (or any key) and it'll take you back to the main menu.  

### Performance

I ran a few benchmarks on my Laptop (Intel Core **i7-8750h**, **GTX1060-MaxQ**), and these are the results:  

Variable Type - CPS (Changes per second):
**EncInt** - 5,837,044
**EncLong** - 3,980,810
**EncFloat** - 5,625,961
**EncDouble** - 3,928,240
**EncDecimal** - 4,213,448
**EncString** - 584,270

This is the size of each EncType:
**EncInt** - 8 bytes
**EncLong** - 16 bytes
**EncFloat**- 8 bytes
**EncDouble** - 16 bytes
**EncDecimal** - 32 bytes

It may seem heavy but it's **very light** considering its **simple** and **efficient encryption**.  
In a game where you want to have an encrypted "**score**" for the player, you can just **switch** the score's variable **type** from an **int** to an **EncInt**.  
They **work** the same, **behave** the same, and have the same **methods** and **functionality**.  
How many time you change the score variable? How many variables you want to be encrypted?  
Even if you'll have **1,000,000 encrypted variables** that you want to change **at once** (it is probably unnecessary to have all of them enc), you can do it and you'll have exactly the same **framerate**. It is a **very light** encryption solution.