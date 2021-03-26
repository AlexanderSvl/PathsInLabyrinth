# PathsInLabyrinth

**A C# .Net Core app, which finds all the possible paths in a given labyrinth using recursion**. All the possible solutions are written in a .txt file, named **"solutions.txt"**, located in **PathsInLabyrinth/bin/Debug/netcoreapp3.1/solutions.txt**.

The input labyrinth has to be in the following format:

"S" - Start
"-" - Free
"*" - Wall
"E" - Exit.
 
Some examples:

Input: 
4
5

S--*\
-*--\
--*-\
*---\
---E\

Output:

RRDRDDD
RRDRDDLDR
RRDRDDLLDRR
DDRDRRD
DDRDRDR
DDRDDRR
DDRDDRURD

7 possible solutions.

-------------------------------------------

Input:
5
5

--S--
*--*-
---*-
-----
**-E-

Output:

RRDDDDL
RRDDDLD
RRDDDLLDR
DDDRRDL
DDDRD
DDDDR
DDLDRRRDL
DDLDRRD
DDLDRDR
DDLLDRRRRDL
DDLLDRRRD
DDLLDRRDR
DLDRDRRDL
DLDRDRD
DLDRDDR
DLDDRRRDL
DLDDRRD
DLDDRDR
DLDLDRRRRDL
DLDLDRRRD
DLDLDRRDR
LDRDDRRDL
LDRDDRD
LDRDDDR
LDRDLDRRRDL
LDRDLDRRD
LDRDLDRDR
LDRDLLDRRRRDL
LDRDLLDRRRD
LDRDLLDRRDR
LDDRDRRDL
LDDRDRD
LDDRDDR
LDDDRRRDL
LDDDRRD
LDDDRDR
LDDLDRRRRDL
LDDLDRRRD
LDDLDRRDR

39 possible solutions.
