My assumptions:
1. The tax table is mutable.
2. The steps for processing pay slips is mutable. 

For dealing with my assumptions, my solution is :
1. I write the tax table in a configure file.
2. I use the responsibility chain pattern to extend processing steps for both pay slip and tax easily.
3. I use the factory pattern for creating the processing chain flexibly.
4. I use the template pattern for reducing code redundancy.

The program's entry is Program.cs


