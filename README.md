# Spotlight with a Randomizer for Level Objects

A fork of Spotlight - the level editor for Super Mario 3D World.<br/>
This fork has a built in level randomizer that can intelligently replace objects at random!

View the official Spotlight repo at https://github.com/jupahe64/Spotlight

The randomizer is intelligent, so it will not usually randomize objects that are necessary to complete the level (such as platforms). It also avoids choosing certain objects that are likely to cause crashing in the game, so crashing is very common (but it does happen).

## Using the Randomizer

- The Randomizer can be found in the File menu

- Change the settings to your liking

- Hit the Randomize button and choose the folder you wish to save the randomized level files

- Wait as Spotlight randomizes them

## Settings

### More Beatable/More Random

MORE BEATABLE increases the odds that the level will still be completable at the expense of limiting randomness.

MORE RANDOM will ignore how completable the level may be to keep things random.

Pretty much setting this lower will lower the chances of large objects being chosen by the randomizer (smaller chance of them blocking the path in a level).

### Less Demanding/More Random

LESS DEMANDING will cause the randomizer to choose more objects that will be less demanding on CPU/RAM/GPU,
but levels will be less random.

MORE RANDOM will make the level more random,
but won't pay attention to how resource-demanding the level may be.

RECOMMENDATION: If using a real wii u, lower this if you need better performance/less crashing. It will MAYBE help.

On Cemu, this won't make much of a difference, so keep it all the way at More Random.

### Easy/Hard

Attempts to adjust the difficulty of the level.

Put the slider in the middle to try to keep the difficulty the same as before.

To be honest, this doesn't do a very good job with changing the difficulty though.

### Randomize Size

Randomizes the size of objects based upon the min and max set.

Less than 1 is smaller.
1 leaves the size the same.
More than 1 is bigger.

Maintain Ratio will keep the width/height/depth scaling the same. Uncheck this if you want the size change to look weird!

Not all objects have their size changed.

This can make many objects buggy. Part of the reason is that the hitbox isn't allways resized to fit the new size. Sometimes the hitbox does resize though, and this can often block levels making them unbeatable if the size is too large.

### Randomize Rotation

Which directions to randomly rotate objects (if random rotations is desired)

Not all objects get rotated.

This can also make some objects buggy.

### Consistent

If checked, each level will randomize objects by type
(for example, all goombas will be changed to the same type of object).

If unchecked, each object will be randomized to a different object
(for example, each goomba will be changed to a different object).
Unchecking this will also take a little longer to randomize.

It's recommended to keep this checked. Unchecking greatly increasing the likelihood of crashing.

### Use Range for Numbers

If checked, each object's properties that use numbers will use a random number in a similar range.
This may make object behavior sometimes a little more "interesting",
but is slightly more likely to break the level.

If unchecked, each object's properties that use numbers will only use an exact number that has been used with that specific property somewhere in the game.

It's recommended to keep this unchecked. Checking this greatly increases the likelihood of crashing.

### Levels and Objects

Choose exactly which levels and objects to randomize.

# Known Problems

- Going into the warp box after a world boss can sometimes kill the character. The source of the issue is unknown at the moment.

- Not every level has been tested. A few may always be unbeatable.

- Many objects are not randomized. This includes objects that are linked to other objects (such as cat goombas), and objects that almost always cause crashing when randomly chosen to replace another object (such as koopas).

# Credits

- JuPaHe64: Project Leader, Lead Programmer, GL Editor Framework Programmer
- Super Hackio: Database Programmer, Debugger, Lead Tester, GitHub Manager

- Ray Koopa: Syroot Library Developer
- KillzXGaming: Switch Toolbox Developer (Some code was borrowed), Rendering Assistant
- KFreon: DXT1 Decompression

- Whitehole (SMG Level editor): Some features and visuals were inspired by Whitehole

- FullmetalHobbit: Created the randomizer