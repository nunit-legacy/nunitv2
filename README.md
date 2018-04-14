# NUnit V2

This project continues support for NUnit V2 beyond the 2.6.4 release, which was the last one produced by the NUnit Project itself. This README file replaces the original file which is available in the same directory as OLD_README.md.

For general information about the NUnit Legacy project, see http://github.com/nunit-legacy/governance

## Scope

To be clear, first, we are __not__ going to do major or extensive revision to the features of NUnit V2. That's what NUnit 3 is about!

We will do a mix of the following:

 1. Fix outstanding bugs in NUnit V2, where possible. (In a few cases, bugs were left in V2 because they could only be fixed after the NUnit 3 re-design.)

 2. Backport __selected, small__ features and enhancements from NUnit 3, with priority given to those that allow users to make their test code more compatible with (and convertible to) NUnit 3.

 3. Provide new features to identify compatibility problems in the test code in order to help users move toward an eventual NUnit 3 conversion.

 4. Restructure the project as needed to make it easier to continue to maintain it. The level of effort we put into this type of work will depend on how long we expect the project to last. For the first relaase or two, we will live with some of the inefficiencies involved in building the project with all components and using older technology, until we see how useful the project actually is to V2 users.

## Versioning

Because the community previews leading to NUnit 3 were versioned as 2.9.x, we only have versions from 2.6.5 through 2.8.x available to us.

Small fixes (items 1-3 in the previous section) will therefore be versioned as 2.6.x. If we do a major reorganization of the code (item 4) that will start a new 2.7 series.
 
## License

The project continues to use the same NUnit license that was used by earlier releases. See license.txt in the root directory.

<hr>
<div align="right">
Charlie Poole<br>
April, 2018
</div>
