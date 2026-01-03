# Fog Gate Randomizer for Dark Souls II: Scholar of the First Sin

A simple program that randomizes fog gate destinations in *Dark Souls II: Scholar of the First Sin*.

## Features

- Randomizes all the fog gate destinations.
- Not tested with any other mods ***(see below for compatibility with item and enemy rando)***.
- Randomizes only the fog gates and not the warps in the game like Giant Memories.

## Some Thing to Note

- Boss fights will not activate unless you enter the area around the Entrance gate (Some will require you to be extremely close to fog door) not the exit gate.
- Some boss will attack you but you will not be able to attack them unless they are activated. To activate read above point.
- Try looking for different ways around the map like dropdowns and reverse traversal to find new paths.
- Should be possible to finish the game and reach all places. Report with the seed if you discover any softlocks and bugs.
- Cheatsheet is located at (GameFolder)/mod/log

## Installation

- Copy the contents of the zip file to the game folder that contains DarkSoulsII.exe

## Usage

- Run the application (GameFolder)/mod/DS2FGR.exe

## Contact and Support

Email: nabeengau@gmail.com

## Soft Compatibility with Item & Enemy Randomizer (by Chainsboyo)

This mod has **soft compatibility** with **Item & Enemy Randomizer** by **Chainsboyo**:

- Item & Enemy Randomizer:  
  https://www.nexusmods.com/darksouls2/mods/1317  
- Author profile:  
  https://www.nexusmods.com/profile/Chainsboyo  

### Important Limitations (Read Carefully)

- **Key items must NOT be randomized (yet).**  
  This is **extremely important**. If key items are randomized, progression may become impossible due to fog gate destination changes.

- **Fog Gate Randomizer does not account for enemy or boss scaling** applied by the Item & Enemy Randomizer.  
  As a result, some fog gate destinations may lead to encounters that are significantly harder or easier than intended.

- Compatibility is considered *soft* because the two mods do not directly integrate with each other like reading key items randomized locations.

---

### Installation (with Item & Enemy Randomizer)

If you want to use this mod **together with Item & Enemy Randomizer**, follow these steps **exactly and in order**:

1. **Install Item & Enemy Randomizer first**  
   - Configure it so that **key items are NOT randomized**.

2. **Install Fog Gate Randomizer**  
   - Copy its files into the game folder.  
   - **Replace files if prompted**.

3. Open `modengine.ini` and **uncomment** the following line by removing the semicolon:
   ```ini
   ;chainDInput8DLLPath="/ds2s_heap_x.dll"
   ```
4. Run the Item & Enemy Randomizer first.

5. Run the Fog Gate Randomizer afterward.

### Notes on Load Order

- Item & Enemy Randomizer must be installed before Fog Gate Randomizer.

- Item & Enemy Randomizer must be run before Fog Gate Randomizer.

- Reversing this order will not randomize enemy and item.

## Credits

This project makes use of and builds upon the work of others. Huge thanks to the respective authors and contributors:

- **UXM Selective Unpack** by *Nordgaren* — https://github.com/Nordgaren/UXM-Selective-Unpack  
- **Smithbox** by *vawser* — https://github.com/vawser/Smithbox/tree/main  
- **SoulsFormats** by *JKAnderson* — https://github.com/JKAnderson/SoulsFormats  
- **ESDLang** by *thefifthmatt* — https://github.com/thefifthmatt/ESDLang  
- **DS2S-META** by *pseudostripy* — https://github.com/pseudostripy/DS2S-META  
- **raylib** by *raysan5* — https://github.com/raysan5/raylib
- **Cheat Engine** — https://www.cheatengine.org/  
- **SoulsSpeedruns Save Organizer** by *Kahmul* — https://github.com/Kahmul/SoulsSpeedruns-Save-Organizer  
