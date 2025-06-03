# Terrain-Recognition

You work for the Brazilian Army and will be primarily responsible for developing terrain recognition software. 
This software will use a newly acquired radar device. 
The device operates according to the following specifications, described in its manual:

1 – The device reads a limited square area at a time. This area is represented by matrices, where each item represents 1 m² of the area read. The value of each item in the matrix will depend on the type of reading performed.

2 – A reading can be obtained to identify possible obstacles to passage in the area read, using the GetObstacleReading method. Each element in this matrix can assume the value “0”, if it does not correspond to an obstacle, or “1”, otherwise.

3 – A reading of the probability of landmines in each m² of the region can be obtained, using the GetLandMineReading method. In this case, each element of the matrix will have a value from 0 to 100, corresponding to the probability of mines being present in that m².

4 – A reading of the terrain type can be obtained. In this case, each element of the matrix will have the value “0”, if it corresponds to solid ground, or a numerical value above 0 if it corresponds to water, with the value representing the depth of the terrain covered by water in meters.

5 – The methods for obtaining the reading are already ready in the device’s function library.

In a meeting with an expert in this area, the following rules were established:

1 – It is possible to cross one m² of terrain covered by water on foot if it is no more than 1 meter deep. It is not possible to cross one m² of terrain that contains obstacles on foot.

2 – A terrain can be classified into 4 security levels:

Level 1 – Safe area – There is no greater than a 50% chance of having a landmine anywhere on the terrain.

Level 2 – Caution area – Unsafe area where up to 10% of the terrain area has a greater than 50% probability of having landmines.

Level 3 – Dangerous area – 10 to 50% of the terrain area has a greater than 50% probability of having landmines.

Level 4 – Not recommended area – More than 50% of the terrain area has a greater than 50% probability of having landmines.

Based on these rules, the following are requested:

6 – Develop an algorithm that reads a terrain and reports the percentage of its area covered by water or obstacles.

7 – Develop an algorithm that reads a terrain and reports the average depth of its entire area covered by water.

8 – Develop an algorithm that determines whether a terrain can be crossed on foot in a straight line. If the only straight line where it is possible to cross the terrain has a m² with a probability greater than 10% of containing mines, the user must be warned.

9 - Develop an algorithm that reads a terrain and informs its level of security.

10 – Develop an algorithm that reads a terrain and determines whether there is a strategically useful islet on the terrain. An islet is a 1m² space of land surrounded by water on all sides. It is only strategically useful if it does not have an obstacle and has a 0 probability of containing mines.
