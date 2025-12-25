Tower of Hanui

Tower of Hanui is a Unity-based implementation of the classic Tower of Hanoi puzzle. The project focuses on data structure usage (specifically stacks), and gameplay system features such as undo/redo and automated solving via recursion.



Architecture Overview


1. GameManager

The GameManager is responsible for initializing and configuring the game.

Responsibilities:

References prefabs for:

Poles
Disks
Stores configuration variables such as:
Disk count
Disk spacing
Disk scaling

Handles spawning of poles and disks into the scene

Enforces encapsulation by restricting modification of configuration variables to within the class itself

2. SystemManager

The SystemManager handles global gameplay systems and player actions that affect overall game state.

Responsibilities:

Reloading the scene

Auto-solving the puzzle

Undo functionality

Redo functionality

3. Pole

The Pole script represents the core gameplay mechanic.

Responsibilities:

Maintains a Stack data structure to store disks in correct order

Controls disk placement logic

Uses boolean flags to determine:

Whether a pole is selected

Whether a disk can be stacked on a given pole based on game rules

This approach ensures that disk movement always respects Tower of Hanoi constraints.





Gameplay Systems

1. Undo Logic:

If a disk is currently selected, undo is blocked to prevent stack corruption

Restores the disk to its previous pole

Recalculates the disk’s position before reinserting it into the correct stack

2. Redo Logic:

Uses the same validation and movement logic as undo

3. Auto Solver

The auto solver uses a recursive algorithm based on the standard Tower of Hanoi solution.

Key Characteristics:

Recursively ensures all smaller disks are moved before moving the largest disk

Automatically completes the puzzle once initiated




Trade-offs and Limitations
Current Limitations

The auto solver resets all disks to their initial spawn state

This occurs because the solver assumes all disks start on the original pole





Potential Improvements

Implement a state-space search or graph-based solution

Track current disk states instead of assuming an initial configuration

Allow auto-solving from any valid intermediate game state

Adding diffrent random colour materials to each disk for better visuals