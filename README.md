![Imgur](https://i.imgur.com/TkHOVkN.png)
# Variable Encryption
Simple tools for storing values while efficiently keeping them encrypted in the memory.
* Currnetly supports in C#  
* **int - long - float - double - decimal - string**.
 
 # [PRESS HERE TO ENTER THE WIKI]
 
 [PRESS HERE TO ENTER THE WIKI]: https://github.com/JosepeDev/Variable-Encryption/wiki
 
# New Encrypted Types
* **EncFloat** - A type for containing a "Single" type (a float).
 The same concept as the EncInt struct.

* **EncDouble** - A type for containing a "Double" type.
 The same concept as the struct above.

* **EncDecimal** - A type for containing a "Decimal" type.
  The same concept as the struct above.

* **EncString** -  An EncType class for a string type,
that uses an XOR bitwise encryption.

## Classes and Structs INDEPENDENCE
I all the previous versions, all the classes, the structs, and the EncTypes were dependent on the **EncryptionTools**.
A class that had methods for getting random numbers. Now there's no need for that.
Every single **EncType** now is **independent** and can work alone.

# Benchmark Application
The **VarEnc** repo now contains a benchmark (exe)cutable to test the efficiency of its types.
When running, **a benchmark** will perform a certain **amount tests** for each variable type you choose and in **each test**,
 the application will **perform changes** to these variables a **certain amount of time**.

### If it sounds complicated, don't worry. It is very simple and it has a full page in the **WIKI** (:

You can lunch the Benchmark executable from the "**Benchmark**" library.
You can also **build** the benchmark executable **yourself** with the **Solution contained in the repo**.

# Removed classes
* **EncryptionTools**, this class contained methods for getting a random variable.
 This was completely redundant and made unnecessary dependencies.
* **EncryptedInt**, this class was the first in this project. 
Now it's useless with the new Enc structs.
