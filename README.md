Using the Unity game engine, design a 3D video game scenario where the protagonist, Bryce, is confined 
within a 500x500 250x250 terrain with a mummy monster. Bryce's objective is to reach a randomly 
placed Divine Pillar (with each gameplay) without losing all three lives.  
Bryce can either move slowly or leap forward, but each leap increases the mummy monster's alert level 
by 20 units. The mummy, initially facing away, rotates randomly every 10-60 seconds. If the mummy 
detects Bryce's movement while facing him, Bryce loses a life, and the alert level of the monster increases 
by 100 units. The alert level gradually decreases over time until it reaches 0.  
B. Game Logic and Setup 
Bryce, positioned at (120, 0, 30), featuring slow walk and leap forward animations. The mummy 
monster, located at (110, 0, 215) with a scale factor of 100, has an initial idle animation and rotates 
based on a custom script (you need to implement it). Bryce's objective is to reach the randomly placed 
Rune Pillar (X: [50-200], Z: [60-100]). 
Implement environmental and lighting settings with ambient lighting (Pitch Black Color) and a 
directional light at (50, 0, 0) rotation, (200, 200, 200) color, and 0.5 intensity. Design game logic 
where Bryce incurs damage if caught by the mummy in non-idle states, with the mummy performing a 
dance animation right after catching Bryce. The monster should continue rotating right after. If Bryce 
reaches the divine pillar, the monster will die. (Use the provided monster die animation once). 
For the mummy, set the initial rotation speed to (90 + alert) units multiplied by Delta time, with alert 
changing based on Bryce's actions. Attach a spotlight to the mummy's eye with a range of 250, a 
spot angle of 70, and an intensity of 100. The spotlight shifts from green to red upon detecting 
Bryce's movements, reverting to green when the mummy turns away.  
Ultimately, the mummy looks around (you can use the provided look around animation once every 
rotation) right after rotating to face Bryce, dances upon catching Bryce in a non-idle state, and 
rotates away before initiating a new random rotation cycle. 
The divine pillar must have a blinking point light with an intensity of 10, a color of (0, 250, 250) and 
a varying range of (0 to 50) depending on the blinking state (use a C# script to manage the blinking). 
The maximum blinking time should not exceed 2 seconds. 
Bryce must always be followed by an Orbital camera without any automatic recentering. Place the 
camera as you like, but make sure that the forward view always includes the monster.  
