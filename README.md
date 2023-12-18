# FrdvTool
Fox Engine .frdv Fox Rig Driver decompiler/compiler. Based on research by Joey35233.

# Usage
To decompile a .frdv file or compile a decompiled .frdv.xml file, simply drag the target file over the application .exe.

**In command line:**:
> FrdvTool file.frdv

> FrdvTool file.frdv.xml

To preserve the bone name (in a string, or if one is not available in the fmdl_dictionary.txt included with the release, a hexadecimal hash), make sure the .frdv's original .fmdl file is located in the same folder as the .frdv or .frdv.xml upon execution, with the same filename, sans extension(s). Otherwise, you won't be able to compile a .frdv.xml file that was decompiled with the .fmdl's hashes or strings correctly. You can still decompile a .frdv without a .fmdl, but you'd have to use much less intelligible bone indices.
