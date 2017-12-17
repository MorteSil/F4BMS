# F4BMS
Class Library used to interact with Falcon BMS file types

This is the Class File I created during my work on the Falcon Mod Tool.  This Library is written in C#, but most of the classes are COM Exposed, so developers should be able to use it in unmanaged projects.

This Library is still a Work in Progress.  However, I consider it complete enough to provide it as an initial release for developers to experiment with.

Please read that again:  This Library is still a Work in Progress.  

I have done a considerable amount of testing with it and tried to implement error handling for as many potential issues or incorrect usages as I could think of during development.  However, it is EXTREMELY important to back up your data prior to doing any kind of modification to the CT or LOD database.  This is a CLASS LIBRARY, not a full implementation, which means it interacts with raw data, and provides very little validation of logical data as it pertains to BMS.  The classes are written to adhere to the file and type limitations, not the logical limitations of implementation.

At this time, I am not ready to post the Source Code, as it is still in development.  I will at some point post it once the Falcon Mod Tool has been completed and released, and all the functions and classes have been thoroughly tested and verified to function correctly.

If you use or experiment with this library, you do so at your own risk.  Please post any issues, concerns, or questions about the Library on this page, or contact me on the BMS Forums and I will do what I can to respond in kind.

Functions currently available:
HDR and LOD file interaction including all the BSP nodes currently being used (As of 4.33.4).  The file is also capable of handling the new HDR structure which allows greater than 2GB LOD file size.  This feature is not yet implemented in BMS, so DO NOT generate LOD files greater than 2GB.  The feature is included in preparation for the changes coming in a future BMS release.

CT Database interaction.  Library handles all the CT files in the OBJECTS folder.  These are the same files the BMS Editor interacts with which have a file name of FALCON4.*  The Library will allow you to export the files as XML.  The XML File Format IS NOT currently compatible with the impending changes to the F4BMS CT DB structure.  When the format is finalized, I will adjust the XML structure to match the new DB Files.

Key File interaction.  The Library includes a class to handle Key Files.  Currently, all key files will be generated with the initial comments, and a few comments to denote where DX, DX Shifted, and POV bindings are in the file.  It WILL retain all the comments and seperators which come with the default key files, but it will not generate them if the file has been saved in BMS and they are gone.

Have fun, be safe, back up your files... Morte
